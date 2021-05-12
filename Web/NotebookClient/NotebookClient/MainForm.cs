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
                MessageBox.Show(response.StatusCode.ToString());
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

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;

            int id = (int)listView.SelectedItems[0].Tag;
            Person person = GetPerson(id);

            contactListView.Items.Clear();
            foreach(var contact in person.Contacts)
            {
                ListViewItem item = new ListViewItem(new[] { contact.ContactType.Title, contact.Value, contact.ContactType.Id.ToString() });
                item.Tag = contact.Id;
                contactListView.Items.Add(item);
            }
        }

        private void DeleteContact(int delete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.DeleteAsync("api/contacts/" + delete).Result;
            }
        }

        private void AddContact(int person, int contactType, string value)
        {
            Contact contact = new Contact() {  PersonId = person,  ContactTypeId = contactType, Value = value};

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/contacts/", contact).Result;
            }
        }

        private void UpdateContact(int id, int person, int contactType, string value)
        {
            Contact contact = new Contact() { Id = id, PersonId = person, ContactTypeId = contactType, Value = value };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PutAsJsonAsync($"api/contacts/{id}", contact).Result;
                //MessageBox.Show(response.StatusCode.ToString());
            }
        }

        private void addContactBtn_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;

            AddChangeContactForm form = new AddChangeContactForm();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                AddContact((int)listView.SelectedItems[0].Tag, form.ContactType, form.Value);

                UpdateDisplayedData();
            }
        }

        private void chgContactBtn_Click(object sender, EventArgs e)
        {
            if (contactListView.SelectedItems.Count == 0)
                return;

            int id = (int)contactListView.SelectedItems[0].Tag;
            int pId = (int)listView.SelectedItems[0].Tag;

            AddChangeContactForm form = new AddChangeContactForm(contactListView.SelectedItems[0].SubItems[1].Text,
                Convert.ToInt32(contactListView.SelectedItems[0].SubItems[2].Text));
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                UpdateContact(id, pId, form.ContactType, form.Value);

                UpdateDisplayedData();
            }
        }

        private void delContactBtn_Click(object sender, EventArgs e)
        {
            if (contactListView.SelectedItems.Count != 0)
            {
                int id = (int)contactListView.SelectedItems[0].Tag;

                DeleteContact(id);

                UpdateDisplayedData();
            }
        }
    }
}
