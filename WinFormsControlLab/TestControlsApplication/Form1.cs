using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabControls;

namespace TestControlsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            colorChoise1.ColorChanged += new ColorChangedHandler(ChangeLabelOnColorChange);
        }

        public void ChangeLabelOnColorChange(object sender, ColorChangedArgs e)
        {
            checkLabel.Text = e.NewColor.ToString();
        }
    }
}
