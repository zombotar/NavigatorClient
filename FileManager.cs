using Client1.NavigatorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfService1;

namespace Client1
{
    public partial class FileManager : Form
    {
        public static int OWNER_MASK = 48;
        public static int GROUP_MASK = 12;
        public static int OTHER_MASK = 3;

        public static int OWNER_READ = 32;
        public static int OWNER_WRITE = 16;
        public static int GROUP_READ = 8;
        public static int GROUP_WRITE = 4;
        public static int OTHER_READ = 2;
        public static int OTHER_WRITE = 1;

        public static int ROOT = OWNER_MASK | GROUP_MASK | OTHER_MASK;
        public static int READ = 32;
        public static int WRITE = 16;
        public static int READ_AND_WRITE = READ | WRITE;

        private int mUserID { get; set; }

        private string[] mGroupNames { get; set; }
        private bool isAdmin { get; set; }
        private Form mParent { get; set; }
        private byte[] mComplexKey { get; set; }
        
        private NavigatorService.BrowserDataResult mCurrDirectoryData { get; set; }
        public FileManager(int _userId, Form _parent, string[] _groupNames) 
        {
            InitializeComponent();
            mUserID = _userId;
            mParent = _parent;
            mGroupNames = _groupNames;
            if (mGroupNames.Contains("admin"))
            {
                /*isAdmin = true;
                addDirButton.Hide();
                addFileButton.Hide();
                Delete.Hide();
                loadButton.Hide();
                keyIndicator.Hide();
                setKeyButton.Hide();*/
            }
            else
            {
                isAdmin = false;
                adminDBControlButton.Hide();
                changeACLButton.Hide();
            }

            var server = new NavigatorService.NavigatorIServiceClient();
            var mainFilesAndDirs = server.GetRootDirForUser(mUserID);
            mCurrDirectoryData = new NavigatorService.BrowserDataResult();

            RefreshListView(mainFilesAndDirs);

            server.Close();

        }

        private void RefreshListView(BrowserDataResult data)
        {
            clearFilesystemObjInfo();
            listView1.Clear();
            if (data != null && data.mResult.mErrCode == 0)
            {
                mCurrDirectoryData = data;
                foreach (var dir in data.mDirectories)
                {
                    string[] dataItem = new string[1];
                    dataItem[0] = dir.mFilepath.Substring(dir.mFilepath.LastIndexOf('\\') + 1);
                    //dataItem[0] = dir.mObjName;
                    ListViewItem item = new ListViewItem(dataItem, 1);
                    item.Tag = dir;
                    listView1.Items.Add(item);
                }

                foreach (var file in data.mFiles)
                {
                    string[] dataItem = new string[1];
                    dataItem[0] = file.mFilepath.Substring(file.mFilepath.LastIndexOf('\\') + 1);
                    ListViewItem item = new ListViewItem(dataItem, 0);
                    item.Tag = file;
                    listView1.Items.Add(item);
                }

                filepathNavBar.Text = data.currPath;
            }
        }

        private void FileManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mParent != null)
            {
                mParent.Show();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                if (item != null)
                {
                    if (item.Tag is FilesystemObject)
                    {
                        var fsObj = (FilesystemObject)item.Tag;
                        if (fsObj.mIsDirFlag)
                        {
                            var server = new NavigatorService.NavigatorIServiceClient();
                            var resp = server.GetListOfData(mUserID, fsObj.mFilepath);
                            if (resp != null && resp.mResult.mErrCode == 0)
                            {
                                RefreshListView(resp);
                            }
                            else if (resp != null)
                            {
                                MessageBox.Show(resp.mResult.mErrMessage);
                            }

                            server.Close();
                        }
                    }
                }
            }
            
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (mCurrDirectoryData.rootPath != mCurrDirectoryData.currPath)
            {
                var server = new NavigatorIServiceClient();
                var resp = server.GetListOfData(mUserID, mCurrDirectoryData.rootPath);
                if (resp != null && resp.mResult.mErrCode == 0)
                {
                    RefreshListView(resp);
                }
                server.Close();
            }
        }

        private void addFileButton_Click(object sender, EventArgs e)
        {
            if (mComplexKey != null)
            {
                string unencryptedFilepath = "";
                var fileDialog = new OpenFileDialog();
                fileDialog.Title = "Выбор файла";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    unencryptedFilepath = fileDialog.FileName;
                    var server = new NavigatorIServiceClient();
                    RemoteFileInfo
                       uploadRequestInfo = new RemoteFileInfo();
                    string encryptedFilename = AppDomain.CurrentDomain.BaseDirectory + "\\" +
                        unencryptedFilepath.Substring(unencryptedFilepath.LastIndexOf('\\') + 1);
                    Crypto.AES_Encrypt(unencryptedFilepath, encryptedFilename, mComplexKey);

                    using (System.IO.FileStream streamEncrypted =
                           new System.IO.FileStream(encryptedFilename,
                           System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        FileInfo fiUnencrypted = new FileInfo(unencryptedFilepath);
                        uploadRequestInfo.mMetaFile = new FilesystemObject();
                        uploadRequestInfo.mMetaFile.mIsDirFlag = false;
                        uploadRequestInfo.mMetaFile.mFilepath = mCurrDirectoryData.currPath + "\\" + fiUnencrypted.Name;
                        uploadRequestInfo.mMetaFile.mFilesize = (int)fiUnencrypted.Length;
                        // Subject control info
                        uploadRequestInfo.mMetaFile.mUid = mUserID;
                        uploadRequestInfo.mMetaFile.mGid = -1;
                        uploadRequestInfo.mMetaFile.mAccessBitset = 
                           OWNER_MASK | GROUP_MASK;

                        uploadRequestInfo.mFileByteStream = streamEncrypted;

                        OperationResult result = new OperationResult();
                        int resultFileId = -1;
                        resultFileId = server.AddFile(uploadRequestInfo.mMetaFile,
                            uploadRequestInfo.mFileByteStream, out result);
                        if (result != null && result.mErrCode == 0)
                        {
                            var resp = server.GetListOfData(mUserID, mCurrDirectoryData.currPath);
                            if (resp != null && resp.mResult.mErrCode == 0)
                            {
                                RefreshListView(resp);
                            }
                            else if (resp != null)
                            {
                                MessageBox.Show(resp.mResult.mErrMessage);
                            }
                        }
                    }

                    FileInfo fi2 = new FileInfo(encryptedFilename);
                    fi2.Delete();
                    server.Close();
                }
            } else // choose key or generate new
            {
                MessageBox.Show("Не выбран ключ шифрования!");
                if (setKey())
                    addFileButton_Click(sender, e);
                else
                    return;
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            var server = new NavigatorIServiceClient();
            var resp = server.GetListOfData(mUserID, mCurrDirectoryData.currPath);
            if (resp != null && resp.mResult.mErrCode == 0)
            {
                RefreshListView(resp);
            }
            server.Close();
        }

        private void addDirButton_Click(object sender, EventArgs e)
        {
            string dirname = "";
            if (DialogWithEdittext.InputBox("Введите название директории", "Имя: ", ref dirname) == DialogResult.OK)
            {
                if (dirname != null && dirname.Equals("") == false)
                {
                    var server = new NavigatorIServiceClient();
                    int dirId = -1;
                    OperationResult result = new OperationResult();
                    //var resp = server.AddDirectory(mCurrDirectoryData.currPath, dirname, mUserID, -1, 63);
                    dirId = server.AddDirectory(OWNER_MASK | GROUP_MASK, mCurrDirectoryData.currPath,
                        -1, mUserID, dirname, null
                        ,out result);
                    if (result != null && result.mErrCode == 0)
                    {
                        refreshButton_Click(sender, e);
                    }
                    else if (result != null)
                    {
                        MessageBox.Show(result.mErrMessage);
                    }

                    server.Close();
                }
                else
                {
                    MessageBox.Show("Недопустимое имя для директории!");
                }
            }
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                if (item != null)
                {
                    FilesystemObject metaObject = (FilesystemObject)item.Tag;
                    if (metaObject != null)
                    {
                        var server = new NavigatorIServiceClient();
                        OperationResult result = new OperationResult();
                        server.DeleteObject(-1, mCurrDirectoryData.currPath, 
                            -1, mUserID, "", metaObject, 
                            out result);
                        if (result != null && result.mErrCode == 0)
                        {
                            refreshButton_Click(sender, e);
                        }
                        else if (result != null)
                        {
                            MessageBox.Show(result.mErrMessage);
                        }

                        server.Close();
                    }

                    
                }
            }
            
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                if (item != null)
                {
                    FilesystemObject metaObject = (FilesystemObject)item.Tag;

                    if (metaObject != null)
                    {
                        var server = new NavigatorIServiceClient();
                        var serverState = server.State;
                        if (metaObject != null)
                        {
                            /*OperationResult result = new OperationResult();
                            var remoteFile = server.DownloadFile(-1, -1, mUserID, "", metaObject, "", out result);*/
                            Stream remoteFile = null;
                            OperationResult result = new OperationResult();
                            int originalFilesize = 0; 
                            var fsMetaObject = server.DownloadFile(metaObject.mFilepath,
                                mUserID, out originalFilesize, 
                                out result, out remoteFile);
                            if (result != null && result.mErrCode == 0)
                            {
                                //refreshButton_Click(sender, e);

                                var saveFileDialog = new SaveFileDialog();
                                saveFileDialog.FileName = metaObject.mFilepath
                                    .Substring(metaObject.mFilepath.LastIndexOf('\\') + 1);
                                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    string filepathDownloaded = saveFileDialog.FileName;
                                    filepathDownloaded = AppDomain.CurrentDomain.BaseDirectory +
                                        "\\" + filepathDownloaded.Substring(filepathDownloaded.LastIndexOf('\\') + 1);
                                    if (filepathDownloaded != null && filepathDownloaded.Equals("") == false)
                                    {
                                        using (FileStream saveDownloadedEncFile =
                                            new FileStream(filepathDownloaded, FileMode.Create, FileAccess.Write))
                                        {
                                            try
                                            {
                                                byte[] buffer = new byte[6500];
                                                int bytesRead = 0;
                                                int totalBytesRead = 0;
                                                do
                                                {
                                                    buffer = new byte[6500];
                                                    bytesRead = remoteFile.Read(buffer, 0, buffer.Length);

                                                    if (bytesRead > 0)
                                                    {
                                                        saveDownloadedEncFile.Write(buffer, 0, bytesRead);
                                                    }
                                                    totalBytesRead += bytesRead;
                                                } while (bytesRead > 0);
                                            }
                                            catch (Exception ex)
                                            {

                                            }
                                        }

                                        if (mComplexKey != null)
                                        {
                                            /*byte[] encryptedBuffer = null;
                                            encryptedBuffer = File.ReadAllBytes(filepathDownloaded);
                                            if ((encryptedBuffer.Length % 16) != 0)
                                            {
                                                byte[] tmpBuf = new byte[encryptedBuffer.Length + (16 - encryptedBuffer.Length % 16)];
                                                Array.Copy(encryptedBuffer, tmpBuf, encryptedBuffer.Length);
                                                encryptedBuffer = tmpBuf;
                                            }
                                            byte[] decryptedBuffer = null;
                                            Crypto.AES_Decrypt(encryptedBuffer, ref decryptedBuffer, mComplexKey);
                                            FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
                                            fs.Write(decryptedBuffer, 0, originalFilesize);
                                            fs.Flush();
                                            fs.Close();*/

                                            Crypto.AES_Decrypt(filepathDownloaded, saveFileDialog.FileName, mComplexKey);
                                        }
                                        else
                                        {
                                            FileInfo fi = new FileInfo(saveFileDialog.FileName);
                                            if (fi.Exists)
                                                fi.Delete();
                                            File.Copy(filepathDownloaded, saveFileDialog.FileName);
                                        }

                                        FileInfo fi2 = new FileInfo(filepathDownloaded);
                                        fi2.Delete();

                                        MessageBox.Show("Ok!");
                                    }
                                }

                            }
                            else if (result != null)
                            {
                                MessageBox.Show(result.mErrMessage);
                            }
                        }


                        server.Close();                       
                    }

                    
                }
            }
            
        }

        private bool setKey()
        {
            var keyFileDialog = new OpenFileDialog();
            keyFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            keyFileDialog.Title = "Выбор ключа шифрования";
            if (keyFileDialog.ShowDialog() == DialogResult.OK)
            {
                var complexKeyFilepath = keyFileDialog.FileName;
                byte[] complexKeyBytes = new byte[(Crypto.KEY_SIZE / 8) + (Crypto.BLOCK_SIZE / 8)];
                FileStream fsKey = new FileStream(complexKeyFilepath, FileMode.Open);
                if ((int)fsKey.Length != complexKeyBytes.Length)
                {
                    MessageBox.Show("Выбран неверный ключ!");
                    return false;
                }
                fsKey.Read(complexKeyBytes, 0, (Crypto.KEY_SIZE / 8) + (Crypto.BLOCK_SIZE / 8));
                fsKey.Close();
                mComplexKey = complexKeyBytes;
                FileInfo file = new FileInfo(keyFileDialog.FileName);
                keyIndicator.Text = file.Name;
                return true;
            }
            return false;
        }

        private void setKeyButton_Click(object sender, EventArgs e)
        {
            setKey();
        }

        private void adminDBControlButton_Click(object sender, EventArgs e)
        {
            AdminDBControl otherForm = new AdminDBControl(mUserID, this);
            //otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherForm.Show();
        }

        private void FileManager_Load(object sender, EventArgs e)
        {
            /*var server = new ServiceReference1.Service1Client();
            var mainFilesAndDirs = server.AfterAuth(mUserID);
            mCurrDirectoryData = new ServiceReference1.BrowserDataInfo();

            RefreshListView(mainFilesAndDirs);

            server.Close();*/

            refreshButton_Click(sender, e);
        }

        private void changeACLButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                if (item != null)
                {
                    FilesystemObject metaObject = (FilesystemObject)(item.Tag);

                    if (metaObject != null)
                    {
                        ACL_Control control = new ACL_Control(this, metaObject, mUserID);
                        if (control.ShowDialog() == DialogResult.OK)
                        {
                            refreshButton_Click(sender, e);
                        }
                    }
                }
            }
            
        }

        private void clearFilesystemObjInfo()
        {
            fileInfoClassLabel.Text = "";
            sizeLabel.Text = "";
        }

        private void setFilesystemObjInfo(string filesize, string classKind)
        {
            fileInfoClassLabel.Text = classKind;
            sizeLabel.Text = filesize;
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            
        }

        private void manFileInfo()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                if (item != null)
                {
                    FilesystemObject metaObject = (FilesystemObject)(item.Tag);

                    if (metaObject != null)
                    {
                        setFilesystemObjInfo
                            (metaObject.mIsDirFlag ? "" : metaObject.mFilesize.ToString() + " bytes",
                              metaObject.mIsDirFlag ? "Directory" : "File"
                            );

                    }
                }
            }
            else
            {
                clearFilesystemObjInfo();
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            manFileInfo();
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            manFileInfo();
        }
    }
}
