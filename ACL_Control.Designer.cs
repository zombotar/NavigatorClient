namespace Client1
{
    partial class ACL_Control
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
            this.objectNameLable = new System.Windows.Forms.Label();
            this.ownerTextBox = new System.Windows.Forms.TextBox();
            this.ownerGroupTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // objectNameLable
            // 
            this.objectNameLable.AutoSize = true;
            this.objectNameLable.Location = new System.Drawing.Point(13, 13);
            this.objectNameLable.Name = "objectNameLable";
            this.objectNameLable.Size = new System.Drawing.Size(43, 17);
            this.objectNameLable.TabIndex = 0;
            this.objectNameLable.Text = "name";
            // 
            // ownerTextBox
            // 
            this.ownerTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.ownerTextBox.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.ownerTextBox.Location = new System.Drawing.Point(16, 77);
            this.ownerTextBox.Name = "ownerTextBox";
            this.ownerTextBox.Size = new System.Drawing.Size(67, 22);
            this.ownerTextBox.TabIndex = 1;
            // 
            // ownerGroupTextBox
            // 
            this.ownerGroupTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.ownerGroupTextBox.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.ownerGroupTextBox.Location = new System.Drawing.Point(112, 77);
            this.ownerGroupTextBox.Name = "ownerGroupTextBox";
            this.ownerGroupTextBox.Size = new System.Drawing.Size(67, 22);
            this.ownerGroupTextBox.TabIndex = 2;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(16, 132);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(86, 39);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(112, 132);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(86, 39);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "ownerID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "ownerGroupID";
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "owner READ",
            "owner WRITE",
            "ownerGroup READ",
            "ownerGroup WRITE",
            "other READ",
            "other WRITE"});
            this.checkedListBox.Location = new System.Drawing.Point(308, 54);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(222, 140);
            this.checkedListBox.TabIndex = 7;
            // 
            // ACL_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 248);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.ownerGroupTextBox);
            this.Controls.Add(this.ownerTextBox);
            this.Controls.Add(this.objectNameLable);
            this.Name = "ACL_Control";
            this.Text = "ACL_Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ACL_Control_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label objectNameLable;
        private System.Windows.Forms.TextBox ownerTextBox;
        private System.Windows.Forms.TextBox ownerGroupTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBox;
    }
}