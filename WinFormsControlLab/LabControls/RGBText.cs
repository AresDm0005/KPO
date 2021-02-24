using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabControls
{
    public partial class RGBText : TextBox
    {
        
        public event EventHandler ValueChanged;

        private Mode NumMode = Mode.Dec;        

        public int Value 
        { 
            get { return Convert.ToInt32(Text, (int)NumMode); }
            set { Text = Convert.ToString(value, (int)NumMode); }
        }

        public RGBText()
        {
            TextAlign = HorizontalAlignment.Right;
            InitializeComponent();
        }

        public RGBText(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            bool fl = (NumMode == Mode.Dec) ? char.IsDigit(e.KeyChar) : Regex.IsMatch(e.KeyChar.ToString(), @"[\da-fA-F]");

            if (!fl && !char.IsControl(e.KeyChar))
                e.Handled = true;
            base.OnKeyPress(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (Regex.IsMatch(Text, @"rgbText\d+") || Text.Equals(String.Empty))
            {
                Text = "0";
                return;
            }

            base.OnTextChanged(e);
            int tmp;
            try 
            { 
                tmp = Convert.ToInt32(Text, (int)NumMode);

                tmp = (tmp > 255) ? 255 : tmp;
                tmp = (tmp < 0) ? 0 : tmp;

                Text = Convert.ToString(tmp, (int)NumMode);
                OnValueChanged(this, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Text} - Некорректно введено значение");
            }            
        }

        public void ChangeMode(Mode newMode)
        {
            Mode old = NumMode;
            NumMode = newMode;
            Text = Convert.ToString(Convert.ToInt32(Text, (int)old), (int)NumMode);
        }

        private void OnValueChanged(object source, EventArgs e)
        {
            ValueChanged?.Invoke(source, e);
        }
    }
}
