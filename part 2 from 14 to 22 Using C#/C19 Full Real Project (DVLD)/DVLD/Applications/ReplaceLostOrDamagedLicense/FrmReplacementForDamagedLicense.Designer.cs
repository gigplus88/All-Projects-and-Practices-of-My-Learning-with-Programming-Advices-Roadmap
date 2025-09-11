using System.ComponentModel;

namespace DVLD.Applications
{
    partial class FrmReplacementForDamagedLicense
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD.Controls.ctrlDriverLicenseInfoWithFilter();
            this.gbApplicationNewLicenseInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblAppliocationDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.lblLRApplicationID = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            //this.btnRenew = new System.Windows.Forms.Button();
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.llblShowNewLicensesInfo = new System.Windows.Forms.LinkLabel();
            this.llblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.gbReplacementFor = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbdamagedLicense = new System.Windows.Forms.RadioButton();
            this.btnReset = new System.Windows.Forms.Button();
            this.gbApplicationNewLicenseInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.gbReplacementFor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(299, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(389, 30);
            this.lblTitle.TabIndex = 127;
            this.lblTitle.Text = "Replacement For Demaged License";
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(2, 74);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(976, 575);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 125;
            this.ctrlDriverLicenseInfoWithFilter1.TxtFocus = true;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseInfo1_OnLicenseSelected);
            this.ctrlDriverLicenseInfoWithFilter1.TextBoxTextChanged += new System.EventHandler(this.ctrlDriverLicenseInfoWithFilter1_TextBoxTextChanged);
            // 
            // gbApplicationNewLicenseInfo
            // 
            this.gbApplicationNewLicenseInfo.Controls.Add(this.pictureBox5);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.pictureBox7);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label8);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label6);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.pictureBox1);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblApplicationFees);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblAppliocationDate);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label2);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.pictureBox13);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblOldLicenseID);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label13);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.pictureBox6);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblReplacedLicenseID);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label3);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.pictureBox12);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblLRApplicationID);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label20);
            this.gbApplicationNewLicenseInfo.Location = new System.Drawing.Point(12, 664);
            this.gbApplicationNewLicenseInfo.Name = "gbApplicationNewLicenseInfo";
            this.gbApplicationNewLicenseInfo.Size = new System.Drawing.Size(958, 203);
            this.gbApplicationNewLicenseInfo.TabIndex = 128;
            this.gbApplicationNewLicenseInfo.TabStop = false;
            this.gbApplicationNewLicenseInfo.Text = "Application New License Info";
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
            this.pictureBox7.Location = new System.Drawing.Point(609, 141);
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
            this.lblCreatedBy.Location = new System.Drawing.Point(650, 147);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(57, 16);
            this.lblCreatedBy.TabIndex = 144;
            this.lblCreatedBy.Text = "[?????]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(423, 147);
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
            this.label6.Size = new System.Drawing.Size(128, 16);
            this.label6.TabIndex = 139;
            this.label6.Text = "Application Fees:";
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
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoEllipsis = true;
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(188, 147);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(57, 16);
            this.lblApplicationFees.TabIndex = 137;
            this.lblApplicationFees.Text = "[?????]";
            // 
            // lblAppliocationDate
            // 
            this.lblAppliocationDate.AutoEllipsis = true;
            this.lblAppliocationDate.AutoSize = true;
            this.lblAppliocationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppliocationDate.Location = new System.Drawing.Point(188, 87);
            this.lblAppliocationDate.Name = "lblAppliocationDate";
            this.lblAppliocationDate.Size = new System.Drawing.Size(57, 16);
            this.lblAppliocationDate.TabIndex = 131;
            this.lblAppliocationDate.Text = "[?????]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 130;
            this.label2.Text = "Appliocation Date:";
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox13.Image = global::DVLD.Properties.Resources.Driver_License11;
            this.pictureBox13.Location = new System.Drawing.Point(609, 79);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(33, 29);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 129;
            this.pictureBox13.TabStop = false;
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoEllipsis = true;
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(650, 87);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(57, 16);
            this.lblOldLicenseID.TabIndex = 126;
            this.lblOldLicenseID.Text = "[?????]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(423, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 16);
            this.label13.TabIndex = 125;
            this.label13.Text = "Old License ID:";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Image = global::DVLD.Properties.Resources.Smart_Card22;
            this.pictureBox6.Location = new System.Drawing.Point(609, 30);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(33, 29);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 124;
            this.pictureBox6.TabStop = false;
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoEllipsis = true;
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(650, 40);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(57, 16);
            this.lblReplacedLicenseID.TabIndex = 123;
            this.lblReplacedLicenseID.Text = "[?????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(423, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 16);
            this.label3.TabIndex = 122;
            this.label3.Text = "Replaced License ID:";
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
            // lblLRApplicationID
            // 
            this.lblLRApplicationID.AutoEllipsis = true;
            this.lblLRApplicationID.AutoSize = true;
            this.lblLRApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLRApplicationID.Location = new System.Drawing.Point(188, 35);
            this.lblLRApplicationID.Name = "lblLRApplicationID";
            this.lblLRApplicationID.Size = new System.Drawing.Size(57, 16);
            this.lblLRApplicationID.TabIndex = 118;
            this.lblLRApplicationID.Text = "[?????]";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(135, 16);
            this.label20.TabIndex = 117;
            this.label20.Text = "L.R.Application ID:";
           
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.Enabled = false;
            this.btnIssueReplacement.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReplacement.Image = global::DVLD.Properties.Resources.Left_Handed__1_;
            this.btnIssueReplacement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueReplacement.Location = new System.Drawing.Point(803, 869);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(175, 34);
            this.btnIssueReplacement.TabIndex = 135;
            this.btnIssueReplacement.Text = "     Issue Replacement";
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close2;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(708, 869);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 34);
            this.btnClose.TabIndex = 134;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // llblShowNewLicensesInfo
            // 
            this.llblShowNewLicensesInfo.AutoSize = true;
            this.llblShowNewLicensesInfo.Enabled = false;
            this.llblShowNewLicensesInfo.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblShowNewLicensesInfo.Location = new System.Drawing.Point(259, 876);
            this.llblShowNewLicensesInfo.Name = "llblShowNewLicensesInfo";
            this.llblShowNewLicensesInfo.Size = new System.Drawing.Size(182, 21);
            this.llblShowNewLicensesInfo.TabIndex = 131;
            this.llblShowNewLicensesInfo.TabStop = true;
            this.llblShowNewLicensesInfo.Text = "Show  New Licenses Info";
            this.llblShowNewLicensesInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowNewLicensesInfo_LinkClicked);
            // 
            // llblShowLicensesHistory
            // 
            this.llblShowLicensesHistory.AutoSize = true;
            this.llblShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblShowLicensesHistory.Location = new System.Drawing.Point(46, 876);
            this.llblShowLicensesHistory.Name = "llblShowLicensesHistory";
            this.llblShowLicensesHistory.Size = new System.Drawing.Size(165, 21);
            this.llblShowLicensesHistory.TabIndex = 129;
            this.llblShowLicensesHistory.TabStop = true;
            this.llblShowLicensesHistory.Text = "Show Licenses History";
            this.llblShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicensesHistory_LinkClicked);
            // 
            // gbReplacementFor
            // 
            this.gbReplacementFor.Controls.Add(this.rbLostLicense);
            this.gbReplacementFor.Controls.Add(this.rbdamagedLicense);
            this.gbReplacementFor.Location = new System.Drawing.Point(692, 83);
            this.gbReplacementFor.Name = "gbReplacementFor";
            this.gbReplacementFor.Size = new System.Drawing.Size(278, 94);
            this.gbReplacementFor.TabIndex = 136;
            this.gbReplacementFor.TabStop = false;
            this.gbReplacementFor.Text = "Replacement For";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLostLicense.Location = new System.Drawing.Point(6, 56);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(110, 22);
            this.rbLostLicense.TabIndex = 1;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbLostLicense_CheckedChanged);
            // 
            // rbdamagedLicense
            // 
            this.rbdamagedLicense.AutoSize = true;
            this.rbdamagedLicense.Checked = true;
            this.rbdamagedLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbdamagedLicense.Location = new System.Drawing.Point(6, 19);
            this.rbdamagedLicense.Name = "rbdamagedLicense";
            this.rbdamagedLicense.Size = new System.Drawing.Size(145, 22);
            this.rbdamagedLicense.TabIndex = 0;
            this.rbdamagedLicense.TabStop = true;
            this.rbdamagedLicense.Text = "Damaged License";
            this.rbdamagedLicense.UseVisualStyleBackColor = true;
            this.rbdamagedLicense.CheckedChanged += new System.EventHandler(this.rbdamagedLicense_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::DVLD.Properties.Resources.Left_Handed__1_;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(506, 873);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 34);
            this.btnReset.TabIndex = 145;
            this.btnReset.Text = "     Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FrmReplacementForDamagedLicense
            // 
            this.AcceptButton = this.btnIssueReplacement;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(979, 915);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.gbReplacementFor);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.llblShowNewLicensesInfo);
            this.Controls.Add(this.llblShowLicensesHistory);
            this.Controls.Add(this.gbApplicationNewLicenseInfo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReplacementForDamagedLicense";
            this.ShowIcon = false;
            this.Text = "Replacement For Demaged License";
            this.Activated += new System.EventHandler(this.FrmReplacementForDamagedLicense_Activated);
            this.Load += new System.EventHandler(this.FrmReplacementForDemagedLicense_Load);
            this.gbApplicationNewLicenseInfo.ResumeLayout(false);
            this.gbApplicationNewLicenseInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.gbReplacementFor.ResumeLayout(false);
            this.gbReplacementFor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.GroupBox gbApplicationNewLicenseInfo;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblAppliocationDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Label lblLRApplicationID;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llblShowNewLicensesInfo;
        private System.Windows.Forms.LinkLabel llblShowLicensesHistory;
        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbdamagedLicense;
        private System.Windows.Forms.Button btnReset;
    }
}