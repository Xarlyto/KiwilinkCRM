using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Server.Models;
using API_Server.Data;

namespace API_Server.ViewModels
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
