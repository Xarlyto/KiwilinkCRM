using API_Server.Data;

namespace API_Server.Models
{
    public class Employee : Base
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public void Save()
        {
            DB.Save<Employee>(this);
        }
    }
}
