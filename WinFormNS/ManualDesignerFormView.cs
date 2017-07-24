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
    public partial class ManualDesignerFormView : Form, IManualDesignerView
    {
        public ManualDesignerFormView()
        {
            InitializeComponent();
            SetClicks();
        }

        IDesignerController DesignerController;

        public void SetController(IDesignerController designerController)
        {
            DesignerController = designerController;
            DesignerController.BuildStaticLevel();
        }

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
                        c.Text = "-";
                        int newSize = 15;
                        c.Font = new Font(c.Font.FontFamily, newSize);
                        who.Click += new EventHandler(WhoClicked);
                    }
                }
            }
        }

        char symbol = '-';

        private void Wall_Click(object sender, EventArgs e)
        {
            symbol = '#';
        }

        private void Player_Click(object sender, EventArgs e)
        {
            symbol = '@';
        }

        private void Block_Click(object sender, EventArgs e)
        {
            symbol = '$';
        }

        private void Goal_Click(object sender, EventArgs e)
        {
            symbol = '.';
        }

        private void Erase_Click(object sender, EventArgs e)
        {
            symbol = '-';
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

        public void Start()
        {
            SetClicks();
        }

        public void Display<T>(T message)
        {
            MessageBox.Show(message.ToString());
        }

        public void ShowButton(int width, int height, int row, int col, char part)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            /*for (int x = this.Controls.Count - 1; x >= 0; x--)
            {
                if (this.Controls[x] is Button) this.Controls[x].Dispose();
            }*/
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    if (c.Name.StartsWith("btn"))
                    {
                        Button who = c as Button;
                        c.Text = "-";
                        int newSize = 15;
                        c.Font = new Font(c.Font.FontFamily, newSize);
                    }
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DesignerController.SaveDesign();
        }

        private void ManualDesignerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
