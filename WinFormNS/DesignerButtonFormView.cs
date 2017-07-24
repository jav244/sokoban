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
    public partial class DesignerButtonFormView : BaseForm, IDesignerButtonView
    {
        public DesignerButtonFormView()
        {
            InitializeComponent();
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
            Button btnWho = sender as Button;
            string[] output = btnWho.Name.Split('_', '_');

            int x = int.Parse(output[1]);
            int y = int.Parse(output[2]);

            DesignerController.AddToLevel(x, y, symbol);
        }

        protected void SetClicks()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    if (c.Name.StartsWith("btn"))
                    {
                        Button who = c as Button;
                        who.Click += new EventHandler(WhoClicked);
                    }
                }
            }
        }





        private void Wall_Click_1(object sender, EventArgs e)
        {
            symbol = '#';
            this.Text = "hey";
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
                if (this.Controls[x] is Button)
                {
                    if (this.Controls[x].Name.StartsWith("btn"))
                    {
                        this.Controls[x].Dispose();
                    }
                } 
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
                        Button btn = (Button)this.Controls.Find("btn_" + (col + "_" + row), true)[0];
                        btn.Text = ((char)Parts.Wall).ToString();
                    }
                    if (enumParts == Parts.Player)
                    {
                        Button btn = (Button)this.Controls.Find("btn_" + (col + "_" + row), true)[0];
                        btn.Text = ((char)Parts.Player).ToString();
                    }
                    if (enumParts == Parts.Block)
                    {
                        Button btn = (Button)this.Controls.Find("btn_" + (col + "_" + row), true)[0];
                        btn.Text = ((char)Parts.Block).ToString();
                    }
                    if (enumParts == Parts.Goal)
                    {
                        Button btn = (Button)this.Controls.Find("btn_" + (col + "_" + row), true)[0];
                        btn.Text = ((char)Parts.Goal).ToString();
                    }
                    if (enumParts == Parts.BlockOnGoal)
                    {
                        Button btn = (Button)this.Controls.Find("btn_" + (col + "_" + row), true)[0];
                        btn.Text = ((char)Parts.BlockOnGoal).ToString();
                    }
                    if (enumParts == Parts.PlayerOnGoal)
                    {
                        Button btn = (Button)this.Controls.Find("btn_" + (col + "_" + row), true)[0];
                        btn.Text = ((char)Parts.PlayerOnGoal).ToString();
                    }
                    if (enumParts == Parts.Empty)
                    {
                        Button btn = (Button)this.Controls.Find("btn_" + (col + "_" + row), true)[0];
                        btn.Text = ((char)Parts.Empty).ToString();
                    }
                }
            }
        }

        public void ShowButton(int width, int height, int row, int col, char part)
        {
            int formWidth = Size.Width;
            int formHeight = Size.Height;
            int iconSize = 50;
            int xStartPos = (formWidth - (width * iconSize)) / 2;
            int yStartPos = (formHeight - (height * iconSize)) / 2;
            int xloc = (col * iconSize) + xStartPos;
            int yloc = (row * iconSize) + yStartPos;


            Button btnNew = new Button();
            btnNew.Name = "btn_" + col + "_" + row;
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = part.ToString();
            btnNew.Visible = true;
            btnNew.Location = new Point(xloc, yloc);

            Controls.Add(btnNew);

        }

        private void LevelBuild_Click_1(object sender, EventArgs e)
        {
            
        }

        private void LevelBuild_Click_2(object sender, EventArgs e)
        {
            Reset();
            DesignerController.newButtonDesign((int)this.WidthInput.Value, (int)this.HeightInput.Value);
            WidthInput.Value = 0;
            HeightInput.Value = 0;
        }

        private void Wall_Click(object sender, EventArgs e)
        {
            symbol = '#';
        }

        private void Player_Click(object sender, EventArgs e)
        {
            symbol = '@';
        }

        private void Block_Click_1(object sender, EventArgs e)
        {
            symbol = '$';
        }

        private void Goal_Click_1(object sender, EventArgs e)
        {
            symbol = '.';
        }

        private void Erase_Click_1(object sender, EventArgs e)
        {
            symbol = '-';
        }

        private void Save_Click_2(object sender, EventArgs e)
        {
            DesignerController.SaveDesign();
        }

        private void DesignerButtonFormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
