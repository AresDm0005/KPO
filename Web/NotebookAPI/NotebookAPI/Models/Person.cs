using System;
using System.Collections.Generic;

namespace NotebookAPI.Models
{
    public class Person : BaseEntity
    {
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public DateTime BirthDay { get; set; }
        public ICollection<Contact> Contacts { get; set; }

        public Person()
        {
            Contacts = new List<Contact>();
        }
    }
}