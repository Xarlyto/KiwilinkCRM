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
                ID = ID,
                ClientName = ClientName,
                Content = Content,
                IsComplete = IsComplete,
                AssignedEmployeeName = AssignedEmployeeName,
                Client = Client.Queryable()
                                    .Where(c => c.ID == Client.ID)
                                    .Single()
                                    .ToReference()
            };

            tsk.Save();
            return tsk.ID;
        }
    }

}
