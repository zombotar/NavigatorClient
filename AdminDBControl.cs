using Client1.NavigatorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace Client1
{
    public partial class AdminDBControl : Form
    {
        private int mUserID { get; set; }
        private Form mParent { get; set; }

        private List<User> mCurrUsers { get; set; }

        private List<Group> mCurrGroups { get; set; }

        private void InitUserListView()
        {
            //init ListView control
            userTreeView.Nodes.Clear();
            userTreeView.HideSelection = false;
                                          //create column header for ListView
            /*usersListView.FullRowSelect = true;
            usersListView.Columns.Add("id", 50, System.Windows.Forms.HorizontalAlignment.Left);
            usersListView.Columns.Add("name", 100, System.Windows.Forms.HorizontalAlignment.Left);*/

        }

        private void InitGroupListView()
        {
            groupsListView.Clear();
            groupsListView.FullRowSelect = true;
            groupsListView.View = View.List;
            groupsListView.HideSelection = false;
        }

        private void RefreshUserListView(GetUsersResult _data)
        {
            InitUserListView();
            if (_data != null && _data.mResult.mErrCode == 0)
            {
                mCurrUsers = _data.mUsers.ToList();
                foreach (var user in mCurrUsers)
                {
                    string[] dataItem = new string[2];
                    dataItem[0] = user.mId.ToString();
                    dataItem[1] = user.mName;
                    TreeNode item = new TreeNode("Id = " + dataItem[0] + 
                        "  |    |  " + dataItem[1]);
                    item.Tag = user;

                    foreach (var group in user.Groups)
                    {
                        TreeNode subNode = new TreeNode(group.mName);
                        subNode.Tag = group;
                        item.Nodes.Add(subNode);
                    }

                    userTreeView.Nodes.Add(item);
                }
            }
        }

        private void RefreshGroupListView(GetGroupsResult _data)
        {
            InitGroupListView();
            if (_data != null && _data.mResult.mErrCode == 0)
            {
                mCurrGroups = _data.mGroups.ToList();
                foreach (var group in mCurrGroups)
                {
                    string[] dataItem = new string[2];
                    dataItem[0] = group.mId.ToString();
                    dataItem[1] = group.mName;
                    ListViewItem item = new ListViewItem("Id = " + dataItem[0] +
                        "  |    |  " + dataItem[1]);
                    item.Tag = group;

                    groupsListView.Items.Add(item);
                }
            }
        }

        public AdminDBControl(int _userId, Form _parent)
        {
            InitializeComponent();

            mUserID = _userId;
            mParent = _parent;

            var server = new NavigatorIServiceClient();
            var resp = server.GetUsers(mUserID);
            RefreshUserListView(resp);
            var resp2 = server.GetGroups(mUserID);
            RefreshGroupListView(resp2);
            server.Close();
        }

        private void AdminDBControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mParent != null)
            {
                mParent.Show();
            }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            AddUserDialog dialog = new AddUserDialog();
            string newUsername = "";
            string newPasswordHash = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                newUsername = dialog.username;
                newPasswordHash = dialog.password_hash;

                var server = new NavigatorIServiceClient();

                var resp1 = server.AddUser(mUserID, newUsername, newPasswordHash);
                if (resp1 != null && resp1.mErrCode == 0)
                {
                    var resp = server.GetUsers(mUserID);
                    RefreshUserListView(resp);
                    server.Close();
                }
                else if (resp1 != null)
                {
                    MessageBox.Show(resp1.mErrMessage);
                }
                
            }
        }

        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            var item = userTreeView.SelectedNode;
            if (item != null)
            {
                if (item.Tag is User)
                {
                    var user = (User)item.Tag;
                    var server = new NavigatorIServiceClient();
                    var resp = server.DeleteUser(mUserID, user.mId);
                    if (resp != null && resp.mErrCode == 0)
                    {
                        var resp2 = server.GetUsers(mUserID);
                        RefreshUserListView(resp2);
                    }
                    else if(resp != null)
                    {
                        MessageBox.Show(resp.mErrMessage);
                    }

                    server.Close();
                }
            }
        }

        private void addGroupButton_Click(object sender, EventArgs e)
        {
            string newGroupname = "";
            if (DialogWithEdittext.InputBox("Добавление группы", "Имя группы", ref newGroupname) == DialogResult.OK)
            {

                var server = new NavigatorIServiceClient();

                var resp1 = server.AddGroup(mUserID, newGroupname);
                if (resp1 != null && resp1.mErrCode == 0)
                {
                    var resp = server.GetGroups(mUserID);
                    RefreshGroupListView(resp);
                    server.Close();
                }
                else if (resp1 != null)
                {
                    MessageBox.Show(resp1.mErrMessage);
                }

            }
        }

        private void deleteGroupButton_Click(object sender, EventArgs e)
        {
            if (groupsListView.SelectedItems.Count > 0)
            {
                var item = groupsListView.SelectedItems[0];
                if (item != null)
                {
                    if (item.Tag is Group)
                    {
                        var group = (Group)item.Tag;
                        var server = new NavigatorIServiceClient();
                        var resp = server.DeleteGroup(mUserID, group.mId);
                        if (resp != null && resp.mErrCode == 0)
                        {
                            var resp2 = server.GetGroups(mUserID);
                            RefreshGroupListView(resp2);

                            var resp3 = server.GetUsers(mUserID);
                            RefreshUserListView(resp3);
                        }
                        else if (resp != null)
                        {
                            MessageBox.Show(resp.mErrMessage);
                        }

                        server.Close();
                    }
                }
            }
        }

        private void addToGroupUser_Click(object sender, EventArgs e)
        {
            var itemUser = userTreeView.SelectedNode;
            if (itemUser != null)
            {
                if (itemUser.Tag is User)
                {
                    var user = (User)itemUser.Tag;

                    var itemGroup = groupsListView.SelectedItems[0];
                    if (itemGroup != null)
                    {
                        if (itemGroup.Tag is Group)
                        {
                            var group = (Group)itemGroup.Tag;

                            var server = new NavigatorIServiceClient();
                            var resp = server.AddUserToGroup(mUserID, user.mId, group.mId);
                            if (resp != null && resp.mErrCode == 0)
                            {
                                var resp2 = server.GetUsers(mUserID);
                                RefreshUserListView(resp2);
                                /*var resp3 = server.GetGroups(mUserID);
                                RefreshGroupListView(resp3);*/
                            }
                            else 
                            {
                                MessageBox.Show(resp.mErrMessage);
                            }

                            server.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не выбрана группа!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не выбран пользователь!");
                }
            }
        }

        private void deleteFromGroup_Click(object sender, EventArgs e)
        {
            var itemGroup= userTreeView.SelectedNode;
            if (itemGroup != null)
            {
                if (itemGroup.Tag is Group)
                {
                    var group = (Group)itemGroup.Tag;
                    var itemUser = itemGroup.Parent;
                    if (itemUser != null)
                    {
                        if (itemUser.Tag is User)
                        {
                            var user = (User)itemUser.Tag;

                            var server = new NavigatorIServiceClient();
                            var resp = server.DeleteUserFromGroup(mUserID, user.mId, group.mId);
                            if (resp != null && resp.mErrCode == 0)
                            {
                                var resp2 = server.GetUsers(mUserID);
                                RefreshUserListView(resp2);
                                /*var resp3 = server.GetGroups(mUserID);
                                RefreshGroupListView(resp3);*/
                            }
                            else 
                            {
                                MessageBox.Show(resp.mErrMessage);
                            }

                            server.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка! Закройте форму и повторите попытку!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не выбрана группа!");
                }
            }
        }
    }
}
