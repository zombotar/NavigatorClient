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
    public partial class AddUserDialog : Form
    {
        public string username { get; set; }
        public string password_hash { get; set; }
        public AddUserDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text.Equals("") == false && passwordTextBox.Text.Equals("") == false)
            {
                username = usernameTextBox.Text;
                password_hash = Authenticate.HashString(passwordTextBox.Text);
            }
            else
            {
                MessageBox.Show("Заполните оба поля!");
            }
        }
    }
}
