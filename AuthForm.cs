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

namespace Client1
{
    public partial class Authenticate : Form
    {
        public Authenticate()
        {
            InitializeComponent();
        }

        public static string HashString(string str)
        {
            byte[] hash = Encoding.ASCII.GetBytes(str);
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] hashenc = md5.ComputeHash(hash);
            string result = "";
            foreach (var b in hashenc)
            {
                result += b.ToString("x2");
            }
            return result;
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            if (username != "" && password != "")
            {
                string p_hash = HashString(password);
                var server = new NavigatorService.NavigatorIServiceClient();
                var resp = server.Authentication(username, p_hash);
                if (resp.mResult.mErrCode == 0)
                {
                    FileManager otherForm = new FileManager(resp.mUserId, this, resp.mGroupNames);
                    //otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
                    this.Hide();
                    otherForm.Show();
                }
                else
                {
                    MessageBox.Show(resp.mResult.mErrMessage);
                }
            }
        }

        private void Authenticate_Load(object sender, EventArgs e)
        {
            passwordTextBox.Text = "";
        }
    }
}
