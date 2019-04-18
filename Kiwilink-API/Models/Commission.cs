using System;
using MongoDAL;

namespace Kiwilink.Models
{
    public class Commission
    {
        public string Amount { get; set; }
        public Nullable<DateTime> Date { get; set; }
        [MongoIgnore]
        public bool ShowPicker { get; set; }
    }
}
