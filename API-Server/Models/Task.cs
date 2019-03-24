using API_Server.Data;
using API_Server.ViewModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Linq;

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
        [BsonIgnore] public bool Completing { get; set; }
        [BsonIgnore] public bool OpeningClient { get; set; }

        public void Save()
        {
            DB.Save<Task>(this);
        }

        public void MarkComplete(ObjectId Id)
        {
            var task = DB.Collection<Task>().Single(t => t.Id.Equals(Id));
            task.IsComplete = true;
            DB.Save<Task>(task);
        }

        public Task[] FetchTasks(string employeeName, bool all, string cid)
        {
            var tasks = from t in DB.Collection<Task>()
                        select t;

            if (employeeName != "null")
            {
                tasks = from t in tasks
                        where t.AssignedEmployeeName.Equals(employeeName)
                        select t;
            }

            if (cid != "null")
            {
                var clid = new ObjectId(cid);

                tasks = from t in tasks
                        where t.ClientId.Equals(clid)
                        select t;
            }

            if (!all)
            {
                tasks = from t in tasks
                        where t.IsComplete.Equals(false)
                        select t;
            }

            return tasks.OrderByDescending(t=>t.LastEditedOn).Take(100).ToArray();
        }
    }
}
