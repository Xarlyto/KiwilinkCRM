using System;
using System.Collections.Generic;
using MongoDAL;

namespace Kiwilink.Models
{
    public class DropList : Entity
    {
        public string Name { get; set; }
        public List<String> Values { get; set; } = new List<string>();        
    }
}
