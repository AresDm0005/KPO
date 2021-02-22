using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaint
{
    public partial class Canvas : Form
    {
        private static int Count = 0;

        private int oldX, oldY;
        private int X, Y;
        private Bitmap bmp;


        private string filepath = String.Empty;
        private ImageFormat saveFormat = null;

        public string FilePath
        {
            get { return filepath; }
            private set 
            {
                filepath = value;
                FileName = GetFileNameFromPath(value);
                this.Text = FileName;
            }
        }

        private string FileName = null;

        public int CanvasWidth
        {
            get
            {
                return pictureBox.Width;
            }
            set
            {
                pictureBox.Width = value;
                Bitmap tbmp = new Bitmap(value, pictureBox.Width);
                Graphics g = Graphics.FromImage(tbmp);
                g.Clear(Color.White);
                g.DrawImage(bmp, new Point(0, 0));
                bmp = tbmp;
                pictureBox.Image = bmp;

                this.Width = value;
            }
        }

        public int CanvasHeight
        {
            get
            {
                return pictureBox.Height;
            }
            set
            {
                pictureBox.Height = value;
                Bitmap tbmp = new Bitmap(pictureBox.Width, value);
                Graphics g = Graphics.FromImage(tbmp);
                g.Clear(Color.White);
                g.DrawImage(bmp, new Point(0, 0));
                bmp = tbmp;
                pictureBox.Image = bmp;

                this.Height = value;
            }
        }

        public Canvas()
        {
            InitializeComponent();
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            Graphics.FromImage(bmp).Clear(Color.White);
            pictureBox.Image = bmp;

            Count++;
            this.Text = $"Холст {Count}";
        }

        public Canvas(String filepath)
        {
            InitializeComponent();
            bmp = new Bitmap(Image.FromFile(filepath));
            Graphics g = Graphics.FromImage(bmp);
            pictureBox.Width = bmp.Width;
            pictureBox.Height = bmp.Height;
            pictureBox.Image = bmp;

            FilePath = filepath;
            saveFormat = GetFormatFromPath(filepath);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Mode mode = ((MainForm)(this.ParentForm)).CurMode;

                if (mode == Mode.Pen)
                    MouseMoveModePen(e);
                else if (mode == Mode.Eraser)
                    MouseMoveModeEraser(e);
                else
                    MouseMoveModeFigures(e);

                pictureBox.Invalidate();
            }
        }

        private void MouseMoveModePen(MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(new Pen(MainForm.CurColor, MainForm.CurWidth),
                oldX, oldY, e.X, e.Y);
            oldX = e.X;
            oldY = e.Y;            
        }

        private void MouseMoveModeEraser(MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);

            g.FillRectangle(new SolidBrush(pictureBox.BackColor),
                e.X - MainForm.CurWidth / 2, e.Y - MainForm.CurWidth / 2, MainForm.CurWidth, MainForm.CurWidth);
        }

        private void MouseMoveModeFigures(MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;

            pictureBox.Invalidate();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            switch (((MainForm)(this.ParentForm)).CurMode)
            {
                case Mode.Pen: { break; }
                case Mode.Line: 
                    {
                        e.Graphics.DrawLine(new Pen(MainForm.CurColor, MainForm.CurWidth),
                            new Point(oldX, oldY), new Point(X, Y));
                        break; 
                    }
                case Mode.Ellips:
                    {
                        var t = LeftCorner(oldX, oldY, X, Y);
                        e.Graphics.DrawEllipse(new Pen(MainForm.CurColor, MainForm.CurWidth),
                            new Rectangle(t.Item1, t.Item2, Math.Abs(oldX - X), Math.Abs(oldY - Y)));
                        break;
                    }
                case Mode.Star:
                    {
                        var t = LeftCorner(oldX, oldY, X, Y);
                        DrawStar(e.Graphics, MainForm.StarN, t.Item1, t.Item2,
                            Math.Abs(oldX - X), Math.Abs(oldY - Y));
                        break;
                    }
                case Mode.Eraser: { break; }
            }            
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            oldX = e.X;
            oldY = e.Y;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (((MainForm)(this.ParentForm)).CurMode)
                {
                    case Mode.Pen: { break; }
                    case Mode.Line:
                        {
                            Graphics.FromImage(bmp).DrawLine(new Pen(MainForm.CurColor, MainForm.CurWidth),
                                new Point(oldX, oldY), new Point(X, Y));
                            break;
                        }
                    case Mode.Ellips:
                        {
                            var t = LeftCorner(oldX, oldY, X, Y);
                            Graphics.FromImage(bmp).DrawEllipse(new Pen(MainForm.CurColor, MainForm.CurWidth),
                                new Rectangle(t.Item1, t.Item2, Math.Abs(oldX - X), Math.Abs(oldY - Y)));
                            break;
                        }
                    case Mode.Star:
                        {
                            var t = LeftCorner(oldX, oldY, X, Y);
                            DrawStar(Graphics.FromImage(bmp), MainForm.StarN, t.Item1, t.Item2,
                                Math.Abs(oldX - X), Math.Abs(oldY - Y));
                            break;
                        }
                }              

                pictureBox.Invalidate();
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        private Tuple<int,int> LeftCorner(int lx, int ly, int rx, int ry)
        {
            if (lx > rx) Swap(ref lx, ref rx);
            if (ly > ry) Swap(ref ly, ref ry);
            return new Tuple<int, int>(lx, ly);
        }

        private void DrawStar(Graphics g, int n, int x, int y, int width, int height)
        {
            double R = Math.Min(width, height) / 2, r = Math.Min(width, height);
            double alpha = 0;
            double x0 = x + width / 2;
            double y0 = y + height / 2;

            PointF[] points = new PointF[2 * n + 1];
            double a = alpha, da = Math.PI / n, l;

            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(x0 + l * Math.Cos(a)), (float)(y0 + l * Math.Sin(a)));
                a += da;
            }

            g.DrawLines(new Pen(MainForm.CurColor, MainForm.CurWidth), points);
        }

        private void Canvas_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        
        public void SaveAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpg) | *.jpg";
            ImageFormat[] ff = { ImageFormat.Bmp, ImageFormat.Jpeg };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(dlg.FileName, ff[dlg.FilterIndex - 1]);
                FilePath = dlg.FileName;
                saveFormat = ff[dlg.FilterIndex - 1];
            }
        }

        public void Save()
        {
            if (FilePath.Equals(String.Empty))
            {
                SaveAs();
                return;
            }            

            bmp.Save(FilePath, saveFormat);            
        }

        private string GetFileNameFromPath(string path)
        {
            var parts = path.Split(new char[] { '\\' });
            return parts[parts.Length - 1].Split(new char[] { '.' })[0];
        }

        private ImageFormat GetFormatFromPath(string path)
        {
            var parts = path.Split(new char[] { '\\' });
            string frm = parts[parts.Length - 1].Split(new char[] { '.' })[1];

            if (frm == "jpg")
                return ImageFormat.Jpeg;
            else
                return ImageFormat.Bmp;
        }
    }

}
