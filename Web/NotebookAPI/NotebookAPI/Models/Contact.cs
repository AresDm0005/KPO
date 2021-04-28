using Newtonsoft.Json;

namespace NotebookAPI.Models
{    
    public class Contact : BaseEntity
    {
        public string Value { get; set; }
        public int? PersonId { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
        public int? ContactTypeId { get; set; }
        public ContactType ContactType { get; set; }
    }
}