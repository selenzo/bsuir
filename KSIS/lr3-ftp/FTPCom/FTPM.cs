using System;
using System.Collections;

namespace FTPCom
{
    /// <summary>
    ///
    /// </summary>
    public class FTPMonitor
    {
        // Canal de commande
        private AsyncSocket m_cmdSock;

        // Canal de données
        private DataAsyncSocket m_dataSock;

        public FTPC m_ftpcom;
        private const string CRLF = "\r\n";

        private ArrayList m_cmdList = new ArrayList();
        private FTPCommand m_CurrentCommand = null;
        private FTPCommand m_NextCommand = null;

        private bool m_bConnected = false;

        public FTPMonitor(FTPC ftpcom)
        {
            m_ftpcom = ftpcom;
            m_cmdSock = null;
            m_dataSock = null;
        }

        public bool Connect(string hostname, int port)
        {
            bool bres = false;

            if (m_bConnected)
                return false;

            if (hostname != "" && port != 0)
            {
                m_cmdSock = new AsyncSocket(this);
                m_cmdSock.Connect(hostname, port);
                bres = true;
            }

            return bres;
        }

        private void AddCommandList(FTPCommand Command)
        {
            if (m_NextCommand == null)
                m_NextCommand = Command;
            m_cmdList.Add(Command);
        }

        public void SendCommand(FTPCommand Command)
        {
            if (m_CurrentCommand != null || m_bConnected == false)
            {
                if (Command.Command == "RETR" || Command.Command == "STOR" || Command.Command == "LIST")
                {
                    AddCommandList(new FTPCommand("PASV", 227));
                }
                AddCommandList(Command);
            }
            else
            {
                if (Command.Command == "RETR" || Command.Command == "STOR" || Command.Command == "LIST")
                {
                    AddCommandList(Command);
                    ProceedCommand(new FTPCommand("PASV", 227));
                }
                else
                    ProceedCommand(Command);
            }
        }

        private void ProceedCommand(FTPCommand Command)
        {
            m_CurrentCommand = Command;
            if (m_cmdList.Count > 0)
                m_NextCommand = (FTPCommand)m_cmdList[0];
            else
                m_NextCommand = null;
            CommandNotify(Command.GetCommandLine());
            m_cmdSock.Send(Command.GetCommandLine());
        }

        private void CreateDataSocket(string ipaddress, int port)
        {
            m_dataSock = new DataAsyncSocket(this);
            if (m_NextCommand.Command == "LIST")
            {
                m_dataSock.DataCommande = 0;
            }
            else
            {
                if (m_NextCommand.Command == "RETR")
                {
                    m_dataSock.Filename = m_ftpcom.LocalFolder + "\\" + m_NextCommand.sParam;
                    m_dataSock.FileSize = m_NextCommand.iParam;
                    m_dataSock.DataCommande = 1;
                }
                else
                {
                    m_dataSock.Filename = m_ftpcom.LocalFolder + "\\" + m_NextCommand.sParam;
                    m_dataSock.FileSize = m_NextCommand.iParam;
                    m_dataSock.DataCommande = 2;
                }
            }
            m_dataSock.Connect(ipaddress, port);
        }

        public void TransferCompleted(int BytesTransfered, int TimeElapsed)
        {
            string s;

            s = m_dataSock.Response;

            m_dataSock.Disconnect();

            FTPEventArgs e = new FTPCom.FTPEventArgs();
            e.TotalBytes = BytesTransfered;
            e.TimeElapsed = TimeElapsed;
            e.Message = s;
            if (m_dataSock.DataCommande == 0)
                m_ftpcom.OnDirCompleted(e);
            else if (m_dataSock.DataCommande == 1)
                m_ftpcom.OnFileDownloadCompleted(e);
            else
                m_ftpcom.OnFileUploadCompleted(e);

            m_dataSock = null;
        }

        public void DataSocketConnected()
        {
            ProceedNextCommand();
        }

        public void CommandNotify(string msg)
        {
            FTPEventArgs e = new FTPCom.FTPEventArgs();
            e.Message = msg.Substring(0, msg.Length - 2);
            m_ftpcom.OnFTPCommand(e);
        }

        public void MessageNotify(string msg)
        {
            FTPEventArgs e = new FTPCom.FTPEventArgs();
            e.Message = msg;
            m_ftpcom.OnMessage(e);
        }

        public void ErrorNotify(string msg, string functionName)
        {
            CancelCommand();

            FTPEventArgs e = new FTPCom.FTPEventArgs();
            e.Message = msg;
            e.FunctionName = functionName;
            m_ftpcom.OnError(e);
        }

        public void PourcentDownload(int bytestransfered, int totalbytes)
        {
            string msg = bytestransfered.ToString() + CRLF;

            FTPEventArgs e = new FTPCom.FTPEventArgs();
            e.Message = msg;
            m_ftpcom.OnMessage(e);
        }

        public void LoginCompleted()
        {
            FTPEventArgs e = new FTPCom.FTPEventArgs();
            e.Message = "";
            m_ftpcom.OnLogged(e);
        }

        public void LoginFailure()
        {
            CancelCommand();
            FTPEventArgs e = new FTPCom.FTPEventArgs();
            e.Message = "";
            m_ftpcom.OnLoginFailure(e);
        }

        public void ProceedNextCommand()
        {
            if (m_cmdList.Count > 0)
            {
                FTPCommand cmd = (FTPCommand)m_cmdList[0];
                m_cmdList.RemoveAt(0);
                ProceedCommand(cmd);
            }
            else
                m_CurrentCommand = null;
        }

        public void ConnectionCompleted()
        {
            FTPEventArgs e = new FTPCom.FTPEventArgs();
            e.Message = "";
            m_ftpcom.OnConnected(e);

            // The connection is succeeded
            m_bConnected = true;
            ProceedNextCommand();
        }

        private void CancelCommand()
        {
            m_cmdList.Clear();
            m_CurrentCommand = null;
        }

        private void RetrieveDataPort(string response, ref string AdresseIP, ref int Port)
        {
            int DebutIP, FinIP;
            string[] AdresseIPKit;
            string ReponseIP = "";
            string tmp = response;

            DebutIP = tmp.IndexOf("(") + 1;
            FinIP = tmp.IndexOf(")");
            ReponseIP = tmp.Substring(DebutIP, FinIP - DebutIP);
            char[] Separateur = { ',' };
            AdresseIPKit = ReponseIP.Split(Separateur);

            for (int Index = 0; Index < 3; Index++)
            {
                AdresseIP += AdresseIPKit[Index];
                AdresseIP += ".";
            }
            AdresseIP += AdresseIPKit[3];
            Port = Convert.ToInt32(AdresseIPKit[4]) * 256 + Convert.ToInt32(AdresseIPKit[5]);
        }

        public void Reply(string Response)
        {
            try
            {
                MessageNotify(Response);

                string sCode = Response.Substring(0, 3);
                int iCode = 0;

                try
                {
                    iCode = Convert.ToInt32(sCode);
                }
                catch (Exception e)
                {
                    // Ignore
                    return;
                }

                // Check Information Return
                if (iCode >= 100 && iCode < 200)
                    return;	// The message was notifed so quit

                if (m_CurrentCommand == null)
                {
                    // Pas de commandande envoyée
                    if (iCode == 220)
                        ConnectionCompleted();	// Connection accepted
                    if (iCode == 421)
                        ConnectionTerminated();	// Connection terminated by host
                }
                else
                {
                    if (m_CurrentCommand.Response == iCode)
                    {
                        // Reponse attendue
                        if (m_CurrentCommand.Command == "PASV")
                        {
                            string AdresseIP = string.Empty;
                            int Port = 0;

                            RetrieveDataPort(Response, ref AdresseIP, ref Port);
                            CreateDataSocket(AdresseIP, Port);
                        }
                        else
                        {
                            if (m_CurrentCommand.Command == "QUIT")
                                Disconnect();

                            if (m_CurrentCommand.Command == "PASS")
                                LoginCompleted();

                            if (m_CurrentCommand.Command == "PWD")
                                m_ftpcom.RemoteFolder = Response.Substring(3, Response.Length - 3);

                            ProceedNextCommand();
                        }
                    }
                    else
                    {
                        if (m_CurrentCommand.Response != 0)
                        {
                            if (m_CurrentCommand.Command == "PASS" && iCode == 530)
                                LoginFailure();
                            else
                            {
                                string s = m_CurrentCommand.Command + " " + m_CurrentCommand.Response.ToString() + " " + sCode;
                                MessageNotify(s);
                                MessageNotify("Server response different that expected");
                                CancelCommand();
                            }
                        }
                        else
                        {
                            ProceedNextCommand();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ErrorNotify(e.Message, "FTPM.Reply");
            }
        }

        private void Disconnect()
        {
            if (m_bConnected)
            {
                m_cmdSock.Close();
                m_cmdSock = null;
                m_bConnected = false;
            }
        }

        public void ConnectionTerminated()
        {
            Disconnect();
        }
    }
}