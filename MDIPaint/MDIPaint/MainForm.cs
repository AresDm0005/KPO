using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PluginInterface;
using System.Configuration;

namespace MDIPaint
{
    public enum Mode { Pen, Line, Ellips, Star, Eraser }

    public partial class MainForm : Form
    {
        private Mode curmode;

        public static Color CurColor = Color.Black;
        public static int CurWidth = 3;
        public static int StarN = 5;

        Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();
        List<Tuple<int, int>> tuples;

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
                        
            FindPlugins();
            CreatePluginMenu();
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
                case Mode.Star: { statusLabel.Text = $"Звезда ({StarN})"; break; }
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

        #region StarN
        private void fourStarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurMode = Mode.Star;
            StarN = 4;
        }

        private void fiveStarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurMode = Mode.Star;
            StarN = 5;
        }

        private void sixStarlStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurMode = Mode.Star;
            StarN = 6;
        }

        private void другоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StarCount dlg = new StarCount();
            dlg.ShowDialog();

            if (dlg.DialogResult == DialogResult.OK)
            {
                CurMode = Mode.Star;
                StarN = dlg.StarN;
            }            
        }
        #endregion

        private void scaleUpStripButton_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).ZoomIn();
        }

        private void scaleDownStripButton_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).ZoomOut();
        }

        #region Plugins
        private void LoadPluginsAutomatically()
        {
            // папка с плагинами
            string folder = System.AppDomain.CurrentDomain.BaseDirectory;
            // dll-файлы в этой папке
            string[] files = Directory.GetFiles(folder, "*.dll");
            tuples = new List<Tuple<int, int>>();
            foreach (string file in files)
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    foreach (Type type in assembly.GetTypes())
                    {                        
                        var attr = type.GetCustomAttribute<VersionAttribute>();
                        Type iface = type.GetInterface("PluginInterface.IPlugin");
                        if (iface != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugins.Add(plugin.Name, plugin);
                            tuples.Add(new Tuple<int, int>(attr.Major, attr.Minor));                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
        }

        private void LoadPluginsManually()
        {
            string folder = System.AppDomain.CurrentDomain.BaseDirectory;
            tuples = new List<Tuple<int, int>>();

            var sAll = ConfigurationManager.AppSettings;

            foreach (string item in sAll)
            {
                try
                {
                    string f = sAll.GetValues(item)[0];
                    Assembly assembly = Assembly.LoadFile(folder + @"\" + sAll.GetValues(item)[0]);
                    foreach (Type type in assembly.GetTypes())
                    {
                        var attr = type.GetCustomAttribute<VersionAttribute>();
                        Type iface = type.GetInterface("PluginInterface.IPlugin");
                        if (iface != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugins.Add(plugin.Name, plugin);
                            tuples.Add(new Tuple<int, int>(attr.Major, attr.Minor));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
            }
        }

        private void FindPlugins()
        {
            bool avtm = false;
            
            try
            {
                var aSet = ConfigurationManager.AppSettings;
                var sAll = ConfigurationManager.AppSettings.AllKeys;

                if (sAll.Length == 0)
                    avtm = true;
                
                string f = aSet.Get(sAll[0]);
                if (sAll.Length == 1 && aSet.Get(sAll[0]).Equals("Auto"))
                    avtm = true;

            } 
            catch (Exception ex)
            {
                avtm = true;
            }

            if (avtm)
                LoadPluginsAutomatically();
            else
                LoadPluginsManually();
            
        }

        private void CreatePluginMenu() 
        {
            foreach (IPlugin plugin in plugins.Values)
            {
                var i = new ToolStripMenuItem(plugin.Name);
                i.Click += new EventHandler(OnPluginClick);
                фильтрыToolStripMenuItem.DropDownItems.Add(i);
            }
        }

        private void OnPluginClick(object sender, EventArgs args)
        {
            if (!(ActiveMdiChild == null))
            {
                IPlugin plugin = plugins[((ToolStripMenuItem)sender).Text];
                plugin.Transform((Bitmap)((Canvas)ActiveMdiChild).GetImage());
            }
        }

        #endregion

        private void списокФильтровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterList dlg = new FilterList(plugins.Values.ToArray(), tuples.ToArray());
            dlg.ShowDialog();
        }
    }
}
