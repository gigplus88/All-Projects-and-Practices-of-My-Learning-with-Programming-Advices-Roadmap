namespace DVLD.Users
{
    partial class FrmUserInfo
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
            this.ctrlUserCard1 = new DVLD.Controls.ctrlUserCard();
            this.btnCloseManagePeople = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlUserCard1
            // 
            this.ctrlUserCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlUserCard1.Location = new System.Drawing.Point(12, 12);
            this.ctrlUserCard1.Name = "ctrlUserCard1";
            this.ctrlUserCard1.Size = new System.Drawing.Size(993, 500);
            this.ctrlUserCard1.TabIndex = 0;
            // 
            // btnCloseManagePeople
            // 
            this.btnCloseManagePeople.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseManagePeople.Image = global::DVLD.Properties.Resources.Close2__1_;
            this.btnCloseManagePeople.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseManagePeople.Location = new System.Drawing.Point(913, 518);
            this.btnCloseManagePeople.Name = "btnCloseManagePeople";
            this.btnCloseManagePeople.Size = new System.Drawing.Size(89, 39);
            this.btnCloseManagePeople.TabIndex = 21;
            this.btnCloseManagePeople.Text = "       Close";
            this.btnCloseManagePeople.UseVisualStyleBackColor = true;
            this.btnCloseManagePeople.Click += new System.EventHandler(this.btnCloseManagePeople_Click);
            // 
            // FrmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 563);
            this.Controls.Add(this.btnCloseManagePeople);
            this.Controls.Add(this.ctrlUserCard1);
            this.Name = "FrmUserInfo";
            this.Text = "User Info";
            this.Load += new System.EventHandler(this.FrmUserInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlUserCard ctrlUserCard1;
        private System.Windows.Forms.Button btnCloseManagePeople;
    }
}