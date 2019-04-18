using System;
using System.Linq;
using Kiwilink.Models;
using MongoDAL;

namespace Kiwilink.ViewModels
{
    public class vLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Employee Authenticate()
        {
            return DB.Collection<Employee>().SingleOrDefault(e => e.Name.Equals(Username) && e.Password.Equals(Password));
        }
    }
}
