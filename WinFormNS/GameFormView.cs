using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FilerNS;

namespace WinFormNS
{
    public partial class GameFormView : WinFormNS.BaseForm, IGameView
    {
        public GameFormView()
        {
            InitializeComponent();
            saveToolStripMenuItem.Enabled = true;
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void UpdateMoveCount(int count)
        {
            MoveCount.Text = count.ToString();
        }

        public void isFinished()
        {
            timer1.Stop();
            Display("You finished in " + TimeLabel.Text + " \r\n with " + MoveCount.Text + " moves");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (int.Parse(MoveCount.Text) == 0)
            {
                TimeLabel.Text = "0 seconds";
                startTheTimer();
            }
            
            if (keyData == Keys.Left)
            {
                GameController.Move(keyData.ToString());
                return true;
            }
            if (keyData == Keys.Right)
            {
                GameController.Move(keyData.ToString());
                return true;
            }
            if (keyData == Keys.Up)
            {
                GameController.Move(keyData.ToString());
                return true;
            }
            if (keyData == Keys.Down)
            {
                GameController.Move(keyData.ToString());
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                timer1.Stop();
                MoveCount.Text = "0";
                timing = 0;
            }
        }

        public void Reset()
        {
            for (int x = this.Controls.Count - 1; x >= 0; x--)
            {
                if (this.Controls[x] is PictureBox) this.Controls[x].Dispose();
            }
            TimeLabel.Text = "0 seconds";
        }

        public void UpdateGame()
        {
            int rowCount = GameController.GetGameHeight();
            int colCount = GameController.GetGameWidth();

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    Parts enumParts = GameController.GetGamePart(col, row);
                    char charParts = (char)enumParts.GetHashCode();

                    if (enumParts == Parts.Wall)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.Wall;//Image.FromFile("../Pics/Wall.jpg");
                        mybox.Refresh();
                    }
                    if (enumParts == Parts.Player)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.Player;//Image.FromFile("../Pics/Player.jpg");
                        mybox.Refresh();
                    }
                    if (enumParts == Parts.Block)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.Block;//Image.FromFile("../Pics/Block.jpg");
                        mybox.Refresh();
                    }
                    if (enumParts == Parts.Goal)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.Goal;//Image.FromFile("../Pics/Goal.jpg");
                        mybox.Refresh();
                    }
                    if (enumParts == Parts.BlockOnGoal)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.BlockOnGoal;//Image.FromFile("../Pics/BlockOnGoal.jpg");
                        mybox.Refresh();
                    }
                    if (enumParts == Parts.PlayerOnGoal)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.PlayerOnGoal;//Image.FromFile("../Pics/PlayerOnGoal.jpg");
                        mybox.Refresh();
                    }
                    if (enumParts == Parts.Empty)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.Empty;//Image.FromFile("../Pics/Empty.jpg");
                        mybox.Refresh();
                    }
                }
            }
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            GameController.RestartGame();
            timer1.Stop();         
        }

        int timing;

        public void startTheTimer()
        {
            timing = 0;
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
                timing += 1;
                TimeLabel.Text = timing + " seconds";            
        }
    }
}
