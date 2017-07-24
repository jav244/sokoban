using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;

namespace WinFormNS
{
    public interface IGameController
    {
        void SaveGame();
        void LoadGame();
        Parts GetGamePart(int x, int y);
        int GetGameWidth();
        int GetGameHeight();
        void Move(string moveId);
        void ResetGame();
        void RestartGame();
    }
}
