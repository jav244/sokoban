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
    public partial class DesignerFormView : WinFormNS.BaseForm, IDesignerView
    {

        public DesignerFormView()
        {
            InitializeComponent();
            //SetClicks();
        }

        public void Start()
        {
            SetClicks();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        char symbol = '-';

        protected void WhoClicked(object sender, EventArgs e)
        {
            PictureBox btnWho = sender as PictureBox;

            string[] output = btnWho.Name.Split('_', '_');

            int x = int.Parse(output[1]);
            int y = int.Parse(output[2]);
            
            DesignerController.AddToLevel(x, y, symbol);
        }

        protected void SetClicks()
        {
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox)
                {
                    if (c.Name.StartsWith("pictureBox"))
                    {
                        PictureBox who = c as PictureBox;
                        who.Click += new EventHandler(WhoClicked);
                    }
                }               
            }
        }



        private void Wall_Click_1(object sender, EventArgs e)
        {
            symbol = '#';
        }

        private void Player_Click_1(object sender, EventArgs e)
        {
            symbol = '@';
        }

        private void Goal_Click(object sender, EventArgs e)
        {
            symbol = '.';
        }

        private void Erase_Click(object sender, EventArgs e)
        {
            symbol = '-';
        }

        private void Block_Click(object sender, EventArgs e)
        {
            symbol = '$';
        }

        public void Reset()
        {
            for (int x = this.Controls.Count - 1; x >= 0; x--)
            {
                if (this.Controls[x] is PictureBox) this.Controls[x].Dispose();
            }
        }

        private void BuildLevel_Click_1(object sender, EventArgs e)
        {
            Reset();
            //Controller.newDesign();
            //Controller.BuildLevel((int)this.WidthInput.Value, (int)this.HeightInput.Value);
        }



        private void Save_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Save_Click_1(object sender, EventArgs e)
        {
            DesignerController.SaveDesign();
        }

        private void DesignerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void LevelBuild_Click(object sender, EventArgs e)
        {
            Reset();
            DesignerController.newDesign((int)this.WidthInput.Value, (int)this.HeightInput.Value);
            WidthInput.Value = 0;
            HeightInput.Value = 0;
        }

        public void UpdateLevel()
        {
            int rowCount = DesignerController.GetHeight();
            int colCount = DesignerController.GetWidth();

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    Parts enumParts = DesignerController.GetPart(col, row);
                    char charParts = (char)enumParts.GetHashCode();

                    if (enumParts == Parts.Wall)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.Wall;//Image.FromFile(@"../Pics/Wall.jpg");
                        mybox.Refresh();
                    }
                    if (enumParts == Parts.Player)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.Player; //Image.FromFile(@"../Pics/Player.jpg");
                        mybox.Refresh();
                    }
                    if (enumParts == Parts.Block)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.Block; //Image.FromFile(@"../Pics/Block.jpg");
                        mybox.Refresh();
                    }
                    if (enumParts == Parts.Goal)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.Goal; //Image.FromFile(@"../Pics/Goal.jpg");
                        mybox.Refresh();
                    }
                    if (enumParts == Parts.BlockOnGoal)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.BlockOnGoal; //Image.FromFile(@"../Pics/BlockOnGoal.jpg");
                        mybox.Refresh();
                    }
                    if (enumParts == Parts.PlayerOnGoal)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.PlayerOnGoal; //Image.FromFile(@"../Pics/PlayerOnGoal.jpg");
                        mybox.Refresh();
                    }
                    if (enumParts == Parts.Empty)
                    {
                        PictureBox mybox = (PictureBox)this.Controls.Find("pictureBox_" + (col + "_" + row), true)[0];
                        mybox.Image.Dispose();
                        mybox.Image = Properties.Resources.Empty; //Image.FromFile(@"../Pics/Empty.jpg");
                        mybox.Refresh();
                    }
                }
            }
        }
    }
}
