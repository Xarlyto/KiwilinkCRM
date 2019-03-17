using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Server.Models
{
    public class Task
    {
        public ObjectId AssignedEmployeeId { get; set; }
        public string Content { get; set; }
    }
}
