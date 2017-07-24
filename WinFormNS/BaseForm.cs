using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilerNS;

namespace WinFormNS
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        protected static IGameController GameController;
        protected static IDesignerController DesignerController;

        public void SetControllers(IGameController gameController, IDesignerController designerController)
        {
            GameController = gameController;
            DesignerController = designerController;
        }

        public void Display<T>(T message)
        {
            MessageBox.Show(message.ToString());
        }

        protected void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameController.ResetGame();
            GameController.LoadGame();
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesignerController.ResetDesign();
            DesignerController.showDesign();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesignerController.ResetDesign();
            DesignerController.LoadDesign();
            
        }

        public void ShowPic(int width, int height, int row, int col, char part)
        {
            int formWidth = Size.Width;
            int formHeight = Size.Height;
            int iconSize = 35;
            int xStartPos = (formWidth - (width * iconSize)) / 2;
            int yStartPos = (formHeight - (height * iconSize)) / 2;
            int xloc = (col * iconSize) + xStartPos;
            int yloc = (row * iconSize) + yStartPos;


            PictureBox pb = new PictureBox();
            switch (part)
            {
                case (char)Parts.Wall:
                    pb.Image = Image.FromFile(@"../Pics/Wall.jpg");
                    break;
                case (char)Parts.Player:
                    pb.Image = Image.FromFile(@"../Pics/Player.jpg");
                    break;
                case (char)Parts.Block:
                    pb.Image = Image.FromFile(@"../Pics/Block.jpg");
                    break;
                case (char)Parts.Goal:
                    pb.Image = Image.FromFile(@"../Pics/Goal.jpg");
                    break;
                case (char)Parts.BlockOnGoal:
                    pb.Image = Image.FromFile(@"../Pics/BlockOnGoal.jpg");
                    break;
                case (char)Parts.PlayerOnGoal:
                    pb.Image = Image.FromFile(@"../Pics/PlayerOnGoal.jpg");
                    break;
                case (char)Parts.Empty:
                    pb.Image = Image.FromFile(@"../Pics/Empty.jpg");
                    break;
            }

            pb.Name = "pictureBox_" + (col + "_" + row);
            pb.Location = new Point(row, col);
            pb.Size = new Size(iconSize, iconSize);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Location = new Point(xloc, yloc);
            Controls.Add(pb);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameController.SaveGame();
        }
       
    }
}
