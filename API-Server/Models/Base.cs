using MongoDB.Bson;
using System;
using API_Server.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Server.Models
{
    public class Base
    {
        public ObjectId Id { get; set; }
        public DateTime LastEditedOn { get; set; }
    }
}
