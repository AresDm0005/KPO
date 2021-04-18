using System;
using System.Windows.Forms;
using TreeViewApp.SDTreeViewDataSetTableAdapters;

namespace TreeViewApp.CUDForms
{
    public partial class ServiceForm : Form
    {
        private decimal? price = 0;
        private int maxCopies;

        public int Service
        {
            get { return Convert.ToInt32(comboBox1.SelectedValue); }
            private set
            {
                comboBox1.SelectedValue = value;
            }
        }

        public int Copies
        {
            get { return Convert.ToInt32(copiesTxt.Text); }
            private set
            {
                copiesTxt.Text = value.ToString();
            }
        }

        public decimal Cost
        {
            get { return Convert.ToDecimal(costTxt.Text); }
        }

        public ServiceForm(int maxcop)
        {
            InitializeComponent();
            this.servicesTableAdapter.Fill(this.sDTreeViewDataSet.Services);
            okBtn.Text = "Добавить";
            maxCopies = maxcop;
        }
                
        public ServiceForm(int service, int copies, int maxcopies)
        {
            InitializeComponent();
            this.servicesTableAdapter.Fill(this.sDTreeViewDataSet.Services);
            Service = service;
            Copies = copies;
            maxCopies = maxcopies;
            okBtn.Text = "Изменить";
        }

        private void ServiceForm_Load(object sender, EventArgs e)
        {
            

        }

        private void copiesTxt_TextChanged(object sender, EventArgs e)
        {
            if (copiesTxt.Text.Length == 0)
            {
                costTxt.Text = "";
                return;
            }

            int copies = -1;

            try
            {
                copies = Convert.ToInt32(copiesTxt.Text);

                if (copies > maxCopies)                
                    copiesTxt.Text = "";                
                else if (copies == 0)
                    copiesTxt.Text = "";
                else
                    costTxt.Text = (price * copies).ToString();
            }
            catch (Exception ex)
            {
                copiesTxt.Text = "";
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            QueriesTableAdapter adapter = new QueriesTableAdapter();
            price = Convert.ToDecimal(adapter.GetPriceOfService(Convert.ToInt32(comboBox1.SelectedValue)));

            if (copiesTxt.Text.Length != 0)
                costTxt.Text = (price * Convert.ToInt32(copiesTxt.Text)).ToString();
        }

        private void copiesTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
