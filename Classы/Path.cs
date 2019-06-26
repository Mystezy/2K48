using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2K48.Classы
{
    class Path
    {
        public string Str { get; private set; } = AppDomain.CurrentDomain.BaseDirectory;

        public void GetPath(int Count)
        {
            string S = "";
            for (int i = 0; i < 13; i++)
            {
                S += Str[i];
            }
            S += "Images\\";
            switch (Count)
            {
                case -4:
                    S += "repeat.png";
                    break;
                case -3:
                    S += "menu.png";
                    break;
                case -2:
                    S += "LeaderBoard.txt";
                    break;
                case -1:
                    S += "Text.txt";
                    break;
                case 0:
                    S += "start.png";
                    break;
                case 2:
                    S += "1.png";
                    break;
                case 4:
                    S += "2.png";
                    break;
                case 8:
                    S += "3.png";
                    break;
                case 16:
                    S += "4.png";
                    break;
                case 32:
                    S += "5.png";
                    break;
                case 64:
                    S += "6.png";
                    break;
                case 128:
                    S += "7.png";
                    break;
                case 256:
                    S += "8.png";
                    break;
                case 512:
                    S += "9.png";
                    break;
                case 1024:
                    S += "10.png";
                    break;
                case 2048:
                    S += "11.png";
                    break;
                case 4096:
                    S += "12.png";
                    break;
            }
            Str = S;
        }
    }
}
