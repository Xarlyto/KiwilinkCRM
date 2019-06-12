using Kiwilink.Models;
using MongoDB.Entities;
using System.Linq;

namespace Kiwilink.ViewModels
{
    public class vTask : Task
    {
        public new Client Client { get; set; }

        public string SaveChanges()
        {
            var tsk = new Task()
            {
                ID = this.ID,
                ClientName = this.ClientName,
                Content = this.Content,
                IsComplete = this.IsComplete,
                AssignedEmployeeName = this.AssignedEmployeeName,
                Client = this.Client.Queryable()
                                    .Where(c => c.ID == this.Client.ID)
                                    .Single()
                                    .ToReference()
            };

            tsk.Save();
            return tsk.ID;
        }
    }

}
