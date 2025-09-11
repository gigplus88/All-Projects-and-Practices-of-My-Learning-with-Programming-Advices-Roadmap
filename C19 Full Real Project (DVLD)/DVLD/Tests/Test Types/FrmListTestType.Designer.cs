namespace DVLD
{
    partial class FrmListTestType
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
            this.lblNumberOfTestTypes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTestTypes = new System.Windows.Forms.DataGridView();
            this.cmsTestTypesList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTestTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCloseManageTestTypesList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypes)).BeginInit();
            this.cmsTestTypesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumberOfTestTypes
            // 
            this.lblNumberOfTestTypes.AutoSize = true;
            this.lblNumberOfTestTypes.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfTestTypes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNumberOfTestTypes.Location = new System.Drawing.Point(109, 578);
            this.lblNumberOfTestTypes.Name = "lblNumberOfTestTypes";
            this.lblNumberOfTestTypes.Size = new System.Drawing.Size(144, 21);
            this.lblNumberOfTestTypes.TabIndex = 36;
            this.lblNumberOfTestTypes.Text = "NumberOfRecords:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(19, 578);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 35;
            this.label3.Text = "#Records:";
            // 
            // dgvTestTypes
            // 
            this.dgvTestTypes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTestTypes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestTypes.ContextMenuStrip = this.cmsTestTypesList;
            this.dgvTestTypes.GridColor = System.Drawing.Color.White;
            this.dgvTestTypes.Location = new System.Drawing.Point(23, 265);
            this.dgvTestTypes.Name = "dgvTestTypes";
            this.dgvTestTypes.ReadOnly = true;
            this.dgvTestTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestTypes.Size = new System.Drawing.Size(862, 298);
            this.dgvTestTypes.TabIndex = 34;
            // 
            // cmsTestTypesList
            // 
            this.cmsTestTypesList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTestTypeToolStripMenuItem});
            this.cmsTestTypesList.Name = "cmsTestTypesList";
            this.cmsTestTypesList.Size = new System.Drawing.Size(159, 40);
            // 
            // editTestTypeToolStripMenuItem
            // 
            this.editTestTypeToolStripMenuItem.Image = global::DVLD.Properties.Resources.Edit2;
            this.editTestTypeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editTestTypeToolStripMenuItem.Name = "editTestTypeToolStripMenuItem";
            this.editTestTypeToolStripMenuItem.Size = new System.Drawing.Size(158, 36);
            this.editTestTypeToolStripMenuItem.Text = "Edit Test Type";
            this.editTestTypeToolStripMenuItem.Click += new System.EventHandler(this.editTestTypeToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(346, 215);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(220, 30);
            this.label1.TabIndex = 33;
            this.label1.Text = "Manage Test Types";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Test_Passed;
            this.pictureBox1.Location = new System.Drawing.Point(362, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // btnCloseManageTestTypesList
            // 
            this.btnCloseManageTestTypesList.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseManageTestTypesList.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseManageTestTypesList.Image = global::DVLD.Properties.Resources.Close2__1_;
            this.btnCloseManageTestTypesList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseManageTestTypesList.Location = new System.Drawing.Point(796, 578);
            this.btnCloseManageTestTypesList.Name = "btnCloseManageTestTypesList";
            this.btnCloseManageTestTypesList.Size = new System.Drawing.Size(89, 39);
            this.btnCloseManageTestTypesList.TabIndex = 38;
            this.btnCloseManageTestTypesList.Text = "       Close";
            this.btnCloseManageTestTypesList.UseVisualStyleBackColor = true;
            this.btnCloseManageTestTypesList.Click += new System.EventHandler(this.btnCloseManageTestTypesList_Click);
            // 
            // FrmListTestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseManageTestTypesList;
            this.ClientSize = new System.Drawing.Size(897, 621);
            this.Controls.Add(this.btnCloseManageTestTypesList);
            this.Controls.Add(this.lblNumberOfTestTypes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvTestTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmListTestType";
            this.ShowIcon = false;
            this.Text = "ListTestType";
            this.Load += new System.EventHandler(this.FrmListTestType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypes)).EndInit();
            this.cmsTestTypesList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNumberOfTestTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTestTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsTestTypesList;
        private System.Windows.Forms.ToolStripMenuItem editTestTypeToolStripMenuItem;
        private System.Windows.Forms.Button btnCloseManageTestTypesList;
    }
}