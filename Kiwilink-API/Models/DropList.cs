using MongoDB.Entities;
using System.Collections.Generic;

namespace Kiwilink.Models
{
    public class DropList : Entity
    {
        public string Name { get; set; }
        public List<string> Values { get; set; } = new List<string>();
    }
}
