using NotebookClient.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace NotebookClient
{
    public partial class MainForm : Form
    {
        private const string _baseAddress = "http://kponotebookapi.azurewebsites.net/";

        public MainForm()
        {
            InitializeComponent();
        }

        private void dsplBtn_Click(object sender, EventArgs e)
        {
            UpdateDisplayedData();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count != 0)
            {
                int id = (int)listView.SelectedItems[0].Tag;

                Delete(id);

                UpdateDisplayedData();
            }

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddChangePersonForm form = new AddChangePersonForm();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                Add(form.FirstName, form.SecondName, form.DateBirth);

                UpdateDisplayedData();
            }
        }

        private void cngBtn_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;

            int id = (int)listView.SelectedItems[0].Tag;
            ListViewItem item = listView.SelectedItems[0];

            AddChangePersonForm form = new AddChangePersonForm(
                item.SubItems[0].Text, item.SubItems[1].Text, Convert.ToDateTime(item.SubItems[2].Text));
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                Update(id, form.FirstName, form.SecondName, form.DateBirth);

                UpdateDisplayedData();
            }
        }

        private void UpdateDisplayedData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                response = client.GetAsync("api/People").Result;
                if (response.IsSuccessStatusCode)
                {
                    listView.Items.Clear();
                    Person[] reports = response.Content.ReadAsAsync<Person[]>().Result;
                    foreach (var p in reports)
                    {
                        var item = new ListViewItem(new[] { p.Firstname, p.Secondname, p.BirthDay.ToShortDateString() });
                        item.Tag = p.Id;
                        listView.Items.Add(item);                        
                    }
                }
            }
        }

        private void Delete(int delete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.DeleteAsync("api/People/" + delete).Result;

            }
        }

        private void Add(string first, string second, DateTime birth)
        {
            Person newReport = new Person() { Firstname = first, Secondname = second, BirthDay = birth };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/People", newReport).Result;

            }
        }

        private void Update(int id, string first, string second, DateTime birth)
        {
            Person newReport = new Person() { Id = id, Firstname = first, Secondname = second, BirthDay = birth };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PutAsJsonAsync($"api/people/{id}", newReport).Result;
            }
        }

        private Person GetPerson(int id)
        {
            Person person = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                response = client.GetAsync($"api/people/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    person = response.Content.ReadAsAsync<Person>().Result;                    
                }
            }

            return person;
        }
    }
}
