using System;
using MongoDB.Entities;

namespace Kiwilink.Models
{
    public class Commission
    {
        public string Amount { get; set; }
        public Nullable<DateTime> Date { get; set; }
        [Ignore]
        public bool ShowPicker { get; set; }
    }
}
