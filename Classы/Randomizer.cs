using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2K48.Classы
{
    class Randomizer
    {
        private int Chance4 = 4;

        public int Count { get; private set; }
        public int Position { get; private set; }

        public void Spawn(ref Cell[,] Board)
        {
            Random Rand = new Random();
            if (Rand.Next() % 5 < Chance4)
                Count = 2;
            else
                Count = 4;

            int n = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Board[i, j].Count == 0)
                        n++;
                }
            }

            Position = Rand.Next() % n;

            bool Spawning = false;
            n = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Board[i, j].Count == 0)
                    {
                        if (Position == n)
                        {
                            Board[i, j].GetImage(Count);
                            Spawning = true;
                            break;
                        }
                        n++;
                    }
                }
                if (Spawning)
                    break;
            }
            
        }
    }
}
