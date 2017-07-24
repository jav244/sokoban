using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormNS
{
    public interface IManualDesignerView
    {
        void Start();
        //void Stop();
        void Display<T>(T message);
        //void ShowButton(int width, int height, int row, int col, char part);
        void UpdateLevel();
        void Show();
        void Reset();
        void SetController(IDesignerController designerController);
    }
}
