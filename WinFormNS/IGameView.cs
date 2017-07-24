using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormNS
{
    public interface IGameView
    {
        void Start();
        void Stop();
        void Display<T>(T message);
        void Show();
        void ShowPic(int width, int height, int row, int col, char part);
        void UpdateGame();
        void UpdateMoveCount(int count);
        void Reset();
        void isFinished();
    }
}
