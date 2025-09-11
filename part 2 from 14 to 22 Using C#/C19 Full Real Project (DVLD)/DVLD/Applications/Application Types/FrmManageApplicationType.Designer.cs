namespace DVLD.Applications
{
    partial class FrmManageApplicationTypes
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
            this.lblNumberOfApplicationTypes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvApplicationTypes = new System.Windows.Forms.DataGridView();
            this.cmsApplicationsTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editApplicationTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseManagePeople = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).BeginInit();
            this.cmsApplicationsTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumberOfApplicationTypes
            // 
            this.lblNumberOfApplicationTypes.AutoSize = true;
            this.lblNumberOfApplicationTypes.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfApplicationTypes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNumberOfApplicationTypes.Location = new System.Drawing.Point(111, 592);
            this.lblNumberOfApplicationTypes.Name = "lblNumberOfApplicationTypes";
            this.lblNumberOfApplicationTypes.Size = new System.Drawing.Size(144, 21);
            this.lblNumberOfApplicationTypes.TabIndex = 29;
            this.lblNumberOfApplicationTypes.Text = "NumberOfRecords:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(21, 592);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 28;
            this.label3.Text = "#Records:";
            // 
            // dgvApplicationTypes
            // 
            this.dgvApplicationTypes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvApplicationTypes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvApplicationTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationTypes.ContextMenuStrip = this.cmsApplicationsTypes;
            this.dgvApplicationTypes.GridColor = System.Drawing.Color.White;
            this.dgvApplicationTypes.Location = new System.Drawing.Point(25, 279);
            this.dgvApplicationTypes.Name = "dgvApplicationTypes";
            this.dgvApplicationTypes.ReadOnly = true;
            this.dgvApplicationTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplicationTypes.Size = new System.Drawing.Size(661, 298);
            this.dgvApplicationTypes.TabIndex = 26;
            // 
            // cmsApplicationsTypes
            // 
            this.cmsApplicationsTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplicationTypeToolStripMenuItem});
            this.cmsApplicationsTypes.Name = "cmsApplicationsTypes";
            this.cmsApplicationsTypes.Size = new System.Drawing.Size(200, 40);
            // 
            // editApplicationTypeToolStripMenuItem
            // 
            this.editApplicationTypeToolStripMenuItem.Image = global::DVLD.Properties.Resources.Create__1_;
            this.editApplicationTypeToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editApplicationTypeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editApplicationTypeToolStripMenuItem.Name = "editApplicationTypeToolStripMenuItem";
            this.editApplicationTypeToolStripMenuItem.Size = new System.Drawing.Size(199, 36);
            this.editApplicationTypeToolStripMenuItem.Text = "Edit Application Type";
            this.editApplicationTypeToolStripMenuItem.Click += new System.EventHandler(this.editApplicationTypeToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(201, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 30);
            this.label1.TabIndex = 23;
            this.label1.Text = "Manage Application Types";
            // 
            // btnCloseManagePeople
            // 
            this.btnCloseManagePeople.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseManagePeople.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseManagePeople.Image = global::DVLD.Properties.Resources.Close2__1_;
            this.btnCloseManagePeople.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseManagePeople.Location = new System.Drawing.Point(597, 583);
            this.btnCloseManagePeople.Name = "btnCloseManagePeople";
            this.btnCloseManagePeople.Size = new System.Drawing.Size(89, 39);
            this.btnCloseManagePeople.TabIndex = 31;
            this.btnCloseManagePeople.Text = "       Close";
            this.btnCloseManagePeople.UseVisualStyleBackColor = true;
            this.btnCloseManagePeople.Click += new System.EventHandler(this.btnCloseManagePeople_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.List_Of_Parts__1_;
            this.pictureBox1.Location = new System.Drawing.Point(249, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // FrmManageApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseManagePeople;
            this.ClientSize = new System.Drawing.Size(710, 643);
            this.Controls.Add(this.btnCloseManagePeople);
            this.Controls.Add(this.lblNumberOfApplicationTypes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvApplicationTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmManageApplicationTypes";
            this.Text = "Manage Application Types";
            this.Load += new System.EventHandler(this.FrmManageApplicationType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).EndInit();
            this.cmsApplicationsTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCloseManagePeople;
        private System.Windows.Forms.Label lblNumberOfApplicationTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvApplicationTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsApplicationsTypes;
        private System.Windows.Forms.ToolStripMenuItem editApplicationTypeToolStripMenuItem;
    }
}