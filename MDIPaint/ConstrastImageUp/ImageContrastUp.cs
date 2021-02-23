using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;
using System.Drawing;

namespace ConstrastImageUp
{
    [Version(3,3)]
    public class ImageContrastUp : IPlugin
    {
        private int N = 25;
        public string Name { get { return "Повышение контрастности"; } }

        public string Author { get { return "Mi"; } }

        public void Transform(Bitmap bitmap)
        {
            for (int i = 0; i < bitmap.Width; ++i)
            {
                for (int j = 0; j < bitmap.Height; ++j)
                {
                    Color color = bitmap.GetPixel(i, j);
                    bitmap.SetPixel(i, j, NewColor(color));
                }
            }
        }

        private Color NewColor(Color old)
        {
            return Color.FromArgb(Func(old.R), Func(old.G), Func(old.B));
        }

        private int Func(int i)
        {
            i = (100 * i - 128 * N) / (100 - N);
            if (i < 0) i = 0;
            if (i > 255) i = 255;
            return i;
        }
    }
}
