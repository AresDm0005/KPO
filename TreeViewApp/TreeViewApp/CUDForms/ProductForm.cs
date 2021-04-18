using System;
using System.Windows.Forms;
using TreeViewApp.SDTreeViewDataSetTableAdapters;

namespace TreeViewApp.CUDForms
{
    public partial class ProductForm : Form
    {
        private decimal? price = 0;

        public int Product 
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

        public ProductForm()
        {
            InitializeComponent();
            this.productsTableAdapter.Fill(this.sDTreeViewDataSet.Products);
            okBtn.Text = "Добавить";
        }

        public ProductForm(int product, int copies)
        {
            InitializeComponent();
            this.productsTableAdapter.Fill(this.sDTreeViewDataSet.Products);
            Product = product;
            Copies = copies;
            okBtn.Text = "Изменить";
        }   

        private void ProductForm_Load(object sender, EventArgs e)
        {   
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            QueriesTableAdapter adapter = new QueriesTableAdapter();
            price = adapter.GetPriceOfProduct(Convert.ToInt32(comboBox1.SelectedValue));

            if (copiesTxt.Text.Length != 0)
                costTxt.Text = (price * Convert.ToInt32(copiesTxt.Text)).ToString();
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

                if (copies > 100000)
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

        private void copiesTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
