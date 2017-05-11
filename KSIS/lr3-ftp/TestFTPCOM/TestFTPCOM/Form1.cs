using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TestFTPCOM
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class SharpFTP : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter SplitView;
        private System.Windows.Forms.ListView LocalView;
        private System.Windows.Forms.ListView ServerView;
        private System.Windows.Forms.RichTextBox TextLog;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader schName;
        private System.Windows.Forms.ColumnHeader schSize;
        private System.Windows.Forms.ColumnHeader schType;
        private System.Windows.Forms.ImageList ImgListViewLarge;
        private System.Windows.Forms.ImageList ImgListViewSmall;
        private System.ComponentModel.IContainer components;

        private Shell32.Shell m_Shell;
        private System.Windows.Forms.ComboBox CBFTPServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EFUsername;
        private System.Windows.Forms.Label Text1;
        private System.Windows.Forms.TextBox EFPassword;
        private System.Windows.Forms.Button BTConnect;
        private System.Windows.Forms.ImageList ImgListServerSmall;
        private Shell32.Folder m_RootShell;
        private Shell32.Folder m_currentFolder;
        private Icon m_IconFolder;

        private string m_previousfilename;
        private System.Windows.Forms.ContextMenu contextMenuServer;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem MenuDelete;
        private System.Windows.Forms.MenuItem MenuDownload;
        private System.Windows.Forms.MenuItem MnuServerNewFolder;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem MnuServerProperties;
        private System.Windows.Forms.MenuItem MnuServerRename;
        private System.Windows.Forms.Button BtnClose;
        private FTPCom.FTPC ftpc;
        private const string CRLF = "\r\n";

        public SharpFTP()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            SplitView.SplitPosition = this.Width / 2;

            m_Shell = new Shell32.ShellClass();
            m_RootShell = m_Shell.NameSpace(Shell32.ShellSpecialFolderConstants.ssfDRIVES);

            InitializeIconFolder();
            FillLocalView(m_RootShell);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.TextLog = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.LocalView = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImgListViewLarge = new System.Windows.Forms.ImageList(this.components);
            this.ImgListViewSmall = new System.Windows.Forms.ImageList(this.components);
            this.SplitView = new System.Windows.Forms.Splitter();
            this.ServerView = new System.Windows.Forms.ListView();
            this.schName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuServer = new System.Windows.Forms.ContextMenu();
            this.MnuServerNewFolder = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.MenuDownload = new System.Windows.Forms.MenuItem();
            this.MnuServerRename = new System.Windows.Forms.MenuItem();
            this.MenuDelete = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.MnuServerProperties = new System.Windows.Forms.MenuItem();
            this.ImgListServerSmall = new System.Windows.Forms.ImageList(this.components);
            this.CBFTPServer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EFUsername = new System.Windows.Forms.TextBox();
            this.Text1 = new System.Windows.Forms.Label();
            this.EFPassword = new System.Windows.Forms.TextBox();
            this.BTConnect = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.ftpc = new FTPCom.FTPC();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(768, 42);
            this.toolBar1.TabIndex = 1;
            // 
            // TextLog
            // 
            this.TextLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextLog.Location = new System.Drawing.Point(0, 351);
            this.TextLog.Name = "TextLog";
            this.TextLog.ReadOnly = true;
            this.TextLog.Size = new System.Drawing.Size(768, 150);
            this.TextLog.TabIndex = 2;
            this.TextLog.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 348);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(768, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // LocalView
            // 
            this.LocalView.AllowDrop = true;
            this.LocalView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chSize,
            this.chType});
            this.LocalView.Dock = System.Windows.Forms.DockStyle.Left;
            this.LocalView.LabelEdit = true;
            this.LocalView.LargeImageList = this.ImgListViewLarge;
            this.LocalView.Location = new System.Drawing.Point(0, 42);
            this.LocalView.Name = "LocalView";
            this.LocalView.Size = new System.Drawing.Size(373, 306);
            this.LocalView.SmallImageList = this.ImgListViewSmall;
            this.LocalView.TabIndex = 4;
            this.LocalView.UseCompatibleStateImageBehavior = false;
            this.LocalView.View = System.Windows.Forms.View.Details;
            this.LocalView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LocalView_ColumnClick);
            this.LocalView.ItemActivate += new System.EventHandler(this.LocalView_ItemActivate);
            this.LocalView.DragDrop += new System.Windows.Forms.DragEventHandler(this.LocalView_DragDrop);
            this.LocalView.DragEnter += new System.Windows.Forms.DragEventHandler(this.LocalView_DragEnter);
            this.LocalView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LocalView_MouseMove);
            // 
            // chName
            // 
            this.chName.Text = "Имя";
            this.chName.Width = 120;
            // 
            // chSize
            // 
            this.chSize.Text = "Размер";
            // 
            // chType
            // 
            this.chType.Text = "Тип";
            // 
            // ImgListViewLarge
            // 
            this.ImgListViewLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImgListViewLarge.ImageSize = new System.Drawing.Size(16, 16);
            this.ImgListViewLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ImgListViewSmall
            // 
            this.ImgListViewSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImgListViewSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.ImgListViewSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // SplitView
            // 
            this.SplitView.Location = new System.Drawing.Point(373, 42);
            this.SplitView.Name = "SplitView";
            this.SplitView.Size = new System.Drawing.Size(3, 306);
            this.SplitView.TabIndex = 5;
            this.SplitView.TabStop = false;
            // 
            // ServerView
            // 
            this.ServerView.AllowDrop = true;
            this.ServerView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.schName,
            this.schSize,
            this.schType});
            this.ServerView.ContextMenu = this.contextMenuServer;
            this.ServerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerView.LabelEdit = true;
            this.ServerView.Location = new System.Drawing.Point(376, 42);
            this.ServerView.Name = "ServerView";
            this.ServerView.Size = new System.Drawing.Size(392, 306);
            this.ServerView.SmallImageList = this.ImgListServerSmall;
            this.ServerView.TabIndex = 6;
            this.ServerView.UseCompatibleStateImageBehavior = false;
            this.ServerView.View = System.Windows.Forms.View.Details;
            this.ServerView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.ServerView_AfterLabelEdit);
            this.ServerView.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.ServerView_BeforeLabelEdit);
            this.ServerView.ItemActivate += new System.EventHandler(this.ServerView_ItemActivate);
            this.ServerView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ServerView_DragDrop);
            this.ServerView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ServerView_DragEnter);
            this.ServerView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ServerView_MouseDown);
            this.ServerView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ServerView_MouseMove);
            // 
            // schName
            // 
            this.schName.Text = "Имя";
            this.schName.Width = 120;
            // 
            // schSize
            // 
            this.schSize.Text = "Размер";
            // 
            // schType
            // 
            this.schType.Text = "Тип";
            // 
            // contextMenuServer
            // 
            this.contextMenuServer.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MnuServerNewFolder,
            this.menuItem7,
            this.MenuDownload,
            this.MnuServerRename,
            this.MenuDelete,
            this.menuItem8,
            this.MnuServerProperties});
            // 
            // MnuServerNewFolder
            // 
            this.MnuServerNewFolder.Index = 0;
            this.MnuServerNewFolder.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.MnuServerNewFolder.Text = "New Folder";
            this.MnuServerNewFolder.Click += new System.EventHandler(this.MnuServerNewFolder_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "-";
            // 
            // MenuDownload
            // 
            this.MenuDownload.Index = 2;
            this.MenuDownload.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.MenuDownload.Text = "Download";
            this.MenuDownload.Click += new System.EventHandler(this.MenuDownload_Click);
            // 
            // MnuServerRename
            // 
            this.MnuServerRename.Index = 3;
            this.MnuServerRename.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.MnuServerRename.Text = "Rename";
            this.MnuServerRename.Click += new System.EventHandler(this.MnuServerRename_Click);
            // 
            // MenuDelete
            // 
            this.MenuDelete.Index = 4;
            this.MenuDelete.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.MenuDelete.Text = "Delete";
            this.MenuDelete.Click += new System.EventHandler(this.MenuDelete_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 5;
            this.menuItem8.Text = "-";
            // 
            // MnuServerProperties
            // 
            this.MnuServerProperties.Index = 6;
            this.MnuServerProperties.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.MnuServerProperties.Text = "Properties";
            // 
            // ImgListServerSmall
            // 
            this.ImgListServerSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImgListServerSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.ImgListServerSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // CBFTPServer
            // 
            this.CBFTPServer.Items.AddRange(new object[] {
            "localhost"});
            this.CBFTPServer.Location = new System.Drawing.Point(56, 8);
            this.CBFTPServer.Name = "CBFTPServer";
            this.CBFTPServer.Size = new System.Drawing.Size(136, 21);
            this.CBFTPServer.TabIndex = 7;
            this.CBFTPServer.Text = "192.168.1.187";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Сервер:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(198, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Логин:";
            // 
            // EFUsername
            // 
            this.EFUsername.Location = new System.Drawing.Point(242, 9);
            this.EFUsername.Name = "EFUsername";
            this.EFUsername.Size = new System.Drawing.Size(80, 20);
            this.EFUsername.TabIndex = 10;
            this.EFUsername.Text = "softinstall";
            // 
            // Text1
            // 
            this.Text1.Location = new System.Drawing.Point(354, 11);
            this.Text1.Name = "Text1";
            this.Text1.Size = new System.Drawing.Size(56, 16);
            this.Text1.TabIndex = 11;
            this.Text1.Text = "Пароль:";
            // 
            // EFPassword
            // 
            this.EFPassword.Location = new System.Drawing.Point(406, 8);
            this.EFPassword.Name = "EFPassword";
            this.EFPassword.Size = new System.Drawing.Size(104, 20);
            this.EFPassword.TabIndex = 12;
            this.EFPassword.Text = "rexrf";
            // 
            // BTConnect
            // 
            this.BTConnect.Location = new System.Drawing.Point(526, 6);
            this.BTConnect.Name = "BTConnect";
            this.BTConnect.Size = new System.Drawing.Size(93, 24);
            this.BTConnect.TabIndex = 13;
            this.BTConnect.Text = "Подключиться";
            this.BTConnect.Click += new System.EventHandler(this.BTConnect_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Enabled = false;
            this.BtnClose.Location = new System.Drawing.Point(625, 6);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(92, 24);
            this.BtnClose.TabIndex = 14;
            this.BtnClose.Text = "Отключиться";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ftpc
            // 
            this.ftpc.Hostname = "";
            this.ftpc.LocalFolder = "c:\\temp";
            this.ftpc.Password = "";
            this.ftpc.Port = 21;
            this.ftpc.RemoteFolder = "";
            this.ftpc.Type = "A";
            this.ftpc.Username = "";
            this.ftpc.Connected += new FTPCom.FTPEventHandler(this.ftpc_Connected);
            this.ftpc.Logged += new FTPCom.FTPEventHandler(this.ftpc_Logged);
            this.ftpc.FileDownloadCompleted += new FTPCom.FTPEventHandler(this.ftpc_FileDownloadCompleted);
            this.ftpc.FileUploadCompleted += new FTPCom.FTPEventHandler(this.ftpc_FileUploadCompleted);
            this.ftpc.DirCompleted += new FTPCom.FTPEventHandler(this.ftpc_DirCompleted);
            this.ftpc.Error += new FTPCom.FTPEventHandler(this.ftpc_Error);
            this.ftpc.Message += new FTPCom.FTPEventHandler(this.ftpc_Message);
            this.ftpc.FTPCommand += new FTPCom.FTPEventHandler(this.ftpc_FTPCommand);
            this.ftpc.ConnectionTerminated += new FTPCom.FTPEventHandler(this.ftpc_ConnectionTerminated);
            // 
            // SharpFTP
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(768, 501);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BTConnect);
            this.Controls.Add(this.EFPassword);
            this.Controls.Add(this.Text1);
            this.Controls.Add(this.EFUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBFTPServer);
            this.Controls.Add(this.ServerView);
            this.Controls.Add(this.SplitView);
            this.Controls.Add(this.LocalView);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.TextLog);
            this.Controls.Add(this.toolBar1);
            this.Name = "SharpFTP";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion Windows Form Designer generated code

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.Run(new SharpFTP());
        }

        private void FillLocalView(Shell32.Folder folder)
        {
            this.Cursor = Cursors.WaitCursor;

            m_currentFolder = folder;

            // Notify that update begins
            LocalView.BeginUpdate();

            // Erase last view items
            LocalView.Items.Clear();

            // Erase previous lists image
            ImgListViewSmall.Images.Clear();
            ImgListViewLarge.Images.Clear();

            int idImage = 0;

            ListViewItem lvItem = new ListViewItem("..");
            lvItem.Tag = folder;

            LocalView.Items.Add(lvItem);

            Shell32.FolderItems items = folder.Items();

            // Folder enumeration
            foreach (Shell32.FolderItem item in items)
            {
                if (item.IsFolder)
                {
                    AddViewItem(item, ref idImage);
                }
            }

            // Other files
            foreach (Shell32.FolderItem item in items)
            {
                if (!item.IsFolder)
                {
                    AddViewItem(item, ref idImage);
                }
            }

            // End update view
            LocalView.EndUpdate();

            //ftpc.LocalFolder = folder.Title;

            this.Cursor = Cursors.Default;
        }

        private void AddViewItem(Shell32.FolderItem item, ref int idImage)
        {
            string[] sValues = new string[10];

            sValues[0] = item.Name;
            if (item.Size == 0)
                sValues[1] = "";
            else
                sValues[1] = Convert.ToString(item.Size / 1024) + " KB";
            sValues[2] = item.Type;
            sValues[3] = item.ModifyDate.ToString();
            /*
            sValues[4] = item.Path;
            sValues[5] = item.IsBrowsable.ToString();
            sValues[6] = item.IsFileSystem.ToString();
            sValues[7] = item.IsFolder.ToString();
            sValues[8] = item.IsLink.ToString();
            */
            ImgListViewSmall.Images.Add(ExtractIcon.GetIcon(item.Path, true));

            ListViewItem lvItem = new ListViewItem(sValues, idImage++);
            lvItem.Tag = item;
            LocalView.Items.Add(lvItem);
        }

        private void LocalView_ItemActivate(object sender, System.EventArgs e)
        {
            if (LocalView.SelectedItems[0].Text == "..")
            {
                Shell32.Folder item;

                item = (Shell32.Folder)LocalView.SelectedItems[0].Tag;
                FillLocalView((Shell32.Folder)item.ParentFolder);
            }
            else
            {
                Shell32.FolderItem item;

                item = (Shell32.FolderItem)LocalView.SelectedItems[0].Tag;
                if (item.IsFolder)
                {
                    ftpc.LocalFolder = item.Path;
                    FillLocalView((Shell32.Folder)item.GetFolder);
                }
            }
        }

        private void LocalView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
        }

        private void BTConnect_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            ftpc.Username = EFUsername.Text;
            ftpc.Password = EFPassword.Text;

            ftpc.Hostname = CBFTPServer.Text;
            if (ftpc.Connect())
            {
                BtnClose.Enabled = true;
                BTConnect.Enabled = false;
            }
        }

        private void ftpc_Message(object sender, FTPCom.FTPEventArgs e)
        {
            TextLog.SelectionColor = Color.Green;
            if (e.Message != string.Empty)
                TextLog.AppendText(e.Message);
            TextLog.AppendText(Environment.NewLine);
        }

        private void ftpc_Connected(object sender, FTPCom.FTPEventArgs e)
        {
            ftpc.Login();
        }

        private void ftpc_Error(object sender, FTPCom.FTPEventArgs e)
        {
            TextLog.SelectionColor = Color.Red;
            TextLog.AppendText(e.FunctionName);
            TextLog.AppendText("-");
            if (e.Message != string.Empty)
                TextLog.AppendText(e.Message);
        }

        private void ftpc_Logged(object sender, FTPCom.FTPEventArgs e)
        {
            ftpc.Dir();
        }

        private void InitializeIconFolder()
        {
            Shell32.Folder FolderShell = m_Shell.NameSpace(Shell32.ShellSpecialFolderConstants.ssfWINDOWS);
            Shell32.FolderItems items = FolderShell.Items();

            foreach (Shell32.FolderItem item in items)
                if (item.IsFolder)
                {
                    m_IconFolder = ExtractIcon.GetIcon(item.Path, true);
                    break;
                }
        }

        private void ftpc_DirCompleted(object sender, FTPCom.FTPEventArgs e)
        {
            int i = 0;
            int idimage = 0;
            string msg;

            msg = "Transfered " + e.TotalBytes.ToString() + " bytes in " + ((float)e.TimeElapsed / 1000).ToString() + " seconds" + CRLF;
            TextLog.SelectionColor = Color.Black;
            TextLog.AppendText(msg);

            ServerView.BeginUpdate();
            ServerView.Items.Clear();
            ImgListServerSmall.Images.Clear();

            ListViewItem lvItem = new ListViewItem("..");
            ServerView.Items.Add(lvItem);

            for (i = 0; i < ftpc.FileCount; i++)
            {
                if (ftpc.IsFolder(i))
                {
                    string[] items = new String[2];
                    items[0] = ftpc.GetFileName(i);
                    items[1] = ftpc.GetFileSize(i).ToString();
                    ImgListServerSmall.Images.Add(m_IconFolder);
                    ServerView.Items.Add(new ListViewItem(items, idimage++));
                }
            }
            for (i = 0; i < ftpc.FileCount; i++)
            {
                if (!ftpc.IsFolder(i))
                {
                    string[] items = new String[2];
                    items[0] = ftpc.GetFileName(i);
                    items[1] = ftpc.GetFileSize(i).ToString();
                    ImgListServerSmall.Images.Add(ExtractIcon.GetIcon(items[0], false));
                    ServerView.Items.Add(new ListViewItem(items, idimage++));
                }
            }
            ServerView.EndUpdate();
            this.Cursor = Cursors.Default;
        }

        private void ServerView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        private void LocalView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void LocalView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string msg = e.Data.GetData(DataFormats.Text).ToString();

            //MessageBox.Show (msg);

            string[] filename = msg.Split(new char[] { '\n' });
            foreach (string sfile in filename)
            {
                ftpc.FileDownload(sfile);
            }
        }

        private void ftpc_FileDownloadCompleted(object sender, FTPCom.FTPEventArgs e)
        {
            string msg = "Transfered " + e.TotalBytes.ToString() + " bytes in " + ((float)e.TimeElapsed / 1000).ToString() + " seconds" + CRLF;
            TextLog.SelectionColor = Color.Black;
            TextLog.AppendText(msg);
            FillLocalView(m_currentFolder);
        }

        private void ServerView_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != 0)
            {
                string msg = "";

                for (int i = 0; i < ServerView.SelectedItems.Count; i++)
                {
                    msg += ServerView.SelectedItems[i].Text + "\n";
                }

                ServerView.DoDragDrop(msg, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void ServerView_ItemActivate(object sender, System.EventArgs e)
        {
            if (ServerView.SelectedItems[0].Text == "..")
            {
                this.Cursor = Cursors.WaitCursor;
                ftpc.DirUp();
                ftpc.Dir();
            }
            else
            {
                string dirname = ServerView.SelectedItems[0].Text;
                if (ftpc.IsFolder(dirname))
                {
                    this.Cursor = Cursors.WaitCursor;

                    ftpc.DirChange(dirname);
                    ftpc.Dir();
                }
            }
        }

        private void ServerView_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                this.Cursor = Cursors.WaitCursor;

                string newfilename = e.Label;
                if (m_previousfilename == "New Folder")
                {
                    ftpc.DirCreate(newfilename);
                }
                else
                {
                    ftpc.Rename(m_previousfilename, newfilename);
                }
                ftpc.Dir();
            }
        }

        private void ServerView_BeforeLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
        {
            m_previousfilename = ServerView.Items[e.Item].Text;
        }

        private void LocalView_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != 0)
            {
                string msg = "";

                for (int i = 0; i < LocalView.SelectedItems.Count; i++)
                {
                    msg += LocalView.SelectedItems[i].Text + "\n";
                }

                LocalView.DoDragDrop(msg, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void ServerView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ServerView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            foreach (ListViewItem lvi in LocalView.SelectedItems)
            {
                ftpc.FileUpload(lvi.Text, GetFileSize(lvi.Text));
            }
        }

        private int GetFileSize(string filename)
        {
            FileInfo fi = new FileInfo(ftpc.LocalFolder + (ftpc.LocalFolder.EndsWith("/") ? "" : "/") + filename);
            return ((int)fi.Length);
        }

        private void ftpc_FileUploadCompleted(object sender, FTPCom.FTPEventArgs e)
        {
            string msg = "Transfered " + e.TotalBytes.ToString() + " bytes in " + ((float)e.TimeElapsed / 1000).ToString() + " seconds" + CRLF;
            TextLog.SelectionColor = Color.Black;
            TextLog.AppendText(msg);
            ftpc.Dir();
        }

        private void MenuDelete_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ServerView.SelectedItems.Count; i++)
            {
                ftpc.Delete(ServerView.SelectedItems[i].Text);
            }
            ftpc.Dir();
        }

        private void MenuDownload_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ServerView.SelectedItems.Count; i++)
            {
                ftpc.FileDownload(ServerView.SelectedItems[i].Text);
            }
        }

        private void MnuServerNewFolder_Click(object sender, System.EventArgs e)
        {
            ImgListServerSmall.Images.Add(m_IconFolder);
            ServerView.Items.Add(new ListViewItem("New Folder", ImgListServerSmall.Images.Count - 1));
            ServerView.Items[ServerView.Items.Count - 1].BeginEdit();
        }

        private void MnuServerRename_Click(object sender, System.EventArgs e)
        {
            ServerView.SelectedItems[0].BeginEdit();
        }

        private void ftpc_FTPCommand(object sender, FTPCom.FTPEventArgs e)
        {
            TextLog.SelectionColor = Color.Blue;
            if (e.Message != string.Empty)
                TextLog.AppendText(e.Message);
            TextLog.AppendText("\n");
            TextLog.SelectionStart = TextLog.TextLength;
            TextLog.ScrollToCaret();
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            ftpc.Disconnect();
            ServerView.Items.Clear();
            BTConnect.Enabled = true;
            BtnClose.Enabled = false;
        }

        public void ftpc_ConnectionTerminated(object sender, FTPCom.FTPEventArgs e)
        {
        }
    }
}