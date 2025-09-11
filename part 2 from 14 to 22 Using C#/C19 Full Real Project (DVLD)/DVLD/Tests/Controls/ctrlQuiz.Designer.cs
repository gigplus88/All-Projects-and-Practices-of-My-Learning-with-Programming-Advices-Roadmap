namespace DVLD.Tests.Controls
{
    partial class ctrlQuiz
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbQuize = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblQuizText = new System.Windows.Forms.Label();
            this.lblQuizeNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbQuize.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbQuize
            // 
            this.gbQuize.Controls.Add(this.groupBox1);
            this.gbQuize.Controls.Add(this.lblQuizeNumber);
            this.gbQuize.Controls.Add(this.label1);
            this.gbQuize.Location = new System.Drawing.Point(0, 3);
            this.gbQuize.Name = "gbQuize";
            this.gbQuize.Size = new System.Drawing.Size(743, 454);
            this.gbQuize.TabIndex = 0;
            this.gbQuize.TabStop = false;
            this.gbQuize.Text = "Quiz";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.lblQuizText);
            this.groupBox1.Location = new System.Drawing.Point(39, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 334);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lblQuizText
            // 
            this.lblQuizText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuizText.Location = new System.Drawing.Point(36, 30);
            this.lblQuizText.Name = "lblQuizText";
            this.lblQuizText.Size = new System.Drawing.Size(601, 283);
            this.lblQuizText.TabIndex = 0;
            this.lblQuizText.Text = "QuizText";
            // 
            // lblQuizeNumber
            // 
            this.lblQuizeNumber.AutoSize = true;
            this.lblQuizeNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuizeNumber.Location = new System.Drawing.Point(396, 58);
            this.lblQuizeNumber.Name = "lblQuizeNumber";
            this.lblQuizeNumber.Size = new System.Drawing.Size(33, 19);
            this.lblQuizeNumber.TabIndex = 1;
            this.lblQuizeNumber.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(271, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quiz";
            // 
            // ctrlQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbQuize);
            this.Name = "ctrlQuiz";
            this.Size = new System.Drawing.Size(746, 461);
            this.gbQuize.ResumeLayout(false);
            this.gbQuize.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbQuize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblQuizeNumber;
        private System.Windows.Forms.Label lblQuizText;
    }
}
