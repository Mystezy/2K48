using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _2K48.Classы;

namespace _2K48
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private Game MyGame;

        public GamePage()
        {
            InitializeComponent();
            MyGame = new Game();
            MyGame.LoadGame();
            Painter();
            Focus();
        }
        
        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("MainMenuPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            MyGame.NewGame();
            MyGame.SaveGame();
            Painter();
            Focus();
        }

        public void Painter()
        {
            Score.Text = "Score\n" + MyGame.Score.ToString();
            Best.Text = "Best\n" + MyGame.BestScore.ToString();

            Image[] Images = new Image[16] { Im1, Im2, Im3, Im4, Im5, Im6, Im7, Im8, Im9, Im10, Im11, Im12, Im13, Im14, Im15, Im16, };
            TextBox[] TB = new TextBox[16] { tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tb15, tb16, };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Images[i * 4 + j].Source = MyGame.Board[i, j].Image;
                    if (MyGame.Board[i, j].Count != 0)
                        TB[i * 4 + j].Text = MyGame.Board[i, j].Count.ToString();
                    else
                        TB[i * 4 + j].Text = "";
                }
            }
        }

        public void Page_KeyDown(object sender, KeyEventArgs e)
        {
            int[,] Board = new int[4, 4];
            switch (e.Key)
            {
                case Key.Right:
                    Mass(ref Board);
                    MyGame.RightMove();
                    if (CheckBoard(Board))
                        MyGame.Randomize();
                    break;
                case Key.D:
                    Mass(ref Board);
                    MyGame.RightMove();
                    if (CheckBoard(Board))
                        MyGame.Randomize();
                    break;

                case Key.Left:
                    Mass(ref Board);
                    MyGame.LeftMove();
                    if (CheckBoard(Board))
                        MyGame.Randomize();
                    break;
                case Key.A:
                    Mass(ref Board);
                    MyGame.LeftMove();
                    if (CheckBoard(Board))
                        MyGame.Randomize();
                    break;

                case Key.Down:
                    Mass(ref Board);
                    MyGame.DownMove();
                    if (CheckBoard(Board))
                        MyGame.Randomize();
                    break;
                case Key.S:
                    Mass(ref Board);
                    MyGame.DownMove();
                    if (CheckBoard(Board))
                        MyGame.Randomize();
                    break;

                case Key.Up:
                    Mass(ref Board);
                    MyGame.UpMove();
                    if (CheckBoard(Board))
                        MyGame.Randomize();
                    break;
                case Key.W:
                    Mass(ref Board);
                    MyGame.UpMove();
                    if (CheckBoard(Board))
                        MyGame.Randomize();
                    break;
            }

            MyGame.NumberMoves++;
            MyGame.MaxCell = MyGame.Maximum();

            if (MyGame.Score > MyGame.BestScore)
                MyGame.BestScore = MyGame.Score;
            Painter();

            if (MyGame.Win == false)
            {
                if (MyGame.CheckWin())
                {
                    MyGame.Win = true;
                    MyGame.SaveGame();
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new Uri("WinPage.xaml", UriKind.RelativeOrAbsolute));
                }
            }

            MyGame.SaveGame();

            if (MyGame.CheckEnd())
            {
                MyGame.NewGame();
                MyGame.SaveGame();
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new Uri("LosePage.xaml", UriKind.RelativeOrAbsolute));
            }

            Game.Focus();
        }

        bool CheckBoard(int[,] Board)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Board[i, j] != MyGame.Board[i, j].Count)
                        return true;
                }
            }
            return false;
        }
        
        void Mass(ref int[,] Board)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j< 4; j++)
                {
                    Board[i, j] = MyGame.Board[i, j].Count;
                }
            }
        }
    }
}
