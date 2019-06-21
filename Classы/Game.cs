using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2K48.Classы
{
    public class Game
    {
        private Path Str = new Path();
        public bool Win { get; set; }

        public Cell[,] Board = new Cell[4, 4];
        public int Score { get; set; }
        public int BestScore { get; set; }
        public int NumberMoves { get; set; }
        public int MaxCell { get; set; }

        public Game()
        {
            Score = 0;
            NumberMoves = 0;
            MaxCell = 0;
            Win = false;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4;j++)
                {
                    Board[i, j] = new Cell();
                }
            }
            
            Str.GetPath(-1);
            string path = Str.Str;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line = sr.ReadLine();
                BestScore = int.Parse(line);
            }

            Win = false;
        }

        public void LoadGame()
        {
            Str.GetPath(-1);
            string path = Str.Str;

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line = sr.ReadLine();
                BestScore = int.Parse(line);
                line = sr.ReadLine();
                Score = int.Parse(line);
                line = sr.ReadLine();
                Win = bool.Parse(line);
                line = sr.ReadLine();
                NumberMoves = int.Parse(line);
                line = sr.ReadLine();
                MaxCell = int.Parse(line);
                for (int i = 0; i < 4; i++)
                {
                    line = sr.ReadLine();
                    string[] Mass = line.Split(' ');
                    for (int j = 0; j < 4; j++)
                    {
                        Board[i, j].GetImage(int.Parse(Mass[j]));
                    }
                }
            }
        }

        public void SaveGame()
        {
            Str.GetPath(-1);
            string path = Str.Str;

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(BestScore);
                sw.WriteLine(Score);
                sw.WriteLine(Win);
                sw.WriteLine(NumberMoves);
                sw.WriteLine(MaxCell);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        sw.Write(Board[i, j].Count + " ");
                    }
                    sw.WriteLine();
                }
            }
        }

        public void NewGame()
        {
            Score = 0;
            NumberMoves = 0;
            MaxCell = 0;
            Win = false;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Board[i, j] = new Cell();
                }
            }

            Str.GetPath(-1);
            string path = Str.Str;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line = sr.ReadLine();
                BestScore = int.Parse(line);
            }

            Randomize();
            Randomize();
        }

        public void Randomize()
        {
            var Rand = new Randomizer();
            Rand.Spawn(ref Board);
        }

        public void RightMove()
        {
            /*for (int i = 0; i < 4; i++)
            {
                int j = 3;
                while (j > -1)
                {
                    if (Board[i, j].Count != 0)
                    {
                        int Time = Board[i, j].Count;
                        int iPos = i;
                        int jPos = j;
                        while (j > -1)
                        {
                            if (j != 0)
                            {
                                j--;
                                if (Board[i, j].Count == Time)
                                {
                                    Board[iPos, jPos].GetImage(Board[iPos, jPos].Count * 2);
                                    Score += Board[iPos, jPos].Count;
                                    Board[i, j].GetImage(0);
                                }
                                else if (Board[i, j].Count == 0) { }
                                else
                                {
                                    j++;
                                    break;
                                }
                            }
                            else { break; }

                        }
                    }
                    j--;
                }
            }
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j > -1; j--)
                {
                    int k = j;
                    while (Board[i, k + 1].Count == 0)
                    {
                        Board[i, k + 1].GetImage(Board[i, k].Count);
                        Board[i, k].GetImage(0);
                        if (k == 2) { break; }
                        k++;
                    }
                }
            }*/

            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j >= 0; j--)
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (Board[i, k].Count == 0)
                        {
                            continue;
                        }
                        else if (Board[i, k].Count == Board[i, j].Count)
                        {
                            Board[i, j].GetImage(Board[i, j].Count * 2);
                            Score += Board[i, j].Count;
                            Board[i, k].GetImage(0);
                            break;
                        }
                        else
                        {
                            if (Board[i, j].Count == 0 && Board[i, k].Count != 0)
                            {
                                Board[i, j].GetImage(Board[i, k].Count);
                                Board[i, k].GetImage(0);
                                j++;
                                break;
                            }
                            else if (Board[i, j].Count != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void LeftMove()
        {
            /*for (int i = 0; i < 4; i++)
            {
                int j = 0;
                while (j < 3)
                {
                    if (Board[i, j].Count != 0)
                    {
                        int Time = Board[i, j].Count;
                        int iPos = i;
                        int jPos = j;
                        while (j < 4)
                        {
                            if (j != 3)
                            {
                                j++;
                                if (Board[i, j].Count == Time)
                                {
                                    Board[iPos, jPos].GetImage(Board[iPos, jPos].Count * 2);
                                    Score += Board[iPos, jPos].Count;
                                    Board[i, j].GetImage(0);
                                }
                                else if (Board[i, j].Count == 0) { }
                                else
                                {
                                    j--;
                                    break;
                                }
                            }
                            else { break; }

                        }
                    }
                    j++;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    int k = j;
                    while (Board[i, k - 1].Count == 0)
                    {
                        Board[i, k - 1].GetImage(Board[i, k].Count);
                        Board[i, k].GetImage(0);
                        if (k - 1 == 0) { break; }
                        k--;
                    }
                }
            }*/

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (Board[i, k].Count == 0)
                        {
                            continue;
                        }
                        else if (Board[i, k].Count == Board[i, j].Count)
                        {
                            Board[i, j].GetImage(Board[i, j].Count * 2);
                            Score += Board[i, j].Count;
                            Board[i, k].GetImage(0);
                            break;
                        }
                        else
                        {
                            if (Board[i, j].Count == 0 && Board[i, k].Count != 0)
                            {
                                Board[i, j].GetImage(Board[i, k].Count);
                                Board[i, k].GetImage(0);
                                j--;
                                break;
                            }
                            else if (Board[i, j].Count != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void UpMove()
        {
            /*for (int i = 0; i < 4; i++)
            {
                int j = 0;
                while (j < 3)
                {
                    if (Board[j, i].Count != 0)
                    {
                        int Time = Board[j, i].Count;
                        int iPos = j;
                        int jPos = i;
                        while (j < 4)
                        {
                            if (j != 3)
                            {
                                j++;
                                if (Board[j, i].Count == Time)
                                {
                                    Board[iPos, jPos].GetImage(Board[iPos, jPos].Count * 2);
                                    Score += Board[iPos, jPos].Count;
                                    Board[j, i].GetImage(0);
                                }
                                else if (Board[j, i].Count == 0) { }
                                else
                                {
                                    j--;
                                    break;
                                }
                            }
                            else { break; }

                        }
                    }
                    j++;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    int k = j;
                    while (Board[k - 1, i].Count == 0)
                    {
                        Board[k - 1, i].GetImage(Board[k, i].Count);
                        Board[k, i].GetImage(0);
                        if (k - 1 == 0) { break; }
                        k--;
                    }
                }
            }*/

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int k = i + 1; k < 4; k++)
                    {
                        if (Board[k, j].Count == 0)
                        {
                            continue;
                        }
                        else if (Board[k, j].Count == Board[i, j].Count)
                        {
                            Board[i, j].GetImage(Board[i, j].Count * 2);
                            Score += Board[i, j].Count;
                            Board[k, j].GetImage(0);
                            break;
                        }
                        else
                        {
                            if (Board[i, j].Count == 0 && Board[k, j].Count != 0)
                            {
                                Board[i, j].GetImage(Board[k, j].Count);
                                Board[k, j].GetImage(0);
                                i--;
                                break;
                            }
                            else if (Board[i, j].Count != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void DownMove()
        {
            /*for (int i = 0; i < 4; i++)
            {
                int j = 3;
                while (j > -1)
                {
                    if (Board[j, i].Count != 0)
                    {
                        int Time = Board[j, i].Count;
                        int iPos = j;
                        int jPos = i;
                        while (j > -1)
                        {
                            if (j != 0)
                            {
                                j--;
                                if (Board[j, i].Count == Time)
                                {
                                    Board[iPos, jPos].GetImage(Board[iPos, jPos].Count * 2);
                                    Score += Board[iPos, jPos].Count;
                                    Board[j, i].GetImage(0);
                                }
                                else if (Board[j, i].Count == 0) { }
                                else
                                {
                                    j++;
                                    break;
                                }
                            }
                            else { break; }

                        }
                    }
                    j--;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j > -1; j--)
                {
                    int k = j;
                    while (Board[k + 1, i].Count == 0)
                    {
                        Board[k + 1, i].GetImage(Board[k, i].Count);
                        Board[k, i].GetImage(0);
                        if (k == 2) { break; }
                        k++;
                    }
                }
            }*/

            for (int j = 0; j < 4; j++)
            {
                for (int i = 3; i >= 0; i--)
                {
                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (Board[k, j].Count == 0)
                        {
                            continue;
                        }
                        else if (Board[k, j].Count == Board[i, j].Count)
                        {
                            Board[i, j].GetImage(Board[i, j].Count * 2);
                            Score += Board[i, j].Count;
                            Board[k, j].GetImage(0);
                            break;
                        }
                        else
                        {
                            if (Board[i, j].Count == 0 && Board[k, j].Count != 0)
                            {
                                Board[i, j].GetImage(Board[k, j].Count);
                                Board[k, j].GetImage(0);
                                i++;
                                break;
                            }
                            else if (Board[i, j].Count != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        public bool CheckEnd()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j + 1 < 4)
                        if (Board[i, j].Count == Board[i, j + 1].Count)
                            return false;
                    if (i + 1 < 4)
                        if (Board[i, j].Count == Board[i + 1, j].Count)
                            return false;
                    if (Board[i, j].Count == 0)
                        return false;
                }
            }
            return true;
        }

        public bool CheckWin()
        {
            Win = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Board[i, j].Count == 2048)
                    {
                        Win = !Win;
                        return Win;
                    }
                }
            }
            return false;
        }

        public int Maximum()
        {
            int Max = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Board[i, j].Count > Max)
                        Max = Board[i, j].Count;
                }
            }
            return Max;
        }
    }
}
