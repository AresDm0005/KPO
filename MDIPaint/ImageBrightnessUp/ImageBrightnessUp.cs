using PluginInterface;
using System.Drawing;

namespace ImageBrightnessUp
{
    [Version(2, 0)]
    public class ImageBrightnessUp : IPlugin
    {
        private int N = 25; 
        public string Name { get { return "Повышение яркости"; } }

        public string Author { get { return "Me"; } }

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
            i = i + N * 128 / 100;
            if (i < 0) i = 0;
            if (i > 255) i = 255;
            return i;
        }
    }
}
