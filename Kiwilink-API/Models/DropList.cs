using System;
using System.Collections.Generic;
using MongoDB.Entities;

namespace Kiwilink.Models
{
    public class DropList : Entity
    {
        public string Name { get; set; }
        public List<String> Values { get; set; } = new List<string>();        
    }
}
