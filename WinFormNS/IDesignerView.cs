using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormNS
{
    public interface IDesignerView
    {
        void Start();
        void Stop();
        void Display<T>(T message);
        void ShowPic(int width, int height, int row, int col, char part);
        void UpdateLevel();
        void Show();
        void Reset();
    }
}
