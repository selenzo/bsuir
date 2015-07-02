using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace FTPCom
{
	// State object for receiving data from remote device.
	public class DataStateObject 
	{
		public Socket workSocket = null;              // Client socket.
		public const int BufferSize = 512;            // Size of receive buffer.
		public byte[] buffer = new byte[BufferSize];  // Receive buffer.
		public StringBuilder sb = new StringBuilder();// Received data string.
		public FileStream fs = null;				  // File Stream Input / Output
		public int BytesTransfered = 0;				  // Nb bytes transfered
		public byte[] bufferupload;
		public FTPMonitor ftpmonitor;
	}

	/// <summary>
	/// 
	/// </summary>
	public class DataAsyncSocket
	{
		private string m_lasterror;
		private int m_datacmd;
		private Socket m_sock;
		private string m_filename;
		private int m_filesize;
		private FTPMonitor m_ftpmonitor;
		private string m_response;
		private const string      CRLF = "\r\n";
		private int m_startTick;
		private int m_endTick;

		public DataAsyncSocket(FTPMonitor ftpmonitor)
		{
			// 
			// TODO: Add constructor logic here
			//
			m_lasterror = "";
			m_datacmd = 0;
			m_ftpmonitor = ftpmonitor;
			m_response = "";
		}


		public void Connect(string hostname, int port)
		{
			// Connect to a remote device.
			try 
			{
				// Establish the remote endpoint for the socket.
				IPHostEntry ipHostInfo = Dns.Resolve(hostname);
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

				//  Create a TCP/IP  socket.
				m_sock = new Socket(AddressFamily.InterNetwork,
					SocketType.Stream, ProtocolType.Tcp);

				// Connect to the remote endpoint.
				m_sock.BeginConnect( remoteEP, 
					new AsyncCallback(ConnectCallback), m_sock);

			} 
			catch (Exception e) 
			{
				m_lasterror = e.Message;
				ErrorNotify("DataAsyncSocket.Connect");
			}
		}

		private void ConnectCallback(IAsyncResult ar) 
		{
			try 
			{
				// Retrieve the socket from the state object.
				Socket sock = (Socket) ar.AsyncState;

				// Complete the connection.
				sock.EndConnect(ar);

				// 
				if (m_datacmd == 0) 
					Receive();
				else
					if (m_datacmd == 1)
						ReceiveFile();
					else
						SendFile();

				// Signal that the connection has been made.
				m_ftpmonitor.DataSocketConnected();

			} 
			catch (Exception ex) 
			{
				m_lasterror = ex.Message;
				ErrorNotify("DataAsyncSocket.ConnectCallback");
			}
		}

		public void Receive() 
		{
			try 
			{
				m_startTick = Environment.TickCount;

				// Create the state object.
				DataStateObject state = new DataStateObject();
				state.workSocket = m_sock;

				// Begin receiving the data from the remote device.
				m_sock.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
					new AsyncCallback(ReceiveCallback), state);
			} 
			catch (Exception e) 
			{
				m_lasterror = e.Message;
				ErrorNotify("DataAsyncSocket.Receive");
			}
		}
		public void ReceiveCallback( IAsyncResult ar ) 
		{
			try 
			{
				// Retrieve the state object and the client socket 
				// from the async state object.
				DataStateObject state = (DataStateObject) ar.AsyncState;
				Socket sock = state.workSocket;

				// Read data from the remote device.
				int bytesRead = sock.EndReceive(ar);
				state.BytesTransfered  += bytesRead;

				if (bytesRead > 0)
				{
					// There might be more data, so store the data received so far.
					string s = Encoding.ASCII.GetString(state.buffer,0,bytesRead);
					state.sb.Append(s);

					if (state.sb.ToString().EndsWith(CRLF))
					{
						m_endTick = Environment.TickCount;
						m_response = state.sb.ToString();
						m_ftpmonitor.TransferCompleted(state.BytesTransfered, m_endTick - m_startTick);
					}
					else
					{
						//  Get the rest of the data.
						sock.BeginReceive(state.buffer,0,StateObject.BufferSize,0,
							new AsyncCallback(ReceiveCallback), state);
					}
				}
				else
				{
					m_endTick = Environment.TickCount;
					m_ftpmonitor.TransferCompleted(state.BytesTransfered, m_endTick - m_startTick);
				}
			} 
			catch (Exception e) 
			{
				m_lasterror = e.Message;
				ErrorNotify("DataAsyncSocket.ReceiveCallback");
			}
		}

		public int DataCommande
		{
			get
			{
				return m_datacmd;
			}
			set
			{
				m_datacmd = value;
			}
		}

		public void SendFile()
		{
			try 
			{
				m_startTick = Environment.TickCount;

				// Create the state object.
				DataStateObject state = new DataStateObject();
				state.workSocket = m_sock;
				state.fs = new FileStream(m_filename, FileMode.Open);
				state.BytesTransfered = 0;

				m_filesize = (int)state.fs.Length;
				state.bufferupload = new byte[state.fs.Length];
				state.fs.Read(state.bufferupload, 0, (int)state.fs.Length);
				state.fs.Close();

				// Begin sending the data.
				m_sock.BeginSend( state.bufferupload, 0, (int)state.bufferupload.Length, 0,
					new AsyncCallback(SendFileCallback), state);
			} 
			catch (Exception e) 
			{
				m_lasterror = e.Message;
				ErrorNotify("DataAsyncSocket.SendFile");
			}				
		}

		private void SendFileCallback(IAsyncResult ar) 
		{
			try 
			{
				// Retrieve the socket from the state object.
				DataStateObject state = (DataStateObject) ar.AsyncState;
				Socket sock = state.workSocket;

				// Complete sending the data to the remote device.
				int bytesSent = sock.EndSend(ar);

				state.BytesTransfered  += bytesSent;

				if (state.BytesTransfered >= m_filesize)
				{
					sock.Close();
					m_endTick = Environment.TickCount;
					m_ftpmonitor.TransferCompleted(state.BytesTransfered, m_endTick - m_startTick);
				}
				else 
				{					
					m_sock.BeginSend( state.bufferupload, state.BytesTransfered, (int)state.fs.Length, 0,
						new AsyncCallback(SendFileCallback), state);
				}
			} 
			catch (Exception e) 
			{
				m_lasterror = e.Message;
				ErrorNotify("DataAsyncSocket.SendFileCallBack");
			}
		}

		public void ReceiveFile()
		{
			try 
			{
				m_startTick = Environment.TickCount;

				// Create the state object.
				DataStateObject state = new DataStateObject();
				state.workSocket = m_sock;
				state.fs = new FileStream(m_filename, FileMode.Create);
				state.BytesTransfered = 0;

				// Begin receiving the data from the remote device.
				m_sock.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
					new AsyncCallback(ReceiveFileCallback), state);
			} 
			catch (Exception e) 
			{
				m_lasterror = e.Message;
				ErrorNotify("DataAsyncSocket.ReceiveFile");
			}		
		}
		private void ReceiveFileCallback( IAsyncResult ar ) 
		{
			try 
			{
				// Retrieve the state object and the client socket 
				// from the async state object.
				DataStateObject state = (DataStateObject) ar.AsyncState;
				Socket sock = state.workSocket;

				// Read data from the remote device.
				int bytesRead = sock.EndReceive(ar);

				// There might be more data, so store the data received so far.
				state.fs.Write(state.buffer, 0, bytesRead);
				state.BytesTransfered  += bytesRead;

				//m_ftpmonitor.PourcentDownload(state.BytesTransfered, m_filesize);

				if (state.BytesTransfered >= m_filesize)
				{
					sock.Close();
					state.fs.Close();
					m_endTick = Environment.TickCount;
					m_ftpmonitor.TransferCompleted(state.BytesTransfered, m_endTick - m_startTick);
				}
				else 
				{
					//  Get the rest of the data.
					sock.BeginReceive(state.buffer,0,StateObject.BufferSize,0,
						new AsyncCallback(ReceiveFileCallback), state);
				}
			} 
			catch (Exception e) 
			{
				m_lasterror = e.Message;
				ErrorNotify("DataAsyncSocket.ReceiveFileCallback");
			}
		}
		private void MessageNotify()
		{
			m_ftpmonitor.MessageNotify(m_response);
		}

		private void ErrorNotify(string functionName)
		{			
			m_ftpmonitor.ErrorNotify(m_lasterror, functionName);
		}

		public string Filename
		{
			get
			{
				return m_filename;
			}
			set
			{
				m_filename = value;
			}
		}

		public int FileSize
		{
			get
			{
				return m_filesize;
			}
			set
			{
				m_filesize = value;
			}
		}

		public string Response
		{
			get
			{
				return m_response;
			}
		}

		public void Disconnect()
		{
			m_sock.Close();
		}
	}
}
