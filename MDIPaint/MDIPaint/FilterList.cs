using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PluginInterface;

namespace MDIPaint
{
    public partial class FilterList : Form
    {
        public FilterList(IPlugin[] plugins, Tuple<int, int>[] arr)
        {
            InitializeComponent();
            CreateList(plugins, arr);


        }

        private void CreateList(IPlugin[] plugins, Tuple<int, int>[] arr)
        {
            int i = 0;
            foreach(var plug in plugins)
            {
                string item = "Название:" + plug.Name + ", Автор: " + plug.Author;
                dataGridView1.Rows.Add(new string[] { plug.Name, plug.Author, arr[i].Item1.ToString(), arr[i].Item2.ToString() });
                i++;
            }
        }
    }
}
