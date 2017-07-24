using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormNS
{
    public partial class FilerFormView : WinFormNS.BaseForm, IFilerView
    {
        public FilerFormView()
        {
            InitializeComponent();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public string Save()
        {
            string fileName = "";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "save level design";
            saveFile.InitialDirectory = @"C:\Desktop";
            saveFile.FileName = "sokoban lvl";
            saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if(saveFile.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFile.FileName;
                return fileName;
            }
            else
            {
                throw new ArgumentException("to save a file you must pick a path");
            }


        }

        public new string[] Load()
        {
            OpenFileDialog loadFile = new OpenFileDialog();

            string[] newLevel = { "", "" };
            if(loadFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = loadFile.FileName;
                string rawLevel = System.IO.File.ReadAllText(fileName);
                newLevel[0] = fileName;
                newLevel[1] = rawLevel;
                return newLevel;
            }
            else
            {
                throw new ArgumentException("pick a file to load");
            }
        }
    }
}
