using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;

namespace WinFormNS
{
    public interface IDesignerController
    {
        void SaveDesign();
        void showDesign();
        void ResetDesign();
        void BuildStaticLevel();
        void AddToLevel(int x, int y, char id);
        Parts GetPart(int x, int y);
        int GetWidth();
        int GetHeight();
        void LoadDesign();
        void newDesign(int width, int height);
        void newButtonDesign(int width, int height);
    }
}
