using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;

namespace DesignerNS
{
    public class Designer : IDesigner, IFileable
    {
        private string widthTooSmallMessage = "width has to be three or more";
        private string heightTooSmallMessage = "height has to be three or more";
        private string levelAreaTooSmallMessage = "level area needs to be more than 15";
        private string outOfGridMessage = "placement is not within the grid";
        private List<List<Parts>> gridIndex = new List<List<Parts>>();

        private int playerXLocation = -1;
        private int playerYLocation = -1;

        private string LoadLevel;


        //public string WidthTooSmallMessage { get { return widthTooSmallMessage; } }
        //public string HeightTooSmallMessage { get { return heightTooSmallMessage; } }
        //public string LevelAreaTooSmallMessage { get { return levelAreaTooSmallMessage; } }
        //public string OutOfGridMessage { get { return outOfGridMessage; } }
        public List<List<Parts>> GridIndex { get { return gridIndex; } }



        public Parts GetPartAtIndex(int gridX, int gridY)
        {
            return gridIndex[gridY][gridX];
        }

        public int GetLevelHeight()
        {
            return gridIndex.Count;
        }

        public int GetLevelWidth()
        {
            return gridIndex[0].Count;
        }

        public void LevelBuilder(int width, int height)
        {
            if (width <= 2)
            {
                throw new ArgumentException(widthTooSmallMessage);
            }
            if (height <= 2)
            {
                throw new ArgumentException(heightTooSmallMessage);
            }
            if (width * height < 15)
            {
                throw new ArgumentException(levelAreaTooSmallMessage);
            }
            if (width > 15)
            {
                throw new ArgumentException("Width has to be 15 or less");
            }
            if (height > 15)
            {
                throw new ArgumentException("Height has to be 15 or less");
            }

            gridIndex.Clear();

            for (int i = 0; i < height; i++)
            {
                gridIndex.Add(new List<Parts>());
                for (int j = 0; j < width; j++)
                {
                    //string add = ((char)Parts.Wall).ToString();
                    gridIndex[i].Add(Parts.Empty);
                    //((char)Parts.Wall).ToString()
                }
            }
        }

        public string SaveMe(List<List<Parts>> level)
        {
            //return level.ToString();
            string temp = "";

            for (int i = 0; i < gridIndex.Count; i++)
            {
                string result = string.Join(",", gridIndex[i]);
                temp += result;
            }

            return temp;
        }

        public void AddWall(int gridX, int gridY)
        {
            if (checkWithinGrid(gridX, gridY))
            {
                throw new ArgumentException(outOfGridMessage);
            }
            if(GetPartAtIndex(gridX, gridY) == Parts.Player)
            {
                return;
            }
            gridIndex[gridY][gridX] = Parts.Wall;
        }

        public void AddPlayer(int gridX, int gridY)
        {
            if (checkWithinGrid(gridX, gridY))
            {
                throw new ArgumentException(outOfGridMessage);
            }
            if (GetPartAtIndex(gridX, gridY) == Parts.Wall || GetPartAtIndex(gridX, gridY) == Parts.Block || GetPartAtIndex(gridX, gridY) == Parts.BlockOnGoal)
            {
                return;
            }
            if (playerXLocation != -1)
            {
                if (GetPartAtIndex(playerXLocation, playerYLocation) == Parts.PlayerOnGoal)
                {
                    removePlayer(playerXLocation, playerYLocation);
                    AddGoal(playerXLocation, playerYLocation);
                }
                else
                {
                    removePlayer(playerXLocation, playerYLocation);
                }
            }
            if (GetPartAtIndex(gridX, gridY) == Parts.Goal)
            {
                AddPlayerOnGoal(gridX, gridY);
            }
            else
            {
                gridIndex[gridY][gridX] = Parts.Player;
            }

            playerXLocation = gridX;
            playerYLocation = gridY;
        }

        public void AddBlock(int gridX, int gridY)
        {
            if (checkWithinGrid(gridX, gridY))
            {
                throw new ArgumentException(outOfGridMessage);
            }
            if (GetPartAtIndex(gridX, gridY) == Parts.Wall)
            {
                return;
            }
            if (GetPartAtIndex(gridX, gridY) == Parts.BlockOnGoal)
            {
                return;
            }
            if (GetPartAtIndex(gridX, gridY) == Parts.Player)
            {
                return;
            }
            if (GetPartAtIndex(gridX, gridY) == Parts.Goal)
            {
                gridIndex[gridY][gridX] = Parts.BlockOnGoal;
            }            
            else
            {
                gridIndex[gridY][gridX] = Parts.Block;
            }
        }

        public void AddGoal(int gridX, int gridY)
        {
            if (checkWithinGrid(gridX, gridY))
            {
                throw new ArgumentException(outOfGridMessage);
            }
            if (GetPartAtIndex(gridX, gridY) == Parts.Wall)
            {
                return;
            }
            if (GetPartAtIndex(gridX, gridY) == Parts.Block)
            {
                gridIndex[gridY][gridX] = Parts.BlockOnGoal;
            }
            else if (GetPartAtIndex(gridX, gridY) == Parts.Player)
            {
                gridIndex[gridY][gridX] = Parts.PlayerOnGoal;
            }
            if (GetPartAtIndex(gridX, gridY) == Parts.BlockOnGoal)
            {
                return;
            }
            if (GetPartAtIndex(gridX, gridY) == Parts.PlayerOnGoal)
            {
                return;
            }
            else
            {
                gridIndex[gridY][gridX] = Parts.Goal;
            }

        }

        private void AddBlockOnGoal(int gridX, int gridY)
        {
            if (checkWithinGrid(gridX, gridY))
            {
                throw new ArgumentException(outOfGridMessage);
            }
            gridIndex[gridY][gridX] = Parts.BlockOnGoal;
        }

        private void AddPlayerOnGoal(int gridX, int gridY)
        {
            if (checkWithinGrid(gridX, gridY))
            {
                throw new ArgumentException(outOfGridMessage);
            }
            gridIndex[gridY][gridX] = Parts.PlayerOnGoal;
        }

        public void AddEmpty(int gridX, int gridY)
        {
            if (checkWithinGrid(gridX, gridY))
            {
                throw new ArgumentException(outOfGridMessage);
            }
            gridIndex[gridY][gridX] = Parts.Empty;
        }

        private void removePlayer(int x, int y)
        {
            AddEmpty(x, y);
            //gridIndex[y][x] = Parts.Empty;
        }

        private bool checkWithinGrid(int x, int y)
        {
            bool result = false;
            if (x > gridIndex[0].Count || y > gridIndex.Count)
            {
                result = true;
            }
            return result;
        }

        public bool checkValid()
        {
            int block = 0;
            int goal = 0;
            int player = 0;
            bool valid = true;

            foreach (var row in gridIndex)
            {
                foreach (var part in row)
                {
                    if (part == Parts.Block)
                    {
                        block++;
                    }
                    if (part == Parts.Goal)
                    {
                        goal++;
                    }
                    if (part == Parts.Player)
                    {
                        player++;
                    }
                    if (part == Parts.PlayerOnGoal)
                    {
                        player++;
                        goal++;
                    }
                    if (part == Parts.BlockOnGoal)
                    {
                        block++;
                        goal++;
                    }
                }
            }
            if (block == 0)
            {
                throw new ArgumentException("no blocks on grid");
            }
            if (goal == 0)
            {
                throw new ArgumentException("no goals on grid");
            }
            if (player == 0)
            {
                throw new ArgumentException("No player");
            }
            if(player > 1)
            {
                throw new ArgumentException("More than one player");
            }
            if (block > goal)
            {
                throw new ArgumentException("more blocks than goals");
            }
            if (block < goal)
            {
                throw new ArgumentException("more goals than blocks");
            }
            return valid;
        }

        public void deletePlayer()
        {
            if (playerXLocation == -1 && playerYLocation == -1)
            {
                throw new ArgumentException("No player to delete");
            }
            removePlayer(playerXLocation, playerYLocation);
        }

        public string LocateParts(Parts part)
        {
            string xy = "";
            //List<string> Index = new List<string>();
            string Index = "";

            for (int i = 0; i < gridIndex.Count; i++)
            {
                for (int j = 0; j < gridIndex[0].Count; j++)
                {
                    if (gridIndex[i][j] == part)
                    {
                        xy = j.ToString() + "," + i.ToString();
                        Index += part + " at " + xy + ". ";
                    }
                }
            }
            return Index;
        }

        public int GetColumnCount()
        {
            return gridIndex[0].Count;
        }

        public int GetRowCount()
        {
            return gridIndex.Count;
        }

        public Parts WhatsAt(int row, int column)
        {
            return gridIndex[row][column];
        }

        public void Load(string level)
        {
            LoadLevel = level;
            ConvertLevelToGrid();
        }

        private void ConvertLevelToGrid()
        {
            gridIndex.Clear();
            string[] arrayOfRows = LoadLevel.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int height = arrayOfRows.Length;
            for (var i = 0; i < height; i++)
            {
                string row = arrayOfRows[i];
                int width = row.Length;
                char[] columns = new char[width];
                columns = row.ToCharArray();
                gridIndex.Add(new List<Parts>());
                for (var j = 0; j < width; j++)
                {
                    char element = columns[j];
                    switch (element)
                    {
                        case '#':
                            gridIndex[i].Add(Parts.Wall);
                            break;
                        case '-':
                            gridIndex[i].Add(Parts.Empty);
                            break;
                        case '@':
                            gridIndex[i].Add(Parts.Player);
                            playerXLocation = j;
                            playerYLocation = i;
                            break;
                        case '.':
                            gridIndex[i].Add(Parts.Goal);
                            break;
                        case '$':
                            gridIndex[i].Add(Parts.Block);
                            break;
                        case '*':
                            gridIndex[i].Add(Parts.BlockOnGoal);
                            break;
                        case '+':
                            gridIndex[i].Add(Parts.PlayerOnGoal);
                            break;
                    }
                }
            }
        }

    }
}
