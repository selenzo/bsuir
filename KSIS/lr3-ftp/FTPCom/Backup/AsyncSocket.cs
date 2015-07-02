using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections;

namespace FTPCom
{
	// State object for receiving data from remote device.
	public class StateObject 
	{
		public Socket workSocket = null;              // Client socket.
		public const int BufferSize = 512;            // Size of receive buffer.
		public byte[] buffer = new byte[BufferSize];  // Receive buffer.
		public StringBuilder sb = new StringBuilder();// Received data string.
		public string scode = string.Empty;
		public StringBuilder multires = new StringBuilder();
	}


	/// <summary>
	/// 
	/// </summary>
	public class AsyncSocket
	{
		private FTPMonitor m_ftpmonitor;
		private Socket m_sock;
		private const string      CRLF = "\r\n";

		public AsyncSocket(FTPMonitor ftpmonitor)
		{
			m_ftpmonitor = ftpmonitor;
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
				m_ftpmonitor.ErrorNotify(e.Message, "AsyncSocket.Connect");
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

				// Prepare to receive data
				Receive();

				// Signal that the connection has been made.
				//m_ftpmonitor.ConnectionCompleted();
				// Only if response equal 220 OK
			} 
			catch (Exception e) 
			{
				m_ftpmonitor.ErrorNotify(e.Message, "AsyncSocket.ConnectCallback");
			}
		}

		public void Receive() 
		{
			try 
			{
				// Create the state object.
				StateObject state = new StateObject();
				state.workSocket = m_sock;

				// Begin receiving the data from the remote device.
				m_sock.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
					new AsyncCallback(ReceiveCallback), state);
			} 
			catch (Exception e) 
			{
				m_ftpmonitor.ErrorNotify(e.Message, "AsyncSocket.Receive");
			}
		}
		private void ReceiveCallback( IAsyncResult ar ) 
		{
			try 
			{
				// Retrieve the state object and the client socket 
				// from the async state object.
				StateObject state = (StateObject) ar.AsyncState;
				Socket sock = state.workSocket;

				// Read data from the remote device.
				int bytesRead = sock.EndReceive(ar);

				if (bytesRead > 0) 
				{
					string s = Encoding.ASCII.GetString(state.buffer,0,bytesRead);
					state.sb.Append(s);

					string response = state.sb.ToString();
					if (response.EndsWith(CRLF))
					{
						ReceiveResponse(response, state);
						state.sb.Remove(0, state.sb.Length);			
					}
				} 

				//  Get the rest of the data.
				sock.BeginReceive(state.buffer,0,StateObject.BufferSize,0,
					new AsyncCallback(ReceiveCallback), state);

			} 
			catch (ObjectDisposedException e) 
			{
				//Nothing
			}

			catch (Exception e) 
			{
				m_ftpmonitor.ErrorNotify(e.Message, "AsyncSocket.ReceiveCallback");
			}
		}

		private void ReceiveResponse(string response, StateObject state)
		{
			string scode = string.Empty;
			ArrayList lResponse = new ArrayList();

			int i, j;
			int maxline = 0;			

			i = 0;
			do 
			{
				j = response.IndexOf(CRLF, i);
				if (j > -1)
				{
					lResponse.Add (response.Substring(i, j - i));
					i = j + 2;
				}
				else
				{
					lResponse.Add (response.Substring(i, response.Length - i));
				}
				maxline++;
			} while (i < response.Length);

			int idline = 0;		
			int idstart = 0;

			do 
			{
				if (((string)lResponse[idline]).Length > 3)
				{
					if (((string)lResponse[idline])[3] == '-' || state.multires.Length > 0)
					{
						if (state.multires.Length == 0)
						{
							state.multires.Append ( lResponse[idline]);
							state.scode = ((string)lResponse[idline]).Substring(0,3);
							idstart = idline + 1;
						}
						else
							idstart = idline;
						for (j = idstart; j < lResponse.Count; j++)
						{
							state.multires.Append( lResponse[j]);
							if (((string)lResponse[j]).Length > 3)
								if (((string)lResponse[j]).Substring(0,3) == state.scode && ((string)lResponse[j])[3] != '-')
									break;
						}
						if (j < lResponse.Count)
						{
							m_ftpmonitor.Reply(state.multires.ToString());
							state.multires.Remove(0, state.multires.Length);
						}
						idline = j + 1;
					}
					else
					{
						m_ftpmonitor.Reply((string)lResponse[idline]);
						idline++;
					}
				}
				else
					idline++;
			} while (idline < lResponse.Count);
		}

		public void Send(string data) 
		{
			try
			{
				// Retrieve the response
				//Receive();

				// Convert the string data to byte data using ASCII encoding.
				byte[] byteData = Encoding.ASCII.GetBytes(data);

				// Begin sending the data to the remote device.
				m_sock.BeginSend(byteData, 0, byteData.Length, 0,
					new AsyncCallback(SendCallback), m_sock);
			}
			catch (Exception e)
			{
				m_ftpmonitor.ErrorNotify(e.Message, "AsynckSocket.Send");
			}
		}

		private void SendCallback(IAsyncResult ar) 
		{
			try 
			{
				// Retrieve the socket from the state object.
				Socket sock = (Socket) ar.AsyncState;

				// Complete sending the data to the remote device.
				int bytesSent = sock.EndSend(ar);

				// All bytes sended ?????

			} 
			catch (Exception e) 
			{
				m_ftpmonitor.ErrorNotify(e.Message, "AsynckSocket.SendCallBack");
			}
		}

		public void Close()
		{
			try
			{
				m_sock.Close();
			}
			catch (Exception e)
			{
				m_ftpmonitor.ErrorNotify(e.Message, "AsynckSocket.SendCallBack");
			}
		}
	}
}
