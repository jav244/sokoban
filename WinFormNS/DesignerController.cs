using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;
using DesignerNS;
using GameNS;

namespace WinFormNS
{
    class DesignerController: IDesignerController
    {
        
        //IManualDesignerView DesignerView;
        //IDesignerButtonView DesignerView;
        IDesignerView DesignerView;
        IFilerView FilerView;
        IFiler Filer;
        IDesigner Designer;
        IFileable DesignerFileable;

        //public DesignerController(IManualDesignerView designerView, IFilerView filerView, IFiler filer, IDesigner designer, IFileable designerFileable)
        //public DesignerController(IDesignerButtonView designerView, IFilerView filerView, IFiler filer, IDesigner designer, IFileable designerFileable)
        public DesignerController(IDesignerView designerView, IFilerView filerView, IFiler filer, IDesigner designer, IFileable designerFileable)
        {
            FilerView = filerView;
            DesignerView = designerView;
            Filer = filer;
            Designer = designer;
            DesignerFileable = designerFileable;
        }

        public void SaveDesign()
        {
            try
            {
                if (Designer.checkValid())
                {
                    string file = FilerView.Save();
                    Filer.Save(file, DesignerFileable);
                }
            }
            catch (ArgumentException e)
            {
                DesignerView.Display(e.Message);
            }


        }

        public void showDesign()
        {
            DesignerView.Reset();
            DesignerView.Show();
        }

        public void ResetDesign()
        {
            DesignerView.Reset();
        }

        public void BuildStaticLevel()
        {
            try
            {
                Designer.LevelBuilder(6, 6);
            }
            catch (ArgumentOutOfRangeException e)
            {
                DesignerView.Display(e.Message);
            }
        }
        private void BuildLevel(int width, int height, string id)
        {
            try
            {
                if (id == "New")
                {
                    Designer.LevelBuilder(width, height);
                }

                DesignerView.Show();

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        char part = (char)DesignerFileable.WhatsAt(i, j);
                        DesignerView.ShowPic(width, height, i, j, part);
                    }
                }
                DesignerView.Start();

            }
            catch (ArgumentException e)
            {
                DesignerView.Display(e.Message);
            }
        }

        private void BuildButtonLevel(int width, int height, string id)
        {
            try
            {
                if (id == "New")
                {
                    Designer.LevelBuilder(width, height);
                }

                DesignerView.Show();

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        char part = (char)DesignerFileable.WhatsAt(i, j);
                        //DesignerView.ShowButton(width, height, i, j, part);
                    }
                }
                DesignerView.Start();

            }
            catch (ArgumentException e)
            {
                DesignerView.Display(e.Message);
            }
        }

        public void AddToLevel(int x, int y, char id)
        {
            try
            {
                switch (id)
                {
                    case '#':
                        Designer.AddWall(x, y);

                        break;
                    case '@':
                        Designer.AddPlayer(x, y);

                        break;
                    case '$':
                        Designer.AddBlock(x, y);

                        break;
                    case '.':
                        Designer.AddGoal(x, y);

                        break;
                    case '-':
                        Designer.AddEmpty(x, y);

                        break;
                }
                DesignerView.UpdateLevel();
            }
            catch (ArgumentException e)
            {
                DesignerView.Display(e.Message);
            }
        }

        public Parts GetPart(int x, int y)
        {
            return DesignerFileable.WhatsAt(y, x);
        }

        public int GetWidth()
        {
            return DesignerFileable.GetColumnCount();
        }

        public int GetHeight()
        {
            return DesignerFileable.GetRowCount();
        }

        public void LoadDesign()
        {
            try
            {
                string[] newLevel = FilerView.Load();
                string rawLevel = newLevel[1];
                Filer.SetString(rawLevel);
                string level = Filer.Load();
                //DesignerView.Display(level);
                Designer.Load(level);
                int rows = DesignerFileable.GetRowCount();
                int cols = DesignerFileable.GetColumnCount();             
                BuildLevel(cols, rows, "Edit");
                DesignerView.UpdateLevel();
            }
            catch (ArgumentException e)
            {
                DesignerView.Display(e.Message);
            }

        }

        public void newDesign(int width, int height)
        {
            try
            {
                BuildLevel(width, height, "New");
            }
            catch (ArgumentException e)
            {
                DesignerView.Display(e.Message);
            }

        }

        public void newButtonDesign(int width, int height)
        {
            try
            {
                BuildButtonLevel(width, height, "New");
            }
            catch (ArgumentException e)
            {
                DesignerView.Display(e.Message);
            }

        }
    }
}
