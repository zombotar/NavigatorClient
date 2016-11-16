using Client1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client1
{
    public partial class FileManager : Form
    {
        private int mUserID { get; set; }
        private Form mParent { get; set; }

        private ServiceReference1.BrowserDataInfo mCurrDirectoryData { get; set; }
        public FileManager(int _userId, Form _parent)
        {
            InitializeComponent();
            mUserID = _userId;
            mParent = _parent;

            var server = new ServiceReference1.Service1Client();
            var mainFilesAndDirs = server.AfterAuth(mUserID);
            mCurrDirectoryData = new ServiceReference1.BrowserDataInfo();

            /*listView1.Clear();
            if (mainFilesAndDirs != null && mainFilesAndDirs.mErrCode == 0)
            {
                mCurrDirectoryData = mainFilesAndDirs;
                foreach (var dir in mainFilesAndDirs.mDirectories)
                {
                    string[] dataItem = new string[1];
                    dataItem[0] = dir.mDirectoryInfo.Name;
                    ListViewItem item = new ListViewItem(dataItem, 1);
                    item.Tag = dir;
                    listView1.Items.Add(item);
                }

                foreach (var file in mainFilesAndDirs.mFiles)
                {
                    string[] dataItem = new string[1];
                    dataItem[0] = file.mFileInfo.Name;
                    ListViewItem item = new ListViewItem(dataItem, 0);
                    item.Tag = file;
                    listView1.Items.Add(item);
                }
            }*/

            RefreshListView(mainFilesAndDirs);

        }

        private void RefreshListView(BrowserDataInfo _data)
        {
            listView1.Clear();
            if (_data != null && _data.mErrCode == 0)
            {
                mCurrDirectoryData = _data;
                foreach (var dir in _data.mDirectories)
                {
                    string[] dataItem = new string[1];
                    dataItem[0] = dir.mDirectoryInfo.Name;
                    ListViewItem item = new ListViewItem(dataItem, 1);
                    item.Tag = dir;
                    listView1.Items.Add(item);
                }

                foreach (var file in _data.mFiles)
                {
                    string[] dataItem = new string[1];
                    dataItem[0] = file.mFileInfo.Name;
                    ListViewItem item = new ListViewItem(dataItem, 0);
                    item.Tag = file;
                    listView1.Items.Add(item);
                }
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
            ListViewItem item = listView1.SelectedItems[0];
            if (item != null)
            {
                if (item.Tag is MyFileInfo)
                {

                } else if (item.Tag is MyDirectoryInfo)
                {
                    var innerDir = (MyDirectoryInfo)item.Tag;
                    var server = new ServiceReference1.Service1Client();
                    var resp = server.GetListOfData(mUserID, innerDir.mMetaObject.filePath);
                    if (resp != null && resp.mErrCode == 0)
                    {
                        RefreshListView(resp);
                    }
                }
            }
        }
    }
}
