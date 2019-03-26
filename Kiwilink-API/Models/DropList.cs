using System;
using System.Collections.Generic;

namespace Kiwilink.Models
{
    public class DropList : Base
    {
        public string Name { get; set; }
        public List<String> Values { get; set; } = new List<string>();
        
    }
}
