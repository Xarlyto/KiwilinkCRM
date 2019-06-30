using Kiwilink.Models;
using MongoDB.Entities;
using System;
using System.Linq;

namespace Kiwilink.ViewModels
{
    public class vLists
    {
        public string[] LeadSources { get; set; }
        public string[] CourseCountries { get; set; }
        public string[] Institutes { get; set; }
        public string[] Employees { get; set; }

        public void Load()
        {
            try
            {
                LeadSources = (from l in DB.Queryable<DropList>()
                               where l.Name.Equals("LeadSources")
                               select l).SingleOrDefault().Values.OrderBy(v => v).ToArray();
            }
            catch (Exception)
            {
                LeadSources = new string[0];
            }

            try
            {
                CourseCountries = (from l in DB.Queryable<DropList>()
                                   where l.Name.Equals("CourseCountries")
                                   select l).SingleOrDefault().Values.OrderBy(v => v).ToArray();


            }
            catch (Exception)
            {

                CourseCountries = new string[0];
            }

            try
            {
                Institutes = (from l in DB.Queryable<DropList>()
                              where l.Name.Equals("Institutes")
                              select l).SingleOrDefault().Values.OrderBy(v => v).ToArray();
            }
            catch (Exception)
            {

                Institutes = new string[0];
            }

            Employees = (from e in DB.Queryable<Employee>()
                         orderby e.Name ascending
                         select e.Name).ToArray();
        }
    }


}
