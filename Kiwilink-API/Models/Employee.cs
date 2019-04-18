using Newtonsoft.Json;
using MongoDAL;

namespace Kiwilink.Models
{
    public class Employee : MongoEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public void Save()
        {
            DB.Save<Employee>(this);
        }
    }
}
