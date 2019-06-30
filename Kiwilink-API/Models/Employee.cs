using MongoDB.Entities;
using Newtonsoft.Json;

namespace Kiwilink.Models
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public void SaveChanges()
        {
            this.Save();
        }
    }
}
