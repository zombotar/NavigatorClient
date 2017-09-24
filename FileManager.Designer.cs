namespace Client1
{
    partial class FileManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManager));
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.filepathNavBar = new System.Windows.Forms.TextBox();
            this.prevButton = new System.Windows.Forms.Button();
            this.addFileButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.addDirButton = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.setKeyButton = new System.Windows.Forms.Button();
            this.keyIndicator = new System.Windows.Forms.Label();
            this.adminDBControlButton = new System.Windows.Forms.Button();
            this.changeACLButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.fileInfoClassLabel = new System.Windows.Forms.Label();
            this.panelNavigation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(12, 72);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(712, 493);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "File.bmp");
            this.imageList1.Images.SetKeyName(1, "FolderClose.bmp");
            // 
            // panelNavigation
            // 
            this.panelNavigation.Controls.Add(this.refreshButton);
            this.panelNavigation.Controls.Add(this.filepathNavBar);
            this.panelNavigation.Controls.Add(this.prevButton);
            this.panelNavigation.Location = new System.Drawing.Point(12, 13);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(712, 53);
            this.panelNavigation.TabIndex = 1;
            // 
            // refreshButton
            // 
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.Location = new System.Drawing.Point(75, -1);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(57, 54);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // filepathNavBar
            // 
            this.filepathNavBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filepathNavBar.Location = new System.Drawing.Point(160, 18);
            this.filepathNavBar.Name = "filepathNavBar";
            this.filepathNavBar.Size = new System.Drawing.Size(533, 26);
            this.filepathNavBar.TabIndex = 1;
            // 
            // prevButton
            // 
            this.prevButton.Image = ((System.Drawing.Image)(resources.GetObject("prevButton.Image")));
            this.prevButton.Location = new System.Drawing.Point(13, -1);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(55, 54);
            this.prevButton.TabIndex = 0;
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // addFileButton
            // 
            this.addFileButton.Location = new System.Drawing.Point(730, 146);
            this.addFileButton.Name = "addFileButton";
            this.addFileButton.Size = new System.Drawing.Size(121, 47);
            this.addFileButton.TabIndex = 2;
            this.addFileButton.Text = "Add File";
            this.addFileButton.UseVisualStyleBackColor = true;
            this.addFileButton.Click += new System.EventHandler(this.addFileButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(730, 217);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(121, 49);
            this.loadButton.TabIndex = 3;
            this.loadButton.Text = "Load File";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // addDirButton
            // 
            this.addDirButton.Location = new System.Drawing.Point(857, 146);
            this.addDirButton.Name = "addDirButton";
            this.addDirButton.Size = new System.Drawing.Size(123, 47);
            this.addDirButton.TabIndex = 4;
            this.addDirButton.Text = "Add Directory";
            this.addDirButton.UseVisualStyleBackColor = true;
            this.addDirButton.Click += new System.EventHandler(this.addDirButton_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(859, 218);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(121, 47);
            this.Delete.TabIndex = 5;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // setKeyButton
            // 
            this.setKeyButton.Location = new System.Drawing.Point(732, 479);
            this.setKeyButton.Name = "setKeyButton";
            this.setKeyButton.Size = new System.Drawing.Size(121, 51);
            this.setKeyButton.TabIndex = 6;
            this.setKeyButton.Text = "Set Key";
            this.setKeyButton.UseVisualStyleBackColor = true;
            this.setKeyButton.Click += new System.EventHandler(this.setKeyButton_Click);
            // 
            // keyIndicator
            // 
            this.keyIndicator.AutoSize = true;
            this.keyIndicator.Location = new System.Drawing.Point(859, 496);
            this.keyIndicator.Name = "keyIndicator";
            this.keyIndicator.Size = new System.Drawing.Size(122, 17);
            this.keyIndicator.TabIndex = 7;
            this.keyIndicator.Text = "Key is not found!!!!";
            // 
            // adminDBControlButton
            // 
            this.adminDBControlButton.Location = new System.Drawing.Point(730, 11);
            this.adminDBControlButton.Name = "adminDBControlButton";
            this.adminDBControlButton.Size = new System.Drawing.Size(121, 53);
            this.adminDBControlButton.TabIndex = 8;
            this.adminDBControlButton.Text = "AdminControl";
            this.adminDBControlButton.UseVisualStyleBackColor = true;
            this.adminDBControlButton.Click += new System.EventHandler(this.adminDBControlButton_Click);
            // 
            // changeACLButton
            // 
            this.changeACLButton.Location = new System.Drawing.Point(862, 11);
            this.changeACLButton.Name = "changeACLButton";
            this.changeACLButton.Size = new System.Drawing.Size(118, 53);
            this.changeACLButton.TabIndex = 9;
            this.changeACLButton.Text = "ChangeACL";
            this.changeACLButton.UseVisualStyleBackColor = true;
            this.changeACLButton.Click += new System.EventHandler(this.changeACLButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.fileInfoClassLabel);
            this.groupBox1.Controls.Add(this.sizeLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(732, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 170);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Class";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(121, 45);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(0, 20);
            this.sizeLabel.TabIndex = 2;
            // 
            // fileInfoClassLabel
            // 
            this.fileInfoClassLabel.AutoSize = true;
            this.fileInfoClassLabel.Location = new System.Drawing.Point(123, 102);
            this.fileInfoClassLabel.Name = "fileInfoClassLabel";
            this.fileInfoClassLabel.Size = new System.Drawing.Size(0, 20);
            this.fileInfoClassLabel.TabIndex = 3;
            // 
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 577);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.changeACLButton);
            this.Controls.Add(this.adminDBControlButton);
            this.Controls.Add(this.keyIndicator);
            this.Controls.Add(this.setKeyButton);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.addDirButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.addFileButton);
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.listView1);
            this.Name = "FileManager";
            this.Text = "FileManager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileManager_FormClosed);
            this.Load += new System.EventHandler(this.FileManager_Load);
            this.panelNavigation.ResumeLayout(false);
            this.panelNavigation.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button addFileButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TextBox filepathNavBar;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button addDirButton;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button setKeyButton;
        private System.Windows.Forms.Label keyIndicator;
        private System.Windows.Forms.Button adminDBControlButton;
        private System.Windows.Forms.Button changeACLButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label fileInfoClassLabel;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}