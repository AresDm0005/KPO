using System;
using System.Windows.Forms;

namespace TreeViewApp.CUDForms
{
    public partial class DealForm : Form
    {
        public int Client 
        { 
            get { return Convert.ToInt32(comboBox1.SelectedValue); } 
            private set
            {
                comboBox1.SelectedValue = value;
            }
        }

        public DateTime DateSign
        {
            get { return dateTimePicker1.Value; }
            private set
            {
                dateTimePicker1.Value = value;
            }
        }

        public DealForm()
        {
            InitializeComponent();
            this.clientsTableAdapter.Fill(this.sDTreeViewDataSet.Clients);
            okBtn.Text = "Добавить";
        }

        public DealForm(int client_id, DateTime date)
        {
            InitializeComponent();
            this.clientsTableAdapter.Fill(this.sDTreeViewDataSet.Clients);
            Client = client_id;
            DateSign = date;
            okBtn.Text = "Изменить";
        }

        private void DealForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
