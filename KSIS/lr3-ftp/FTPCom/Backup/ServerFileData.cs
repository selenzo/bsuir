using System;

namespace FTPCom
{
	/// <summary>
	/// 
	/// </summary>
	public class ServerFileData
	{
		public bool    isDirectory;
		public string  fileName;
		public int     size;
		public string  type;
		public string  date;
		public string  permission;
		public string  owner;
		public string  group;

		public ServerFileData()
		{
		}
	}
}
