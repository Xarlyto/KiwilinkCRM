using Kiwilink.Data;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Kiwilink.Models
{
    public class Employee : Base
    {
        public string Name { get; set; }
        [JsonIgnore]public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public void Save()
        {
            DB.Save<Employee>(this);
        }
    }
}
