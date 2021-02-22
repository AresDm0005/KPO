using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaint
{
    public enum Mode { Pen, Line, Ellips, Star, Eraser }

    public partial class MainForm : Form
    {
        private Mode curmode;

        public static Color CurColor = Color.Black;
        public static int CurWidth = 3;
        public static int StarN = 5;

        public Mode CurMode
        {
            get { return curmode; }
            private set
            {
                curmode = value;
                ChangeStatusBarToolName(value);
            }
        }

        public MainForm()
        {
            InitializeComponent();
            CurMode = Mode.Pen;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog();
        }

        #region RadioButtonEmitation

        private void penStripButton_Click(object sender, EventArgs e)
        {
            CurMode = Mode.Pen;            
        }

        private void lineStripButton_Click(object sender, EventArgs e)
        {
            CurMode = Mode.Line;            
        }        

        private void ellipsStripButton_Click(object sender, EventArgs e)
        {
            CurMode = Mode.Ellips;            
        }

        private void starStripButton_Click(object sender, EventArgs e)
        {
            CurMode = Mode.Star;            
        }

        private void eraserStripButton_Click(object sender, EventArgs e)
        {
            CurMode = Mode.Eraser;            
        }
        #endregion

        private void ChangeStatusBarToolName(Mode mode)
        {
            switch (mode)
            {
                case Mode.Pen: { statusLabel.Text = "Перо"; break; }
                case Mode.Line: { statusLabel.Text = "Линия"; break; }
                case Mode.Ellips: { statusLabel.Text = "Эллипс"; break; }
                case Mode.Star: { statusLabel.Text = "Звезда"; break; }
                case Mode.Eraser: { statusLabel.Text = "Ластик"; break; }
            }
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canvas frmChild = new Canvas();
            frmChild.MdiParent = this;
            frmChild.Show();
        }

        #region BrushColorSet
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColor = Color.Red;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColor = Color.Blue;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColor = Color.Green;
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                CurColor = dlg.Color;
        }
        #endregion

        private void brushWidthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CurWidth = int.Parse(brushWidthTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Значение должн быть целым числом.",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpeg, *.jpg)| *.jpeg; *.jpg | Все файлы() *.*| *.* ";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                bool ok = true;
                foreach (var form in MdiChildren)
                {
                    if (form is Canvas)
                    {
                        Canvas canv = (Canvas)form;

                        if (canv.FilePath.Equals(dlg.FileName))
                            ok = false;
                    } else
                    {
                        throw new Exception("Wrong Coding");
                    }
                }
                   

                if (!ok)
                {
                    MessageBox.Show("Данный файл уже открыт в программе", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Canvas frmChild = new Canvas(dlg.FileName);
                frmChild.MdiParent = this;
                frmChild.Show();
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).SaveAs();
        }

        #region CanvasesArragment
        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void слеваНаправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void сверхуВнизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void упорядочитьЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        #endregion

        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasSize cs = new CanvasSize();
            cs.CanvasWidth = ((Canvas)ActiveMdiChild).CanvasWidth;
            cs.CanvasHeight = ((Canvas)ActiveMdiChild).CanvasHeight;
            if (cs.ShowDialog() == DialogResult.OK)
            {
                ((Canvas)ActiveMdiChild).CanvasWidth = cs.CanvasWidth;
                ((Canvas)ActiveMdiChild).CanvasHeight = cs.CanvasHeight;
            }
        }

        private void размерХолстаToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            размерХолстаToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).Save();
        }
    }
}
