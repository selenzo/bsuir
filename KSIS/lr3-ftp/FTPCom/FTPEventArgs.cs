namespace FTPCom
{
    /// <summary>
    ///
    /// </summary>
    public class FTPEventArgs : System.EventArgs
    {
        private string m_sMessage;
        private int m_timeelapsed;			// Time elapsed
        private int m_totalbytes;			// Total Bytes
        private string m_function;			// Function name (for debug)

        public FTPEventArgs()
        {
            //
            // TODO: Add constructor logic here
            //
            m_sMessage = string.Empty;
            m_function = string.Empty;
            m_totalbytes = 0;
            m_timeelapsed = 0;
        }

        public FTPEventArgs(bool bResult, string sResult, string sError)
        {
            m_sMessage = sError;
        }

        public string Message
        {
            get
            {
                return m_sMessage;
            }
            set
            {
                m_sMessage = value;
            }
        }

        public int TimeElapsed
        {
            get
            {
                return m_timeelapsed;
            }
            set
            {
                m_timeelapsed = value;
            }
        }

        public int TotalBytes
        {
            get
            {
                return m_totalbytes;
            }
            set
            {
                m_totalbytes = value;
            }
        }

        public string FunctionName
        {
            get
            {
                return m_function;
            }
            set
            {
                m_function = value;
            }
        }
    }
}
