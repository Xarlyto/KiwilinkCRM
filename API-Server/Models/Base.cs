using MongoDB.Bson;
using System;
using API_Server.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;
using API_Server.ViewModels;

namespace API_Server.Models
{
    public class Base
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [JsonIgnore]
        public DateTime LastEditedOn { get; set; }
    }
}
