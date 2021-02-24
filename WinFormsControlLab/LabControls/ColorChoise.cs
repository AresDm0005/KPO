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

namespace LabControls
{
    public partial class ColorChoise : UserControl
    {
        public event ColorChangedHandler ColorChanged;
        public Mode Mode = Mode.Dec;

        public Color Color
        {
            get { return colorBox.BackColor; }
            set
            {
                OnColorChanged(this, new ColorChangedArgs(colorBox.BackColor, value));
                colorBox.BackColor = value;
            }
        }

        public ColorChoise()
        {
            InitializeComponent();
            decRadio.Checked = true;
            
            colorBox.Invalidate();

            txtRed.ValueChanged += new EventHandler(ChangeColor);
            txtGreen.ValueChanged += new EventHandler(ChangeColor);
            txtBlue.ValueChanged += new EventHandler(ChangeColor);
        }

        private void decRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (decRadio.Checked)
            {
                Mode = Mode.Dec;
                SwitchMode();
            }
        }

        private void hexRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (hexRadio.Checked)
            {
                Mode = Mode.Hex;
                SwitchMode();
            }
        }

        private void SwitchMode()
        {
            txtRed.ChangeMode(Mode);
            txtGreen.ChangeMode(Mode);
            txtBlue.ChangeMode(Mode);
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            Color = Color.FromArgb(txtRed.Value, txtGreen.Value, txtBlue.Value);
        }

        private void OnColorChanged(object sender, ColorChangedArgs e)
        {
            ColorChanged?.Invoke(sender, e);
        }

        private void ColorChoise_Load(object sender, EventArgs e)
        {
            ChangeColor(this, new EventArgs());
        }
    }


    public delegate void ColorChangedHandler(object sender, ColorChangedArgs e);

    public class ColorChangedArgs : EventArgs
    {
        public Color PreviousColor { get; private set; }

        public Color NewColor { get; private set; }

        public ColorChangedArgs(Color old, Color newColor)
        {
            PreviousColor = old;
            NewColor = newColor;
        }
    }

    public enum Mode { Dec = 10, Hex = 16 };
}
