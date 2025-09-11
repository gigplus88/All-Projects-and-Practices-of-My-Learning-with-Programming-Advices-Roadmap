using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toc_Game.Properties;

namespace Tic_Tac_Toc_Game
{
    public partial class Form1 : Form
    {
        enum enPlayerTurn {Player1 , Player2 };
        enPlayerTurn Player = enPlayerTurn.Player1;
        enum enWinner  { Player1 , Player2 , Draw , InProgress };
        struct stGameStatue
        {
            public enWinner Winner;
            public bool GameOver ;
            public byte PlayerCount;
        }
        stGameStatue GameStatue;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;

            Pen Pen = new Pen(White);
            Pen.Width = 5;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Triangle;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Triangle;

            e.Graphics.DrawLine(Pen, 420, 75, 420, 390);
            e.Graphics.DrawLine(Pen, 540, 75, 540, 390);
            e.Graphics.DrawLine(Pen, 320, 170, 640, 170);
            e.Graphics.DrawLine(Pen, 320, 280, 640, 280);



        }

        

        void EndGame()
        {
            lbPlayerTurn.Text = "Game Over";

            switch (GameStatue.Winner) 
            {
                case enWinner.Player1 :
                lbWinner.Text = "Player1";
                break;

                case enWinner.Player2 :
                lbWinner.Text = "Player2";
                break;

                default:
                lbWinner.Text = "Draw";
                break;

            }
            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        bool GetValueFor3Turn(Button btn1, Button btn2, Button btn3)
        {
                if (btn1.Tag != null && btn1.Tag.ToString() != "?" &&
                    btn2.Tag != null && btn3.Tag != null &&
                    btn1.Tag.Equals(btn2.Tag) && btn2.Tag.Equals(btn3.Tag))
                //if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())

                {
                btn1.BackColor= Color.BlueViolet;
                btn2.BackColor= Color.BlueViolet;
                btn3.BackColor= Color.BlueViolet;


                if (btn1.Tag.ToString() == "X")
                {
                    GameStatue.Winner = enWinner.Player1;
                    GameStatue.GameOver = true;
                    EndGame();
                    return true;
                }

                else
                {
                    GameStatue.Winner = enWinner.Player2;
                    GameStatue.GameOver = true;
                    EndGame();
                    return true;
                }

            }

            GameStatue.GameOver = false;
            return false;
            
        }



        void CheckWinner()
        {
            if (GetValueFor3Turn(btn1, btn2, btn3))
            {
                return;
            }
            if (GetValueFor3Turn(btn4, btn5, btn6))
            {
                return;
            }
            if (GetValueFor3Turn(btn7, btn8, btn9))
            {
                return;
            }
            if (GetValueFor3Turn(btn1, btn5, btn9))
            {
                return;
            }
            if (GetValueFor3Turn(btn3, btn5, btn7))
            {
                return;
            }
            if (GetValueFor3Turn(btn1, btn4, btn7))
            {
                return;
            }
            if (GetValueFor3Turn(btn2, btn5, btn8))
            {
                return;
            }
            if (GetValueFor3Turn(btn3, btn6, btn9))
            {
                return;
            }
        }

       
        void UpdateGame(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch(Player)
                {
                    case enPlayerTurn.Player1:
                        btn.Image = Resources.X;       
                        btn.Tag = "X";
                        lbPlayerTurn.Text = "Player2";
                        Player = enPlayerTurn.Player2;
                        GameStatue.PlayerCount++;
                        CheckWinner();

                    break;

                    case enPlayerTurn.Player2:
                        btn.Image = Resources.O;
                        btn.Tag = "O";
                        lbPlayerTurn.Text = "Player1";
                        Player = enPlayerTurn.Player1;
                        GameStatue.PlayerCount++;
                        CheckWinner();

                    break;

                }
                

            }

            else if(btn.Tag.ToString() != "?")
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (GameStatue.PlayerCount == 9 )
            {
                GameStatue.GameOver = true;
                GameStatue.Winner = enWinner.Draw;
                EndGame();
            }


        }
        
        private void btRestartGame_Click(object sender, EventArgs e)
        {
            lbPlayerTurn.Text = "Player1";
            lbWinner.Text = "In Progress";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbPlayerTurn.Text = "Player1";
            lbWinner.Text = "In Progress";
            GameStatue.Winner = enWinner.Player1;
            GameStatue.Winner = enWinner.InProgress;
            GameStatue.PlayerCount =0;
            GameStatue.GameOver = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateGame(btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            UpdateGame(btn2);

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            UpdateGame(btn3);

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            UpdateGame(btn4);

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            UpdateGame(btn5);

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            UpdateGame(btn6);

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            UpdateGame(btn7);

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            UpdateGame(btn8);

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            UpdateGame(btn9);

        }

        void Reset(Button btn)
        {
            btn.Tag = "?";
            btn.Image = Resources.question_mark_96;
            btn.BackColor = Color.Black;
        }
        void RestartGame()
        {
            lbPlayerTurn.Text = "Player1";
            lbWinner.Text = "In Progress";
            GameStatue.Winner = enWinner.Player1;
            GameStatue.Winner = enWinner.InProgress;
            GameStatue.PlayerCount =0;
            GameStatue.GameOver = false;

            Reset(btn1);
            Reset(btn2);
            Reset(btn3);
            Reset(btn4);
            Reset(btn5);
            Reset(btn6);
            Reset(btn7);
            Reset(btn8);
            Reset(btn9);


        }
        private void btRestartGame_Click_1(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
