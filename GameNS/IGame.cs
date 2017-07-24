﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNS
{
    public enum Direction { Up, Down, Left, Right };
    public interface IGame
    {
        //void Move(Direction moveDirection);
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        int GetMoveCount();
        void Undo();
        void Restart();
        bool IsFinished();
        void Load(string newLevel);
    }
}
