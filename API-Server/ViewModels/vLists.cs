using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Server.Data;
using API_Server.Models;

namespace API_Server.ViewModels
{
    public class vLists
    {
        public string[] LeadSources { get; set; }
        public string[] CourseCountries { get; set; }
        public string[] Institutes { get; set; }

        public void Load()
        {
            try
            {
                LeadSources = (from l in DB.Collection<DropList>()
                               where l.Name.Equals("LeadSources")
                               select l).SingleOrDefault().Values.OrderBy(v=>v).ToArray();
            }
            catch (Exception)
            {
                //ignore
            }

            try
            {
                CourseCountries = (from l in DB.Collection<DropList>()
                                   where l.Name.Equals("CourseCountries")
                                   select l).SingleOrDefault().Values.OrderBy(v => v).ToArray();


            }
            catch (Exception)
            {

                //ignore
            }

            try
            {
                Institutes = (from l in DB.Collection<DropList>()
                              where l.Name.Equals("Institutes")
                              select l).SingleOrDefault().Values.OrderBy(v => v).ToArray();
            }
            catch (Exception)
            {

                //ignore
            }
        }
    }


}
