using System;
using System.Collections.Generic;
using MongoDB.Bson;
using API_Server.Data;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API_Server.Models
{
    [BsonIgnoreExtraElements]
    public class Client : Base
    {
        public string Address { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Background { get; set; }
        public string CV { get; set; }
        public string Course { get; set; }
        public string CourseCountry { get; set; }
        public string CourseDuration { get; set; }
        public string CourseFee { get; set; }
        public DateTime CourseIntakeDate { get; set; }
        public string CourseLink { get; set; }
        public DateTime CourseStartDate { get; set; }
        public string CommissionAmount { get; set; }
        public DateTime CommissionDate { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Institute { get; set; }
        public string Landline { get; set; }
        public string LeadSource { get; set; }
        public string MinIELTS { get; set; }
        public string Mobile { get; set; }
        [Required] public string Name { get; set; }
        public string Passport { get; set; }
        public string PathwayProgram1 { get; set; }
        public string PathwayProgram2 { get; set; }
        [Required] public string Surname { get; set; }
        public DateTime VisaAppliedDate { get; set; }
        public DateTime VisaApprovedDate { get; set; }
        public string VisaStatus { get; set; }
        //[JsonIgnore] public ObjectId[] Tasks { get; set; }

        [BsonIgnore] public bool Saving { get; set; }
        [BsonIgnore] public bool ReadOnly { get; set; } = true;
        [BsonIgnore] public Task[] TaskList { get; set; }

        public void Save()
        {
            //this.Tasks = (from t in DB.Collection<Task>()
            //              where t.ClientId.Equals(Id)
            //              select t.Id).ToArray();

            DB.Save<Client>(this);
        }

        public Client Load(string id)
        {
            var cl = (from c in DB.Collection<Client>()
                      where c.Id.Equals(new ObjectId(id))
                      select c).Single();

            cl.TaskList = (from t in DB.Collection<Task>()
                           where t.ClientId.Equals(new ObjectId(id))
                           orderby t.LastEditedOn descending
                           select t).ToArray();

            return cl;
        }
    }
}
