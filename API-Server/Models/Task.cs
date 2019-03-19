using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Server.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Server.Models
{
    public class Task : Base
    {
        public ObjectId ClientId { get; set; }
        public string ClientName { get; set; }
        public string Content { get; set; }
        public bool IsComplete { get; set; } = false;
        public ObjectId AssignedEmployeeId { get; set; }
        public string AssignedEmployeeName { get; set; }

        public void Save()
        {
            DB.Save<Task>(this);
        }
    }
}
