using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;

namespace GameNS
{
    public class Position
    {
        public int X;
        public int Y;
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Position Step(Direction moveDirection)
        {
            int xOffset = 0;
            int yOffset = 0;
            switch (moveDirection)
            {
                case Direction.Left:
                    xOffset = -1;
                    break;
                case Direction.Right:
                    xOffset = 1;
                    break;
                case Direction.Up:
                    yOffset = -1;
                    break;
                case Direction.Down:
                    yOffset = 1;
                    break;
            }
            return new Position(X + xOffset, Y + yOffset);
        }
    }

    public class Game :IGame, IFileable
    {
        protected int MoveCount { get; private set; }
        protected int GetRowCallCount { get; private set; }
        protected int GetColumnCallCount { get; private set; }
        protected int WhatsAtCallCount { get; private set; }
        protected int PlayerX { get; private set; }
        protected int PlayerY { get; private set; }

        protected List<int> RowsChecked = new List<int>();
        protected List<int> ColumnsChecked = new List<int>();

        protected string Level;
        protected List<List<Parts>> Grid = new List<List<Parts>>();

        public int GetColumnCount()
        {
            string[] rows = Level.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int columns = rows[0].Length;
            return columns;
        }
        public int GetRowCount()
        {
            string[] rows = Level.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            return rows.Length;
        }
        public int GetMoveCount()
        {
            return MoveCount;
        }

        public bool IsFinished()
        {
            bool result = true;

            int height = GetRowCount();
            int width = GetColumnCount();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    char part = (char)WhatsAt(i, j);
                    if (part == (char)Parts.Block)
                    {
                        result = false;                        
                    }
                }
            }
            return result;
        }

        public void Load(string newLevel)
        {
            Level = newLevel;
            ConvertLevelToGrid();
        }
        protected void ConvertLevelToGrid()
        {
            Grid.Clear();
            MoveCount = 0;
            string[] arrayOfRows = Level.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int height = arrayOfRows.Length;
            for (var i = 0; i < height; i++)
            {
                string row = arrayOfRows[i];
                int width = row.Length;
                char[] columns = new char[width];
                columns = row.ToCharArray();
                Grid.Add(new List<Parts>());
                for (var j = 0; j < width; j++)
                {
                    char element = columns[j];
                    switch (element)
                    {
                        case '#':
                            Grid[i].Add(Parts.Wall);
                            break;
                        case '-':
                            Grid[i].Add(Parts.Empty);
                            break;
                        case '@':
                            Grid[i].Add(Parts.Player);
                            break;
                        case '.':
                            Grid[i].Add(Parts.Goal);
                            break;
                        case '$':
                            Grid[i].Add(Parts.Block);
                            break;
                        case '*':
                            Grid[i].Add(Parts.BlockOnGoal);
                            break;
                        case '+':
                            Grid[i].Add(Parts.PlayerOnGoal);
                            break;
                    }
                }
            }
        }
        public void MoveUp()
        {
            Move(Direction.Up);
        }
        public void MoveDown()
        {
            Move(Direction.Down);
        }
        public void MoveLeft()
        {
            Move(Direction.Left);
        }
        public void MoveRight()
        {
            Move(Direction.Right);
        }
        public void Move(Direction moveDirection)
        {
            MoveCount++;
            GetPlayerLocation();
            if (WhatsAt(PlayerY, PlayerX) == Parts.Player || WhatsAt(PlayerY, PlayerX) == Parts.PlayerOnGoal)
            {
                Position currentPosition = new Position(PlayerX, PlayerY);
                Position destPosition = currentPosition.Step(moveDirection);

                Parts oldPart = WhatsAt(currentPosition.Y, currentPosition.X);
                Parts newPart = WhatsAt(destPosition.Y, destPosition.X);

                if (newPart == Parts.Empty || newPart == Parts.Goal && newPart != Parts.Wall)
                {
                    if (oldPart == Parts.PlayerOnGoal && newPart == Parts.Empty)
                    {
                        Grid[destPosition.Y][destPosition.X] = Parts.Player;
                        Grid[currentPosition.Y][currentPosition.X] = Parts.Goal;
                    }
                    else if (oldPart == Parts.PlayerOnGoal && newPart == Parts.Goal)
                    {
                        Grid[destPosition.Y][destPosition.X] = Parts.PlayerOnGoal;
                        Grid[currentPosition.Y][currentPosition.X] = Parts.Goal;
                    }
                    else if (newPart == Parts.Goal)
                    {
                        Grid[destPosition.Y][destPosition.X] = Parts.PlayerOnGoal;
                        Grid[currentPosition.Y][currentPosition.X] = Parts.Empty;
                    }
                    else
                    {
                        Grid[destPosition.Y][destPosition.X] = Parts.Player;
                        Grid[currentPosition.Y][currentPosition.X] = Parts.Empty;
                    }
                }

                /* BLOCK MOVEMENT */
                else if (newPart == Parts.Block
                        || newPart == Parts.BlockOnGoal)
                {
                    Parts oldBlockPart = WhatsAt(destPosition.Y, destPosition.X);
                    Position newBlockPos = destPosition.Step(moveDirection);
                    Parts newBlockPart = WhatsAt(newBlockPos.Y, newBlockPos.X);

                    /* player -> block -> empty */
                    if (oldPart == Parts.Player
                        && newPart == Parts.Block
                        && newBlockPart == Parts.Empty)
                    {
                        /* empty -> player -> block */
                        Grid[currentPosition.Y][currentPosition.X] = Parts.Empty;
                        Grid[destPosition.Y][destPosition.X] = Parts.Player;
                        Grid[newBlockPos.Y][newBlockPos.X] = Parts.Block;
                    }
                    /* player -> block -> goal */
                    else if (oldPart == Parts.Player
                            && newPart == Parts.Block
                            && newBlockPart == Parts.Goal)
                    {
                        /* empty -> player -> blockOnGoal */
                        Grid[currentPosition.Y][currentPosition.X] = Parts.Empty;
                        Grid[destPosition.Y][destPosition.X] = Parts.Player;
                        Grid[newBlockPos.Y][newBlockPos.X] = Parts.BlockOnGoal;
                    }
                    /* player -> blockOnGoal -> empty */
                    else if (oldPart == Parts.Player
                            && newPart == Parts.BlockOnGoal
                            && newBlockPart == Parts.Empty)
                    {
                        /* empty -> playerOnGoal -> block */
                        Grid[currentPosition.Y][currentPosition.X] = Parts.Empty;
                        Grid[destPosition.Y][destPosition.X] = Parts.PlayerOnGoal;
                        Grid[newBlockPos.Y][newBlockPos.X] = Parts.Block;
                    }

                    /* player -> blockOnGoal -> goal */
                    else if (oldPart == Parts.Player
                            && newPart == Parts.BlockOnGoal
                            && newBlockPart == Parts.Goal)
                    {
                        /* empty -> playerOnGoal -> blockOnGoal */
                        Grid[currentPosition.Y][currentPosition.X] = Parts.Empty;
                        Grid[destPosition.Y][destPosition.X] = Parts.PlayerOnGoal;
                        Grid[newBlockPos.Y][newBlockPos.X] = Parts.BlockOnGoal;
                    }

                    /* playerOnGoal -> block -> empty */
                    else if (oldPart == Parts.PlayerOnGoal
                            && newPart == Parts.Block
                            && newBlockPart == Parts.Empty)
                    {
                        /* goal -> player -> block */
                        Grid[currentPosition.Y][currentPosition.X] = Parts.Goal;
                        Grid[destPosition.Y][destPosition.X] = Parts.Player;
                        Grid[newBlockPos.Y][newBlockPos.X] = Parts.Block;
                    }
                    /* playerOnGoal -> block -> goal */
                    else if (oldPart == Parts.PlayerOnGoal
                            && newPart == Parts.Block
                            && newBlockPart == Parts.Goal)
                    {
                        /* goal -> player -> blockOnGoal */
                        Grid[currentPosition.Y][currentPosition.X] = Parts.Goal;
                        Grid[destPosition.Y][destPosition.X] = Parts.Player;
                        Grid[newBlockPos.Y][newBlockPos.X] = Parts.BlockOnGoal;
                    }
                    /* playerOnGoal -> blockOnGoal -> empty */
                    else if (oldPart == Parts.PlayerOnGoal
                            && newPart == Parts.BlockOnGoal
                            && newBlockPart == Parts.Empty)
                    {
                        /* goal -> playerOnGoal -> block */
                        Grid[currentPosition.Y][currentPosition.X] = Parts.Goal;
                        Grid[destPosition.Y][destPosition.X] = Parts.PlayerOnGoal;
                        Grid[newBlockPos.Y][newBlockPos.X] = Parts.Block;
                    }
                    /* playerOnGoal -> blockOnGoal -> goal */
                    else if (oldPart == Parts.PlayerOnGoal
                            && newPart == Parts.BlockOnGoal
                            && newBlockPart == Parts.Goal)
                    {
                        /* goal -> playerOnGoal -> blockOnGoal */
                        Grid[currentPosition.Y][currentPosition.X] = Parts.Goal;
                        Grid[destPosition.Y][destPosition.X] = Parts.PlayerOnGoal;
                        Grid[newBlockPos.Y][newBlockPos.X] = Parts.BlockOnGoal;
                    }
                }
            }
        }
        public void GetPlayerLocation()
        {
            PlayerX = 0;
            PlayerY = 0;

            for (int i = 0; i < Grid.Count; i++)
            {
                List<Parts> row = Grid[i];
                if (row.IndexOf(Parts.Player) != -1)
                {
                    PlayerY = i;
                    for (int j = 0; j < Grid[i].Count; j++)
                    {
                        PlayerX = row.IndexOf(Parts.Player);
                    }
                }
                else if (row.IndexOf(Parts.PlayerOnGoal) != -1)
                {
                    PlayerY = i;
                    for (int j = 0; j < Grid[i].Count; j++)
                    {
                        PlayerX = row.IndexOf(Parts.PlayerOnGoal);
                    }
                }
            }
        }

        public void Restart()
        {
            ConvertLevelToGrid();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public Parts WhatsAt(int row, int column)
        {
            WhatsAtCallCount++;
            RowsChecked.Add(row);
            ColumnsChecked.Add(column);
            //char part = (char)Grid[row][column];
            //return (Parts)(int)part;
            return Grid[row][column];
        }
    }
}
