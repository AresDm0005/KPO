using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotebookClient
{
    public partial class AddChangePersonForm : Form
    {
        public string FirstName
        {
            get { return nameTxt.Text; }
            set
            {
                nameTxt.Text = value;
            }
        }

        public string SecondName
        {
            get { return surnameTxt.Text; }
            set
            {
                surnameTxt.Text = value;
            }
        }

        public DateTime DateBirth 
        { 
            get { return dateBirthDTP.Value; }
            set
            {
                dateBirthDTP.Value = value;
            }
        }

        public AddChangePersonForm()
        {
            InitializeComponent();
            Text = "Добавление нового человека";
            okBtn.Text = "Добавить";
        }

        public AddChangePersonForm(string first, string second, DateTime birth)
        {
            InitializeComponent();
            Text = "Измение данных человека";
            okBtn.Text = "Изменить";
            FirstName = first;
            SecondName = second;
            DateBirth = birth;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text.Length == 0 || surnameTxt.Text.Length == 0)
            {
                MessageBox.Show("Одно из полей не заполнено!");
                DialogResult = DialogResult.None;
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void cnclBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
