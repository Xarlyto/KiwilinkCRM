using System;
using System.Linq;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using MongoDAL;

namespace Kiwilink.Models
{
    public class Client : Entity
    {
        public string Address { get; set; }
        public Nullable<DateTime> ArrivalDate { get; set; }
        public string Background { get; set; }
        public string CV { get; set; }
        public string Course { get; set; }
        public string CourseCountry { get; set; }
        public string CourseDuration { get; set; }
        public string CourseFee { get; set; }
        public string CourseLink { get; set; }
        public Nullable<DateTime> CourseStartDate { get; set; }
        public Commission[] Commissions { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Institute { get; set; }
        public string Landline { get; set; }
        public string LeadSource { get; set; }
        public string MinIELTS { get; set; }
        public string Mobile { get; set; }
        [Required]
        public string Name { get; set; }
        public string Passport { get; set; }
        public PathwayProgram[] Pathways { get; set; }
        [Required]
        public string Surname { get; set; }
        public Nullable<DateTime> VisaAppliedDate { get; set; }
        public Nullable<DateTime> VisaApprovedDate { get; set; }
        public string VisaStatus { get; set; }

        [Ignore]
        public bool Saving { get; set; }
        [Ignore]
        public bool ReadOnly { get; set; } = true;
        [Ignore]
        public bool DeleteEnable { get; set; } = false;
        [Ignore]
        public Task[] TaskList { get; set; }

        public void SaveChanges()
        {
            if (CourseCountry != null)
            {
                var countryList = (from l in DB.Collection<DropList>()
                                   where l.Name.Equals("CourseCountries")
                                   select l).SingleOrDefault();

                if (countryList == null)
                {
                    countryList = new DropList() { Name = "CourseCountries" };
                }

                if (!countryList.Values.Any(x => x.Equals(CourseCountry, StringComparison.OrdinalIgnoreCase)))
                {
                    countryList.Values.Add(CourseCountry.TitleCaseMe());
                }

                countryList.Save();
            }


            if (LeadSource != null)
            {
                var leadSourceList = (from l in DB.Collection<DropList>()
                                      where l.Name.Equals("LeadSources")
                                      select l).SingleOrDefault();

                if (leadSourceList == null)
                {
                    leadSourceList = new DropList() { Name = "LeadSources" };
                }

                if (!leadSourceList.Values.Any(x => x.Equals(LeadSource, StringComparison.OrdinalIgnoreCase)))
                {
                    leadSourceList.Values.Add(LeadSource.TitleCaseMe());
                }

                leadSourceList.Save();
            }


            if (Institute != null)
            {
                var instituteList = (from l in DB.Collection<DropList>()
                                     where l.Name.Equals("Institutes")
                                     select l).SingleOrDefault();

                if (instituteList == null)
                {
                    instituteList = new DropList() { Name = "Institutes" };
                }

                if (!instituteList.Values.Any(x => x.Equals(Institute, StringComparison.OrdinalIgnoreCase)))
                {
                    instituteList.Values.Add(Institute.TitleCaseMe());
                }

                instituteList.Save();
            }

            this.Save();
        }

        public Client Load(string id, string employeeName, bool all)
        {
            var cl = (from c in DB.Collection<Client>()
                      where c.ID.Equals(id)
                      select c).Single();

            cl.TaskList = new Task().FetchTasks(employeeName, all, id);

            return cl;
        }

        public void Delete(string id)
        {
            DB.Delete<Task>(t => t.Client.ID.Equals(id));
            DB.Delete<Client>(id);
        }
    }
}
