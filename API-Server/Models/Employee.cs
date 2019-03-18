using API_Server.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Server.Models
{
    public class Employee : Base
    {
        public string Name { get; set; }
        public string PasswordHash { get; set; }

        public void Save()
        {
            DB.Save<Employee>(this);
        }
    }
}
