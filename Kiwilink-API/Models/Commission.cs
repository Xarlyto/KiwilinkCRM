using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Kiwilink.Models
{
    [BsonIgnoreExtraElements]
    public class Commission
    {
        public string Amount { get; set; }
        public Nullable<DateTime> Date { get; set; }
        [BsonIgnore] public bool ShowPicker { get; set; }
    }
}
