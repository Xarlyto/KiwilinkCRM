using System.Linq;
using API_Server.Data;
using API_Server.Models;

namespace API_Server.ViewModels
{
    public class vHome
    {
        public vTeaser[] Teasers { get; set; }
        public Task[] Tasks { get; set; }
        public vLists Lists { get; set; } = new vLists();

        public void Load(string EmployeeName)
        {
            Teasers = (from c in DB.Collection<Client>()
                       orderby c.LastEditedOn descending
                       select new vTeaser()
                       {
                           Id = c.Id,
                           Name = c.Name + " " + c.Surname,
                           Mobile = c.Mobile,
                           Course = c.Course,
                           Institute = c.Institute
                       }).Take(50).ToArray();

            Tasks = (from t in DB.Collection<Task>()
                     where t.IsComplete == false && t.AssignedEmployeeName.Equals(EmployeeName)
                     orderby t.LastEditedOn descending
                     select t).Take(100).ToArray();

            Lists.Load();
        }
    }
}

