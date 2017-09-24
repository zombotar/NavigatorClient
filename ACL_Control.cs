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

namespace Client1
{
    public partial class ACL_Control : Form
    {
        private Form mOwner { get; set; }
        private FilesystemObject mMetaObject { get; set; }
        private int mUserID { get; set; }

        public ACL_Control(Form _owner, FilesystemObject _object, int _idUser)
        {
            InitializeComponent();

            //_owner.Enabled = false;

            mOwner = _owner;
            mMetaObject = _object;
            mUserID = _idUser;

            objectNameLable.Text = mMetaObject.mFilepath;
            ownerTextBox.Text = mMetaObject.mUid.ToString();
            ownerGroupTextBox.Text = mMetaObject.mGid.ToString();

            int mask = 32;

            for (int i = 0; i < checkedListBox.Items.Count; ++i)
            {
                if ((mask & mMetaObject.mAccessBitset) != 0)
                {
                    checkedListBox.SetItemChecked(i, true);
                }
                mask = mask >> 1;
            }

        }

        private void ACL_Control_FormClosed(object sender, FormClosedEventArgs e)
        {
            //mOwner.Enabled = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var server = new NavigatorIServiceClient();

            int newAccessBitset = 0;
            int newOwnerID = 0;
            int newOwnerGroupID = -1;

            int mask = 32;
            int i = 0;
            foreach (var item in checkedListBox.Items)
            {
                if (checkedListBox.GetItemChecked(i))
                {
                    newAccessBitset = newAccessBitset | mask;
                }
                ++i;
                mask = mask >> 1;
            }

            if (!Int32.TryParse(ownerTextBox.Text, out newOwnerID))
            {
                newOwnerID = -1;
            }
            if (!Int32.TryParse(ownerGroupTextBox.Text, out newOwnerGroupID))
            {
                newOwnerGroupID = -1;
            }

            var result = server.ChangeAccess(mUserID, mMetaObject.mId, newAccessBitset, newOwnerID, newOwnerGroupID);
            if (result != null && result.mErrCode == 0)
            {
                MessageBox.Show("Ok!");
                this.DialogResult = DialogResult.OK;
            }
            else if (result != null)
            {
                MessageBox.Show(result.mErrMessage);
                this.DialogResult = DialogResult.Abort;
            }

            server.Close();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
