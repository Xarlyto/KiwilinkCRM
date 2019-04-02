using MongoDB.Bson;
using System;
using Newtonsoft.Json;
using Kiwilink.ViewModels;

namespace Kiwilink.Models
{
    public class Base
    {
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [JsonIgnore]
        public DateTime LastEditedOn { get; set; }
    }
}
