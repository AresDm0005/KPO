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
    public partial class StarCount : Form
    {
        public int StarN 
        {
            get { return Convert.ToInt32(textBox1.Text); }            
        }


        public StarCount()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int tmp;
            string msg = String.Empty;

            try
            {
                tmp = Convert.ToInt32(textBox1.Text);

                if (tmp < 4 || tmp > 100)
                    msg += "Звезда может быть от 4х до 100 конечной";
            } catch (Exception ex)
            {
                msg += "Некорректно введено число";
            }

            if (!msg.Equals(String.Empty))
            {
                MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}
