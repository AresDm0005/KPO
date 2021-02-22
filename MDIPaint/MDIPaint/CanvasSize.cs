using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaint
{
    public partial class CanvasSize : Form
    {
        public int CanvasWidth
        {
            get { return Convert.ToInt32(widthBox.Text); }
            set 
            {
                widthBox.Text = value.ToString();
            }
        }
        public int CanvasHeight 
        {
            get { return Convert.ToInt32(heightBox.Text); }
            set
            {
                heightBox.Text = value.ToString();           
            }
        }

        public CanvasSize()
        {
            InitializeComponent();
        }

        private void heightBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void widthBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string msg = "";

            try
            {
                int tmp = Convert.ToInt32(widthBox.Text);
            }
            catch (Exception ex)
            {
                msg += "Значение ширины введено некорректно\n";
            }

            try
            {
                int tmp = Convert.ToInt32(heightBox.Text);
            }
            catch (Exception ex)
            {
                msg += "Значение высоты введено некорректно\n";
            }

            if (!msg.Equals(String.Empty))
            {
                MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}
