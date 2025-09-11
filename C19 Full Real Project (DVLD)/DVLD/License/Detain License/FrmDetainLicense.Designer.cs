namespace DVLD.License
{
    partial class FrmDetainLicense
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
            this.llblShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.gbApplicationNewLicenseInfo = new System.Windows.Forms.GroupBox();
            this.txtFineFees = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfoWithFilter = new DVLD.Controls.ctrlDriverLicenseInfoWithFilter();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.gbApplicationNewLicenseInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // llblShowLicenseInfo
            // 
            this.llblShowLicenseInfo.AutoSize = true;
            this.llblShowLicenseInfo.Enabled = false;
            this.llblShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblShowLicenseInfo.Location = new System.Drawing.Point(307, 885);
            this.llblShowLicenseInfo.Name = "llblShowLicenseInfo";
            this.llblShowLicenseInfo.Size = new System.Drawing.Size(135, 21);
            this.llblShowLicenseInfo.TabIndex = 140;
            this.llblShowLicenseInfo.TabStop = true;
            this.llblShowLicenseInfo.Text = "Show License Info";
            this.llblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicenseInfo_LinkClicked);
            // 
            // llblShowLicensesHistory
            // 
            this.llblShowLicensesHistory.AutoSize = true;
            this.llblShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblShowLicensesHistory.Location = new System.Drawing.Point(56, 885);
            this.llblShowLicensesHistory.Name = "llblShowLicensesHistory";
            this.llblShowLicensesHistory.Size = new System.Drawing.Size(165, 21);
            this.llblShowLicensesHistory.TabIndex = 139;
            this.llblShowLicensesHistory.TabStop = true;
            this.llblShowLicensesHistory.Text = "Show Licenses History";
            this.llblShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicensesHistory_LinkClicked);
            // 
            // gbApplicationNewLicenseInfo
            // 
            this.gbApplicationNewLicenseInfo.Controls.Add(this.txtFineFees);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.pictureBox5);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.pictureBox7);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label8);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label6);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.pictureBox1);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblDetainDate);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label2);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.pictureBox13);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblLicenseID);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label13);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.pictureBox12);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblDetainID);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label20);
            this.gbApplicationNewLicenseInfo.Location = new System.Drawing.Point(19, 664);
            this.gbApplicationNewLicenseInfo.Name = "gbApplicationNewLicenseInfo";
            this.gbApplicationNewLicenseInfo.Size = new System.Drawing.Size(958, 203);
            this.gbApplicationNewLicenseInfo.TabIndex = 138;
            this.gbApplicationNewLicenseInfo.TabStop = false;
            this.gbApplicationNewLicenseInfo.Text = "Application New License Info";
            // 
            // txtFineFees
            // 
            this.txtFineFees.Location = new System.Drawing.Point(191, 150);
            this.txtFineFees.Name = "txtFineFees";
            this.txtFineFees.Size = new System.Drawing.Size(100, 20);
            this.txtFineFees.TabIndex = 148;
            this.txtFineFees.Validating += new System.ComponentModel.CancelEventHandler(this.txtFineFees_Validating);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Image = global::DVLD.Properties.Resources.calendar_52930251;
            this.pictureBox5.Location = new System.Drawing.Point(147, 79);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(33, 29);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 147;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Image = global::DVLD.Properties.Resources.pbName2;
            this.pictureBox7.Location = new System.Drawing.Point(583, 92);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(33, 29);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 145;
            this.pictureBox7.TabStop = false;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoEllipsis = true;
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(651, 98);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(57, 16);
            this.lblCreatedBy.TabIndex = 144;
            this.lblCreatedBy.Text = "[?????]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(424, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 143;
            this.label8.Text = "Created By:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 139;
            this.label6.Text = "Fine Fees:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Money_Bag1;
            this.pictureBox1.Location = new System.Drawing.Point(147, 141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 138;
            this.pictureBox1.TabStop = false;
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoEllipsis = true;
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.Location = new System.Drawing.Point(188, 87);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(57, 16);
            this.lblDetainDate.TabIndex = 131;
            this.lblDetainDate.Text = "[?????]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 130;
            this.label2.Text = "Detain Date:";
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox13.Image = global::DVLD.Properties.Resources.Driver_License11;
            this.pictureBox13.Location = new System.Drawing.Point(583, 30);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(33, 29);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 129;
            this.pictureBox13.TabStop = false;
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoEllipsis = true;
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(651, 38);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(57, 16);
            this.lblLicenseID.TabIndex = 126;
            this.lblLicenseID.Text = "[?????]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(424, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 16);
            this.label13.TabIndex = 125;
            this.label13.Text = "License ID:";
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox12.Image = global::DVLD.Properties.Resources.Reminder__1_1;
            this.pictureBox12.Location = new System.Drawing.Point(147, 30);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(33, 29);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 119;
            this.pictureBox12.TabStop = false;
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoEllipsis = true;
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.Location = new System.Drawing.Point(188, 35);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(57, 16);
            this.lblDetainID.TabIndex = 118;
            this.lblDetainID.Text = "[?????]";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 16);
            this.label20.TabIndex = 117;
            this.label20.Text = "Detain ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(440, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(186, 34);
            this.label9.TabIndex = 137;
            this.label9.Text = "Detain License";
            // 
            // ctrlDriverLicenseInfoWithFilter
            // 
            this.ctrlDriverLicenseInfoWithFilter.FilterEnabled = true;
            this.ctrlDriverLicenseInfoWithFilter.Location = new System.Drawing.Point(9, 74);
            this.ctrlDriverLicenseInfoWithFilter.Name = "ctrlDriverLicenseInfoWithFilter";
            this.ctrlDriverLicenseInfoWithFilter.Size = new System.Drawing.Size(976, 575);
            this.ctrlDriverLicenseInfoWithFilter.TabIndex = 136;
            this.ctrlDriverLicenseInfoWithFilter.TxtFocus = true;
            this.ctrlDriverLicenseInfoWithFilter.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseInfo1_OnLicenseSelected);
            this.ctrlDriverLicenseInfoWithFilter.TextBoxTextChanged += new System.EventHandler(this.ctrlDriverLicenseInfoWithFilter_TextBoxTextChanged);
            // 
            // btnDetain
            // 
            this.btnDetain.Enabled = false;
            this.btnDetain.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetain.Image = global::DVLD.Properties.Resources.Left_Handed__1_;
            this.btnDetain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetain.Location = new System.Drawing.Point(892, 878);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(85, 34);
            this.btnDetain.TabIndex = 142;
            this.btnDetain.Text = "     Detain";
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close2;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(797, 878);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 34);
            this.btnClose.TabIndex = 141;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::DVLD.Properties.Resources.Left_Handed__1_;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(485, 878);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 34);
            this.btnReset.TabIndex = 143;
            this.btnReset.Text = "     Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FrmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 931);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.llblShowLicenseInfo);
            this.Controls.Add(this.llblShowLicensesHistory);
            this.Controls.Add(this.gbApplicationNewLicenseInfo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter);
            this.Name = "FrmDetainLicense";
            this.Text = "Detain License";
            this.Load += new System.EventHandler(this.FrmDetainLicense_Load);
            this.Shown += new System.EventHandler(this.FrmDetainLicense_Shown);
            this.gbApplicationNewLicenseInfo.ResumeLayout(false);
            this.gbApplicationNewLicenseInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llblShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llblShowLicensesHistory;
        private System.Windows.Forms.GroupBox gbApplicationNewLicenseInfo;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label9;
        private DVLD.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter;
        private System.Windows.Forms.TextBox txtFineFees;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnReset;
    }
}