using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2K48.Classы
{
    class Leaders
    {
        public List<Player> LeaderBoard = new List<Player>();
        private Path Str = new Path();

        public Leaders()
        {
            Initialization();
        }

        private void Initialization()
        {
            Str.GetPath(-2);
            string path = Str.Str;

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] Mass = line.Split(' ');
                    AddResult(Mass[0], int.Parse(Mass[1]), int.Parse(Mass[2]), int.Parse(Mass[3]));
                }
            }

            LeaderBoard.Sort();
        }

        public void SaveLeaders()
        {
            Str.GetPath(-1);
            string path = Str.Str;

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < LeaderBoard.Count; i++)
                {
                    sw.Write(LeaderBoard[i].Name + " ");
                    sw.Write(LeaderBoard[i].Score + " ");
                    sw.Write(LeaderBoard[i].NumberMoves + " ");
                    sw.WriteLine(LeaderBoard[i].MaxCell);
                }
            }
        }

        public void AddResult(string Name, int Score, int NumberMoves, int MaxCell)
        {
            Player New = new Player();
            New.Name = Name;
            New.Score = Score;
            New.NumberMoves = NumberMoves;
            New.MaxCell = MaxCell;

            LeaderBoard.Add(New);

            LeaderBoard.Sort();
        }

        private void Sort()
        {
            LeaderBoard = LeaderBoard.OrderBy(Player => Player.Score).ToList();
        }
    }
}
