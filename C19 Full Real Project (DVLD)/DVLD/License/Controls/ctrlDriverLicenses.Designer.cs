namespace DVLD.License.Controls
{
    partial class ctrlDriverLicenses
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ControlBox = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.lblNumberOfLocalLicenses = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvLocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.cmsLocalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLocalLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.lblNumberOfInternationalLicenses = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvInternationalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.cmsInterenationalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.InternationalLicenseHistorytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.ControlBox.SuspendLayout();
            this.tpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).BeginInit();
            this.cmsLocalLicenseHistory.SuspendLayout();
            this.tpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).BeginInit();
            this.cmsInterenationalLicenseHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlBox
            // 
            this.ControlBox.Controls.Add(this.tpLocal);
            this.ControlBox.Controls.Add(this.tpInternational);
            this.ControlBox.Location = new System.Drawing.Point(0, 0);
            this.ControlBox.Name = "ControlBox";
            this.ControlBox.SelectedIndex = 0;
            this.ControlBox.Size = new System.Drawing.Size(1210, 340);
            this.ControlBox.TabIndex = 1;
            // 
            // tpLocal
            // 
            this.tpLocal.Controls.Add(this.lblNumberOfLocalLicenses);
            this.tpLocal.Controls.Add(this.label3);
            this.tpLocal.Controls.Add(this.dgvLocalLicensesHistory);
            this.tpLocal.Controls.Add(this.label2);
            this.tpLocal.Location = new System.Drawing.Point(4, 22);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(1202, 314);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            this.tpLocal.UseVisualStyleBackColor = true;
            // 
            // lblNumberOfLocalLicenses
            // 
            this.lblNumberOfLocalLicenses.AutoSize = true;
            this.lblNumberOfLocalLicenses.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfLocalLicenses.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNumberOfLocalLicenses.Location = new System.Drawing.Point(110, 291);
            this.lblNumberOfLocalLicenses.Name = "lblNumberOfLocalLicenses";
            this.lblNumberOfLocalLicenses.Size = new System.Drawing.Size(144, 21);
            this.lblNumberOfLocalLicenses.TabIndex = 13;
            this.lblNumberOfLocalLicenses.Text = "NumberOfRecords:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(20, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "#Records:";
            // 
            // dgvLocalLicensesHistory
            // 
            this.dgvLocalLicensesHistory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLocalLicensesHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLocalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicensesHistory.ContextMenuStrip = this.cmsLocalLicenseHistory;
            this.dgvLocalLicensesHistory.GridColor = System.Drawing.Color.White;
            this.dgvLocalLicensesHistory.Location = new System.Drawing.Point(22, 50);
            this.dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            this.dgvLocalLicensesHistory.ReadOnly = true;
            this.dgvLocalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalLicensesHistory.Size = new System.Drawing.Size(1158, 228);
            this.dgvLocalLicensesHistory.TabIndex = 11;
            // 
            // cmsLocalLicenseHistory
            // 
            this.cmsLocalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLocalLicenseInfoToolStripMenuItem});
            this.cmsLocalLicenseHistory.Name = "cmsLocalLicenseHistory";
            this.cmsLocalLicenseHistory.Size = new System.Drawing.Size(186, 42);
            // 
            // showLocalLicenseInfoToolStripMenuItem
            // 
            this.showLocalLicenseInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showLocalLicenseInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLocalLicenseInfoToolStripMenuItem.Name = "showLocalLicenseInfoToolStripMenuItem";
            this.showLocalLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(185, 38);
            this.showLocalLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLocalLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLocalLicenseInfoToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local Licenses History";
            // 
            // tpInternational
            // 
            this.tpInternational.Controls.Add(this.lblNumberOfInternationalLicenses);
            this.tpInternational.Controls.Add(this.label7);
            this.tpInternational.Controls.Add(this.dgvInternationalLicensesHistory);
            this.tpInternational.Controls.Add(this.label8);
            this.tpInternational.Location = new System.Drawing.Point(4, 22);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternational.Size = new System.Drawing.Size(1202, 314);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            this.tpInternational.UseVisualStyleBackColor = true;
            // 
            // lblNumberOfInternationalLicenses
            // 
            this.lblNumberOfInternationalLicenses.AutoSize = true;
            this.lblNumberOfInternationalLicenses.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfInternationalLicenses.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNumberOfInternationalLicenses.Location = new System.Drawing.Point(112, 284);
            this.lblNumberOfInternationalLicenses.Name = "lblNumberOfInternationalLicenses";
            this.lblNumberOfInternationalLicenses.Size = new System.Drawing.Size(144, 21);
            this.lblNumberOfInternationalLicenses.TabIndex = 17;
            this.lblNumberOfInternationalLicenses.Text = "NumberOfRecords:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(22, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "#Records:";
            // 
            // dgvInternationalLicensesHistory
            // 
            this.dgvInternationalLicensesHistory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInternationalLicensesHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvInternationalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicensesHistory.ContextMenuStrip = this.cmsInterenationalLicenseHistory;
            this.dgvInternationalLicensesHistory.GridColor = System.Drawing.Color.White;
            this.dgvInternationalLicensesHistory.Location = new System.Drawing.Point(26, 53);
            this.dgvInternationalLicensesHistory.Name = "dgvInternationalLicensesHistory";
            this.dgvInternationalLicensesHistory.ReadOnly = true;
            this.dgvInternationalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLicensesHistory.Size = new System.Drawing.Size(1142, 228);
            this.dgvInternationalLicensesHistory.TabIndex = 15;
            // 
            // cmsInterenationalLicenseHistory
            // 
            this.cmsInterenationalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InternationalLicenseHistorytoolStripMenuItem});
            this.cmsInterenationalLicenseHistory.Name = "cmsLocalLicenseHistory";
            this.cmsInterenationalLicenseHistory.Size = new System.Drawing.Size(186, 42);
            // 
            // InternationalLicenseHistorytoolStripMenuItem
            // 
            this.InternationalLicenseHistorytoolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.InternationalLicenseHistorytoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InternationalLicenseHistorytoolStripMenuItem.Name = "InternationalLicenseHistorytoolStripMenuItem";
            this.InternationalLicenseHistorytoolStripMenuItem.Size = new System.Drawing.Size(185, 38);
            this.InternationalLicenseHistorytoolStripMenuItem.Text = "Show License Info";
            this.InternationalLicenseHistorytoolStripMenuItem.Click += new System.EventHandler(this.InternationalLicenseHistorytoolStripMenuItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 21);
            this.label8.TabIndex = 14;
            this.label8.Text = "International Licenses History";
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ControlBox);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1208, 341);
            this.ControlBox.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.tpLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).EndInit();
            this.cmsLocalLicenseHistory.ResumeLayout(false);
            this.tpInternational.ResumeLayout(false);
            this.tpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).EndInit();
            this.cmsInterenationalLicenseHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ControlBox;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.Label lblNumberOfLocalLicenses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.Label lblNumberOfInternationalLicenses;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvInternationalLicensesHistory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem showLocalLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsInterenationalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem InternationalLicenseHistorytoolStripMenuItem;
    }
}
