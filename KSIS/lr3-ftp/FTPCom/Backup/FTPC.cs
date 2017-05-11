// FTP Component for .NET
// April 2002 by Jérôme Lacaille

// Properties :
//		Username	: account username
//		Password	: account password
//		Hostname	: FTP Host server
//		Port		: FTP Host port
//		LocalFolder	: local path
//		RemoteFolder: remote path
//		FileCount	: Nb file on the current remote folder
//		Type		: Transfert Type (Ascii, Binary)

// Methods :
//		Connect()
//		Disconnect()				QUIT
//		Login()						
//		Abort()						ABORT
//		SystemInfo()				SYST
//		Help()						HELP
//		Stat()						STAT
//		Dir()						LIST
//		DirChange()					Select directory
//		DirUp()						CDUP
//		DirCreate(string filename)	MKD
//		FileDownload()				
//		FileUpload()				
//		Delete()					
//		Rename()					

//
// This component use asyncronous methods
// Each command result fire an event.

// Events
//		Connected				Succesful Connection to the remote host
//		Logged					Login succesful
//		FileDownloadCompleted	Download completed	
//		FileUploadCompleted		Upload Completed
//		DirCompleted			Dir Completed
//		Error					
//		Message
//		FTPCommand
//		Transfered
//		ConnectionTerminated

// TO DO
// Change File Array to File Collection

using System;
using System.ComponentModel;

namespace FTPCom
{

	// Delegate declaration.
	//
	public delegate void FTPEventHandler(object sender, FTPEventArgs e);

	/// <summary>
	/// Main Class for FTP Component
	/// Provide simple interface
	/// </summary>
	public class FTPC : System.ComponentModel.Component
	{
		private string m_username;						// username account
		private string m_password;						// username password

		private string m_hostname;						// hostname
		private int m_port;								// host port

		private string m_localfolder;					// local folder string path
		private string m_remotefolder;					// remote folder string path

		private string m_type;

		private FTPMonitor m_ftpmonitor;				// FTP Monitor Class

		private int m_filecount = 0;					// Remote folder file count
		private ServerFileData[] m_files = new ServerFileData[255];		// remote file array !!! TO DO

		public FTPC()
		{
			m_username = string.Empty;
			m_password = string.Empty;
			m_hostname = string.Empty;
			m_port = 21;								// Default port
			m_localfolder = "c:\\temp";					// Local folder !! TO DO
			m_remotefolder = string.Empty;
			m_type = "A";
			m_ftpmonitor = new FTPMonitor(this);
		}

		/// <summary>
		/// Component properties
		/// </summary>
		[
		Category("Account"),
		Description("FTP account username"),
		]
		public string Username
		{
			get
			{
				return m_username;
			}
			set
			{
				m_username = value;
			}
		}

		[
		Category("Account"),
		Description("FTP account password"),
		]
		public string Password
		{
			get
			{
				return m_password;
			}
			set
			{
				m_password = value;
			}
		}

		[
		Category("FTP Server"),
		Description("FTP server hostname"),
		]
		public string Hostname
		{
			get
			{
				return m_hostname;
			}
			set
			{
				m_hostname = value;
			}
		}

		[
		Category("FTP Server"),
		Description("FTP Server port"),
		DefaultValue(22)
		]
		public int Port
		{
			get
			{
				return m_port;
			}
			set
			{
				m_port = value;
			}
		}

		[
		Category("Directory"),
		Description("Local directory"),
		]
		public string LocalFolder
		{
			get
			{
				return m_localfolder;
			}
			set
			{
				m_localfolder = value;
			}
		}

		[
		Category("Directory"),
		Description("Remote directory"),
		]
		public string RemoteFolder
		{
			get
			{
				return m_remotefolder;
			}
			set
			{
				m_remotefolder = value;
			}
		}

		private int GetFileIndex(string FileName)
		{
			int ires = -1;
			int i;

			for (i = 0; i < m_filecount; i++)
			{
				if (FileName == m_files[i].fileName)
				{
					ires = i;
					break;
				}
			}

			return ires;
		}

		/// <summary>
		/// Connection to remote Host
		/// </summary>
		/// <returns></returns>
		public bool Connect()
		{
			m_ftpmonitor.Connect(m_hostname, m_port);

			return true;
		}

		/// <summary>
		/// Login
		/// </summary>
		/// <returns></returns>
		public bool Login()
		{
			bool bres = false;

			if (m_username != string.Empty && m_password != string.Empty)
			{
				m_ftpmonitor.SendCommand(new FTPCommand("USER", 331, m_username));
				m_ftpmonitor.SendCommand(new FTPCommand("PASS", 230, m_password));
				m_ftpmonitor.SendCommand(new FTPCommand("SYST", 0));
				m_ftpmonitor.SendCommand(new FTPCommand("PWD", 257));	// Will be accessible by RemoteFolder Property
				m_ftpmonitor.SendCommand(new FTPCommand("TYPE", 200, "A"));
				bres =  true;
			}

			return bres;
		}

		public void Disconnect()
		{
			m_ftpmonitor.SendCommand(new FTPCommand("QUIT", 221));
		}

		public void Dir()
		{
			m_ftpmonitor.SendCommand(new FTPCommand("TYPE I", 200));
			m_ftpmonitor.SendCommand(new FTPCommand("LIST", 226));
		}

		public bool DirChange(int FileIndex)
		{
			bool bres = false;

			if (FileIndex < m_filecount)
			{
				m_ftpmonitor.SendCommand(new FTPCommand("CWD", 250, m_files[FileIndex].fileName));
				bres = true;
			}
			return bres;
		}

		public bool DirChange(string FileName)
		{
			bool bres = false;
			int FileIndex = GetFileIndex(FileName);

			if (FileIndex > -1)
				bres = DirChange(FileIndex);

			return bres;
		}

		public void DirUp()
		{
			m_ftpmonitor.SendCommand(new FTPCommand("CDUP", 250));
		}

		public void DirCreate(string FileName)
		{
			m_ftpmonitor.SendCommand(new FTPCommand("MKD", 257, FileName));
		}

		public void Abort()
		{
			m_ftpmonitor.SendCommand(new FTPCommand("ABOR", 0));
		}

		public void SystemInfo()
		{
			m_ftpmonitor.SendCommand(new FTPCommand("SYST", 0));
		}

		public void Help()
		{
			m_ftpmonitor.SendCommand(new FTPCommand("HELP", 0));
		}

		public void Stat()
		{
			m_ftpmonitor.SendCommand(new FTPCommand("STAT", 0));
		}

		/// <summary>
		/// Download file whose index equal FileIndex
		/// </summary>
		/// <param name="FileIndex"></param>
		/// <returns></returns>
		public bool FileDownload(int fileindex)
		{
			bool bres = false;

			if (fileindex < m_filecount)
			{
				m_ftpmonitor.SendCommand(new FTPCommand("TYPE I", 200));
				m_ftpmonitor.SendCommand(new FTPCommand("RETR", 226, m_files[fileindex].fileName, m_files[fileindex].size ));
				bres =  true;
			}

			return bres;
		}
		/// <summary>
		/// Download file whose name equal Filename
		/// </summary>
		/// <param name="filename"></param>
		public bool FileDownload(string FileName)
		{
			bool bres = false;
			int FileIndex = GetFileIndex(FileName);

			if (FileIndex > -1)
				bres = FileDownload(FileIndex);

			return bres;
		}

		public void FileUpload(string FileName, int FileSize)
		{
			m_ftpmonitor.SendCommand(new FTPCommand("TYPE I", 200));
			m_ftpmonitor.SendCommand(new FTPCommand("STOR", 226, FileName, FileSize ));
		}

		public bool Delete(int FileIndex)
		{
			bool bres = false;
			if (FileIndex < m_filecount)
			{
				if (m_files[FileIndex].isDirectory)
					m_ftpmonitor.SendCommand(new FTPCommand("RMD", 250, m_files[FileIndex].fileName ));
				else
					m_ftpmonitor.SendCommand(new FTPCommand("DELE", 250, m_files[FileIndex].fileName ));
				bres = true;
			}
			return bres;
		}

		public bool Delete(string FileName)
		{
			bool bres = false;
			int FileIndex = GetFileIndex(FileName);

			if (FileIndex > -1)
				bres = Delete(FileIndex);

			return bres;
		}

		public bool Rename(int FileIndex, string NewFileName)
		{
			bool bres = false;

			if (FileIndex < m_filecount)
			{
				m_ftpmonitor.SendCommand(new FTPCommand("RNFR", 0, m_files[FileIndex].fileName ));
				m_ftpmonitor.SendCommand(new FTPCommand("RNTO", 0, NewFileName ));
				bres = true;
			}
			return bres;
		}

		public bool Rename(string FileName, string NewFilename)
		{
			bool bres = false;
			int FileIndex = GetFileIndex(FileName);

			if (FileIndex > -1)
				bres = Rename(FileIndex, NewFilename);

			return bres;		
		}

		public event FTPEventHandler Connected;
		public event FTPEventHandler ConnectionFailure;
		public event FTPEventHandler Logged;
		public event FTPEventHandler LoginFailure;
		public event FTPEventHandler FileDownloadCompleted;
		public event FTPEventHandler FileUploadCompleted;
		public event FTPEventHandler DirCompleted;
		public event FTPEventHandler Error;
		public event FTPEventHandler Message;
		public event FTPEventHandler FTPCommand;
		public event FTPEventHandler Transfered;
		public event FTPEventHandler ConnectionTerminated;

		public virtual void OnTransfered(FTPEventArgs e)
		{
			if (Transfered != null)
			{
				Transfered(this, e);
			}
		}
		public virtual void OnError(FTPEventArgs e)
		{
			if (Error != null)
			{
				Error(this, e);
			}
		}

		public virtual void OnMessage(FTPEventArgs e)
		{
			if (Message != null)
			{
				Message(this, e);
			}
		}

		public virtual void OnFTPCommand(FTPEventArgs e)
		{
			if (FTPCommand != null)
			{
				FTPCommand(this, e);
			}
		}

		public virtual void OnConnected(FTPEventArgs e) 
		{
			if (Connected != null) 
			{
				Connected(this, e); 
			}
		}
		public virtual void OnConnectionFailure(FTPEventArgs e) 
		{
			if (ConnectionFailure != null) 
			{
				ConnectionFailure(this, e); 
			}
		}	
		public virtual void OnLogged(FTPEventArgs e) 
		{
			if (Logged != null) 
			{
				Logged(this, e); 
			}
		}

		public virtual void OnLoginFailure(FTPEventArgs e) 
		{
			if (LoginFailure != null) 
			{
				LoginFailure(this, e); 
			}
		}	
		public virtual void OnFileDownloadCompleted(FTPEventArgs e) 
		{
			if (FileDownloadCompleted != null) 
			{
				FileDownloadCompleted(this, e); 
			}
		}

		public virtual void OnFileUploadCompleted(FTPEventArgs e) 
		{
			if (FileUploadCompleted != null) 
			{
				FileUploadCompleted(this, e); 
			}
		}

		public virtual void OnDirCompleted(FTPEventArgs e) 
		{
			if (DirCompleted != null) 
			{
				ParseUnixDirList(e.Message);

				DirCompleted(this, e); 
			}
		}
		public virtual void OnConnectionterminatedCompleted(FTPEventArgs e) 
		{
			if (ConnectionTerminated != null) 
			{
				ConnectionTerminated(this, e); 
			}
		}

		private ServerFileData ParseDosDirLine(string line)
		{
			ServerFileData sfd = new ServerFileData();

			try 
			{
				string[] parsed = new string[3];
				int index = 0;
				int position = 0;

				// Parse out the elements
				position  = line.IndexOf(' ');
				while (index<parsed.Length) 
				{
					parsed[index] = line.Substring(0, position);
					line = line.Substring(position);
					line = line.Trim();
					index++;
					position  = line.IndexOf(' ');
				}
				sfd.fileName   = line;  
          
				if (parsed[2] != "<DIR>")
					sfd.size       = Convert.ToInt32(parsed[2]);

				sfd.date       = parsed[0]+ ' ' + parsed[1];
				sfd.isDirectory = parsed[2] == "<DIR>";
			}
			catch 
			{
				sfd  = null;
			}
			return sfd;
		}

		private ServerFileData ParseUnixDirLine(string line)
		{
			ServerFileData  sfd = new ServerFileData();

			try 
			{
				string[] parsed = new string [8];
				int index = 0;
				int position;
        
				// Parse out the elements
				position  = line.IndexOf(' ');
				while (index<parsed.Length) 
				{
					parsed[index] = line.Substring(0, position);
					line = line.Substring(position);
					line = line.Trim();
					index++;
					position  = line.IndexOf(' ');
				}
				sfd.fileName   = line;  
          
				sfd.permission = parsed[0];
				sfd.owner      = parsed[2];
				sfd.group      = parsed[3];
				sfd.size       = Convert.ToInt32(parsed[4]);
				sfd.date       = parsed[5]+ ' ' + parsed[6] + ' ' + parsed[7];
				sfd.isDirectory = sfd.permission[0] == 'd';
			}
			catch 
			{
				sfd  = null;
			}
			return sfd;
		}

		private void ParseUnixDirList(string sDir)
		{
			const string      CRLF = "\r\n";

			try
			{
				m_filecount = 0;
				int i = 0;
				sDir = sDir.Replace (CRLF, "\r");
				string[] sFile   = sDir.Split(new Char[]{'\r'});
				ServerFileData  sfd = null;
				int autodetect = 0;

				foreach (string fileLine in sFile)
				{
					if (autodetect == 0)
					{
						sfd = ParseDosDirLine(fileLine);
						if (sfd == null)
						{
							sfd = ParseUnixDirLine(fileLine);
							autodetect = 2;
						}
						else
							autodetect = 1;
					}
					else
						if (autodetect == 1)
							sfd = ParseDosDirLine(fileLine);
					else
						if (autodetect == 2)
							sfd = ParseUnixDirLine(fileLine);

					if (sfd != null)
					{
						m_files[i] = sfd;
						i++;
						m_filecount = i;
					}
				}				
			}
			catch (Exception e)
			{
				
			}
		}

		protected override void Dispose (bool disposing)
		{
			if (disposing)
			{
			}
		}
		~FTPC()
		{
			Dispose();
		}

		public int FileCount
		{
			get
			{
				return m_filecount;
			}
		}

		public string GetFileName(int FileIndex)
		{
			if (FileIndex < m_filecount)
				return m_files[FileIndex].fileName;
			else
				return "";
		}

		public int GetFileSize(int FileIndex)
		{
			if (FileIndex < m_filecount)
				return (int)m_files[FileIndex].size;
			else
				return -1;
		}

		public void Command(string command, int reply)
		{
			m_ftpmonitor.SendCommand(new FTPCommand(command, reply));
		}

		public bool IsFolder(int FileIndex)
		{
			if (FileIndex < m_filecount)
				return m_files[FileIndex].isDirectory;
			else
				return false;
		}

		public bool IsFolder(string FileName)
		{
			bool bres = false;
			int FileIndex = GetFileIndex(FileName);

			if (FileIndex > -1)
				bres = IsFolder(FileIndex);

			return bres;
		}

		public string Type
		{
			get
			{
				return m_type;
			}
			set
			{
				m_type = value;
			}
		}
	}
}
