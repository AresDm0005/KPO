using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using NotebookClient.Models;

namespace NotebookClient
{
    public partial class AddChangeContactForm : Form
    {
        public string Value
        {
            get { return nameTxt.Text; }
            set { nameTxt.Text = value; }
        }

        public int ContactType
        {
            get { return Convert.ToInt32(comboBox1.SelectedValue); }
            set { comboBox1.SelectedValue = value; }
        }

        public AddChangeContactForm()
        {
            InitializeComponent();
            InitializeCombo();

            Text = "Добавить новый контакт";
            okBtn.Text = "Добавить";
        }

        public AddChangeContactForm(string value, int ctype)
        {
            InitializeComponent();
            InitializeCombo();

            Value = value;
            ContactType = ctype;

            Text = "Изменить новый контакт";
            okBtn.Text = "Изменить";
        }

        void InitializeCombo()
        {
            DataTable table = GetContactTypes();
            comboBox1.DataSource = table;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Title";
        }

        DataTable GetContactTypes()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new[] { new DataColumn("Title", typeof(string)), new DataColumn("Id", typeof(int)) });
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://kponotebookapi.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                response = client.GetAsync("api/contacttypes").Result;
                if (response.IsSuccessStatusCode)
                {
                    ContactType[] reports = response.Content.ReadAsAsync<ContactType[]>().Result;
                    foreach (var c in reports)
                    {
                        table.Rows.Add(new object[] { c.Title, c.Id });
                    }
                }
            }

            return table;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text.Length == 0)
            {
                MessageBox.Show("Поле значения не заполнено");
                DialogResult = DialogResult.None;
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
