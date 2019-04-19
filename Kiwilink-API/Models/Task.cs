using System.Linq;
using MongoDAL;

namespace Kiwilink.Models
{
    public class Task : MongoEntity
    {
        [MongoRef]
        public string ClientId { get; set; }

        public string ClientName { get; set; }
        public string Content { get; set; }
        public bool IsComplete { get; set; } = false;
        public string AssignedEmployeeName { get; set; }

        [MongoIgnore]
        public bool Saving { get; set; }
        [MongoIgnore]
        public bool Completing { get; set; }
        [MongoIgnore]
        public bool OpeningClient { get; set; }

        public void Save()
        {
            DB.Save<Task>(this);
        }

        public void MarkComplete(string Id)
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

                tasks = from t in tasks
                        where t.ClientId.Equals(cid)
                        select t;
            }

            if (!all)
            {
                tasks = from t in tasks
                        where t.IsComplete.Equals(false)
                        select t;
            }

            return tasks.OrderByDescending(t=>t.ModifiedOn).Take(100).ToArray();
        }
    }
}
