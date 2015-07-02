namespace FTPCom
{
    /// <summary>
    /// Class that store FTP Commands with parameters - use with FTP Queue
    /// </summary>
    public class FTPCommand
    {
        public string Command = "";				// FTP Command (ex: USER, RETR, ....)
        public int Response = 0;				// Code reponse attented
        public string sParam = "";				// String parameter (ex : filename)
        public int iParam = 0;					// Int parameter (ex : filesize)
        private const string CRLF = "\r\n";

        public FTPCommand(string cmd, int response)
        {
            Command = cmd;
            Response = response;
        }

        public FTPCommand(string cmd, int response, string sparam)
        {
            Command = cmd;
            Response = response;
            sParam = sparam;
        }

        public FTPCommand(string cmd, int response, string sparam, int iparam)
        {
            Command = cmd;
            Response = response;
            sParam = sparam;
            iParam = iparam;
        }

        /// <summary>
        /// Format the FTP Command to send to the Host
        /// </summary>
        /// <returns></returns>
        public string GetCommandLine()
        {
            string s;

            s = Command;
            if (sParam != "")
                s = s + " " + sParam;
            s += CRLF;
            return s;
        }
    }
}