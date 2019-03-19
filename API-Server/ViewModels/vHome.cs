using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Server.Data;
using API_Server.Models;

namespace API_Server.ViewModels
{
    public class vHome
    {
        public vTeaser[] Teasers { get; set; }
        public Models.Task[] Tasks { get; set; }

        public void Load()
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
                       }).Take(25).ToArray();

            Tasks = (from t in DB.Collection<Models.Task>()
                     where t.IsComplete == false
                     orderby t.LastEditedOn descending
                     select t).Take(25).ToArray();
        }
    }
}
