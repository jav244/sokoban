using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;
using DesignerNS;
using GameNS;
using System.Windows.Forms;

namespace WinFormNS
{
    class GameController : IGameController
    {
        IGameView GameView;
        IFilerView FilerView;
        IFiler Filer;
        IGame Game;
        IFileable GameFileable;

        public GameController(IGameView gameView, IFilerView filerView, IFiler filer, IGame game, IFileable gameFileable)
        {
            GameView = gameView;
            FilerView = filerView;
            Filer = filer;
            Game = game;
            GameFileable = gameFileable;
        }
       
        public void RestartGame()
        {
            GameView.Reset();
            Game.Restart();
            int rows = GameFileable.GetRowCount();
            int cols = GameFileable.GetColumnCount();
            BuildGameLevel(cols, rows);
            GameView.UpdateMoveCount(0);
        }

        public void ResetGame()
        {
            GameView.Reset();
        }


        public void SaveGame()
        {
            try
            {

                string file = FilerView.Save();
                Filer.Save(file, GameFileable);

            }
            catch (ArgumentException e)
            {
                GameView.Display(e.Message);
            }
        }

        public void BuildGameLevel(int width, int height)
        {
            int check = 0;
            try
            {
                if(check != 0)
                {
                    GameView.Start();
                }
                GameView.Show();

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        char part = (char)GameFileable.WhatsAt(i, j);
                        GameView.ShowPic(width, height, i, j, part);
                    }
                }
                check++;
            }
            catch (ArgumentException e)
            {
                GameView.Display(e.Message);
            }
        }

        public Parts GetGamePart(int x, int y)
        {
            return GameFileable.WhatsAt(y, x);
        }

        public int GetGameWidth()
        {
            return GameFileable.GetColumnCount();
        }

        public int GetGameHeight()
        {
            return GameFileable.GetRowCount();
        }

        public void Move(string moveId)
        {
            try
            {
                switch (moveId)
                {
                    case "Left":
                        Game.MoveLeft();

                        break;
                    case "Right":
                        Game.MoveRight();

                        break;
                    case "Down":
                        Game.MoveDown();

                        break;
                    case "Up":
                        Game.MoveUp();

                        break;
                }
                GameView.UpdateGame();
                GameView.UpdateMoveCount(Game.GetMoveCount());
                if (Game.IsFinished())
                {
                    GameView.isFinished();
                    RestartGame();
                    GameView.UpdateGame();
                    GameView.UpdateMoveCount(0);
                }
            }
            catch (ArgumentException e)
            {
                GameView.Display(e.Message);
            }
        }



        public void LoadGame()
        {
            try
            {
                string[] newLevel = FilerView.Load();
                string rawLevel = newLevel[1];
                Filer.SetString(rawLevel);
                string level = Filer.Load();
                Game.Load(level);
                int rows = GameFileable.GetRowCount();
                int cols = GameFileable.GetColumnCount();
                BuildGameLevel(cols, rows);
            }
            catch (ArgumentException e)
            {
                GameView.Display(e.Message);
            }
        }
    }
}
