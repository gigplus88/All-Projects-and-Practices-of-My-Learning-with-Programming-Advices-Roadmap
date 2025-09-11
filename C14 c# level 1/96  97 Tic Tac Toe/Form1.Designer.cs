namespace Tic_Tac_Toc_Game
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbPlayerTurn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbWinner = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btRestartGame = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poor Richard", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(40, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turn";
            // 
            // lbPlayerTurn
            // 
            this.lbPlayerTurn.AutoSize = true;
            this.lbPlayerTurn.Font = new System.Drawing.Font("Poor Richard", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayerTurn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbPlayerTurn.Location = new System.Drawing.Point(40, 189);
            this.lbPlayerTurn.Name = "lbPlayerTurn";
            this.lbPlayerTurn.Size = new System.Drawing.Size(136, 47);
            this.lbPlayerTurn.TabIndex = 1;
            this.lbPlayerTurn.Tag = "";
            this.lbPlayerTurn.Text = "Player1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poor Richard", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(40, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 47);
            this.label2.TabIndex = 2;
            this.label2.Text = "Winner";
            // 
            // lbWinner
            // 
            this.lbWinner.AutoSize = true;
            this.lbWinner.Font = new System.Drawing.Font("Poor Richard", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWinner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbWinner.Location = new System.Drawing.Point(40, 307);
            this.lbWinner.Name = "lbWinner";
            this.lbWinner.Size = new System.Drawing.Size(136, 47);
            this.lbWinner.TabIndex = 3;
            this.lbWinner.Text = "Player1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poor Richard", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(324, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(459, 68);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tic-Tac-Toe Game";
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.Black;
            this.btn1.Font = new System.Drawing.Font("Poor Richard", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.ForeColor = System.Drawing.Color.White;
            this.btn1.Image = global::Tic_Tac_Toc_Game.Properties.Resources.question_mark_96;
            this.btn1.Location = new System.Drawing.Point(382, 90);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(98, 114);
            this.btn1.TabIndex = 15;
            this.btn1.Tag = "?";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Poor Richard", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(324, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(459, 68);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tic-Tac-Toe Game";
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.Black;
            this.btn2.Font = new System.Drawing.Font("Poor Richard", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.ForeColor = System.Drawing.Color.White;
            this.btn2.Image = global::Tic_Tac_Toc_Game.Properties.Resources.question_mark_96;
            this.btn2.Location = new System.Drawing.Point(511, 90);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(98, 114);
            this.btn2.TabIndex = 16;
            this.btn2.Tag = "?";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.Black;
            this.btn3.Font = new System.Drawing.Font("Poor Richard", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.ForeColor = System.Drawing.Color.White;
            this.btn3.Image = global::Tic_Tac_Toc_Game.Properties.Resources.question_mark_96;
            this.btn3.Location = new System.Drawing.Point(645, 90);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(98, 114);
            this.btn3.TabIndex = 17;
            this.btn3.Tag = "?";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btRestartGame
            // 
            this.btRestartGame.BackColor = System.Drawing.Color.Black;
            this.btRestartGame.Font = new System.Drawing.Font("Poor Richard", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRestartGame.ForeColor = System.Drawing.Color.White;
            this.btRestartGame.Location = new System.Drawing.Point(48, 391);
            this.btRestartGame.Name = "btRestartGame";
            this.btRestartGame.Size = new System.Drawing.Size(128, 59);
            this.btRestartGame.TabIndex = 14;
            this.btRestartGame.Text = "Restart Game";
            this.btRestartGame.UseVisualStyleBackColor = false;
            this.btRestartGame.Click += new System.EventHandler(this.btRestartGame_Click_1);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.Black;
            this.btn4.Font = new System.Drawing.Font("Poor Richard", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.ForeColor = System.Drawing.Color.White;
            this.btn4.Image = global::Tic_Tac_Toc_Game.Properties.Resources.question_mark_96;
            this.btn4.Location = new System.Drawing.Point(382, 227);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(98, 114);
            this.btn4.TabIndex = 18;
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.Black;
            this.btn5.Font = new System.Drawing.Font("Poor Richard", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.ForeColor = System.Drawing.Color.White;
            this.btn5.Image = global::Tic_Tac_Toc_Game.Properties.Resources.question_mark_96;
            this.btn5.Location = new System.Drawing.Point(511, 227);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(98, 114);
            this.btn5.TabIndex = 19;
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.Black;
            this.btn6.Font = new System.Drawing.Font("Poor Richard", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.ForeColor = System.Drawing.Color.White;
            this.btn6.Image = global::Tic_Tac_Toc_Game.Properties.Resources.question_mark_96;
            this.btn6.Location = new System.Drawing.Point(645, 227);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(98, 114);
            this.btn6.TabIndex = 20;
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.Black;
            this.btn7.Font = new System.Drawing.Font("Poor Richard", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.ForeColor = System.Drawing.Color.White;
            this.btn7.Image = global::Tic_Tac_Toc_Game.Properties.Resources.question_mark_96;
            this.btn7.Location = new System.Drawing.Point(382, 368);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(98, 114);
            this.btn7.TabIndex = 21;
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.Black;
            this.btn8.Font = new System.Drawing.Font("Poor Richard", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.ForeColor = System.Drawing.Color.White;
            this.btn8.Image = global::Tic_Tac_Toc_Game.Properties.Resources.question_mark_96;
            this.btn8.Location = new System.Drawing.Point(511, 368);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(98, 114);
            this.btn8.TabIndex = 22;
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.Black;
            this.btn9.Font = new System.Drawing.Font("Poor Richard", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.ForeColor = System.Drawing.Color.White;
            this.btn9.Image = global::Tic_Tac_Toc_Game.Properties.Resources.question_mark_96;
            this.btn9.Location = new System.Drawing.Point(645, 368);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(98, 114);
            this.btn9.TabIndex = 23;
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(921, 534);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btRestartGame);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbWinner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbPlayerTurn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPlayerTurn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbWinner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btRestartGame;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
    }
}

