using MongoDB.Bson;
using System;
using Kiwilink.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;
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
