using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2K48.Classы
{
    public class Cell
    {
        private Path Str = new Path();

        public int Count { get; private set; }
        public BitmapImage Image { get; private set; }

        public Cell()
        {
            Count = 0;
            Str.GetPath(Count);
            string path = Str.Str;
            var uriImageSource = new Uri(path, UriKind.RelativeOrAbsolute);
            Image = new BitmapImage(uriImageSource);
        }

        public void GetImage(int Count)
        {
            this.Count = Count;

            Str.GetPath(Count);
            string path = Str.Str;

            var uriImageSource = new Uri(path, UriKind.RelativeOrAbsolute);
            Image = new BitmapImage(uriImageSource);
        }
    }
}
