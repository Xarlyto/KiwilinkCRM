using API_Server.Data;
using API_Server.ViewModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace API_Server.Models
{
    public class Task : Base
    {
        [JsonConverter(typeof(ObjectIdConverter))] public ObjectId ClientId { get; set; }
        public string ClientName { get; set; }
        public string Content { get; set; }
        public bool IsComplete { get; set; } = false;
        public string AssignedEmployeeName { get; set; }

        [BsonIgnore] public bool Saving { get; set; }

        public void Save()
        {
            DB.Save<Task>(this);
        }
    }
}
