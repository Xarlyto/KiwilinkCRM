using System.Linq;
using Kiwilink.Models;
using MongoDAL;

namespace Kiwilink.ViewModels
{
    public class vHome
    {
        public vTeaser[] Teasers { get; set; }
        public Task[] Tasks { get; set; }
        public vLists Lists { get; set; } = new vLists();

        public void Load(string EmployeeName)
        {
            Teasers = (from c in DB.Collection<Client>()
                       orderby c.ModifiedOn descending
                       select new vTeaser()
                       {
                           Id = c.Id,
                           Name = c.Name + " " + c.Surname,
                           Mobile = c.Mobile,
                           Course = c.Course,
                           Institute = c.Institute
                       }).Take(100).ToArray();

            Tasks = (from t in DB.Collection<Task>()
                     where t.IsComplete == false && t.AssignedEmployeeName.Equals(EmployeeName)
                     orderby t.ModifiedOn descending
                     select t).Take(100).ToArray();

            Lists.Load();
        }
    }
}

