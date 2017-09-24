namespace Client1
{
    partial class AdminDBControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userTreeView = new System.Windows.Forms.TreeView();
            this.deleteFromGroup = new System.Windows.Forms.Button();
            this.addToGroupUser = new System.Windows.Forms.Button();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.addUserButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteGroupButton = new System.Windows.Forms.Button();
            this.addGroupButton = new System.Windows.Forms.Button();
            this.groupsListView = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userTreeView);
            this.groupBox1.Controls.Add(this.deleteFromGroup);
            this.groupBox1.Controls.Add(this.addToGroupUser);
            this.groupBox1.Controls.Add(this.deleteUserButton);
            this.groupBox1.Controls.Add(this.addUserButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 478);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users";
            // 
            // userTreeView
            // 
            this.userTreeView.FullRowSelect = true;
            this.userTreeView.Location = new System.Drawing.Point(6, 22);
            this.userTreeView.Name = "userTreeView";
            this.userTreeView.Size = new System.Drawing.Size(440, 302);
            this.userTreeView.TabIndex = 4;
            // 
            // deleteFromGroup
            // 
            this.deleteFromGroup.Location = new System.Drawing.Point(115, 374);
            this.deleteFromGroup.Name = "deleteFromGroup";
            this.deleteFromGroup.Size = new System.Drawing.Size(161, 43);
            this.deleteFromGroup.TabIndex = 3;
            this.deleteFromGroup.Text = "DeleteFromGroup";
            this.deleteFromGroup.UseVisualStyleBackColor = true;
            this.deleteFromGroup.Click += new System.EventHandler(this.deleteFromGroup_Click);
            // 
            // addToGroupUser
            // 
            this.addToGroupUser.Location = new System.Drawing.Point(6, 374);
            this.addToGroupUser.Name = "addToGroupUser";
            this.addToGroupUser.Size = new System.Drawing.Size(102, 43);
            this.addToGroupUser.TabIndex = 2;
            this.addToGroupUser.Text = "AddToGroup";
            this.addToGroupUser.UseVisualStyleBackColor = true;
            this.addToGroupUser.Click += new System.EventHandler(this.addToGroupUser_Click);
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.Location = new System.Drawing.Point(115, 330);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(102, 38);
            this.deleteUserButton.TabIndex = 2;
            this.deleteUserButton.Text = "Delete";
            this.deleteUserButton.UseVisualStyleBackColor = true;
            this.deleteUserButton.Click += new System.EventHandler(this.deleteUserButton_Click);
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(7, 330);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(102, 38);
            this.addUserButton.TabIndex = 1;
            this.addUserButton.Text = "Add";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deleteGroupButton);
            this.groupBox2.Controls.Add(this.addGroupButton);
            this.groupBox2.Controls.Add(this.groupsListView);
            this.groupBox2.Location = new System.Drawing.Point(509, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 417);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Groups";
            // 
            // deleteGroupButton
            // 
            this.deleteGroupButton.Location = new System.Drawing.Point(114, 329);
            this.deleteGroupButton.Name = "deleteGroupButton";
            this.deleteGroupButton.Size = new System.Drawing.Size(102, 38);
            this.deleteGroupButton.TabIndex = 4;
            this.deleteGroupButton.Text = "Delete";
            this.deleteGroupButton.UseVisualStyleBackColor = true;
            this.deleteGroupButton.Click += new System.EventHandler(this.deleteGroupButton_Click);
            // 
            // addGroupButton
            // 
            this.addGroupButton.Location = new System.Drawing.Point(6, 330);
            this.addGroupButton.Name = "addGroupButton";
            this.addGroupButton.Size = new System.Drawing.Size(102, 38);
            this.addGroupButton.TabIndex = 3;
            this.addGroupButton.Text = "Add";
            this.addGroupButton.UseVisualStyleBackColor = true;
            this.addGroupButton.Click += new System.EventHandler(this.addGroupButton_Click);
            // 
            // groupsListView
            // 
            this.groupsListView.Location = new System.Drawing.Point(6, 22);
            this.groupsListView.Name = "groupsListView";
            this.groupsListView.Size = new System.Drawing.Size(419, 302);
            this.groupsListView.TabIndex = 1;
            this.groupsListView.UseCompatibleStateImageBehavior = false;
            // 
            // AdminDBControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 585);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminDBControl";
            this.Text = "AdminDBControl";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminDBControl_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView groupsListView;
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.Button deleteGroupButton;
        private System.Windows.Forms.Button addGroupButton;
        private System.Windows.Forms.Button deleteFromGroup;
        private System.Windows.Forms.Button addToGroupUser;
        private System.Windows.Forms.TreeView userTreeView;
    }
}