using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;


namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(textBox3.Text);
            wr.Method = "GET";

            string htmlPage = string.Empty;
            try
            {
                using (HttpWebResponse WebResp = (HttpWebResponse)wr.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(WebResp.GetResponseStream(), Encoding.UTF8))
                    {
                        htmlPage = sr.ReadToEnd();
                    }
                }
                webBrowser1.DocumentText = htmlPage;
                textBox1.Text = htmlPage;
            }
            catch (Exception ex)
            {
                webBrowser1.DocumentText = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://localhost");
            wr.Method = "HEAD";

            string htmlPage = string.Empty;
            using (HttpWebResponse WebResp = (HttpWebResponse)wr.GetResponse())
            {
                foreach (var header in WebResp.Headers)
                {
                    var i = WebResp.Headers.GetValues((string) header);
                    htmlPage += header + ":" + i[0] + "\r\n";
                }
            }
            textBox1.Text = htmlPage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/auth.php");
            request.Method = "POST";
            request.AllowAutoRedirect = true;
            request.CookieContainer = new CookieContainer();
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] EncodedPostParams = Encoding.UTF8.GetBytes("login="+login.Text.Trim()+"&password="+pass.Text.Trim());
            request.ContentLength = EncodedPostParams.Length;
            request.GetRequestStream().Write(EncodedPostParams,0,EncodedPostParams.Length);
            request.GetRequestStream().Close();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    webBrowser1.DocumentText = sr.ReadToEnd();
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
