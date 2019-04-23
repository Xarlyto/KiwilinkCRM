using System.Linq;
using MongoDAL;

namespace Kiwilink.Models
{
    public class Task : Entity
    {
        public One<Client> Client { get; set; }

        public string ClientName { get; set; }
        public string Content { get; set; }
        public bool IsComplete { get; set; } = false;
        public string AssignedEmployeeName { get; set; }

        [Ignore]
        public bool Saving { get; set; }
        [Ignore]
        public bool Completing { get; set; }
        [Ignore]
        public bool OpeningClient { get; set; }

        public void MarkComplete(string Id)
        {
            var task = DB.Collection<Task>().Single(t => t.ID.Equals(Id));
            task.IsComplete = true;
            task.Save();
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
                        where t.Client.ID.Equals(cid)
                        select t;
            }

            if (!all)
            {
                tasks = from t in tasks
                        where t.IsComplete.Equals(false)
                        select t;
            }

            return tasks.OrderByDescending(t => t.ModifiedOn).Take(100).ToArray();
        }
    }
}
