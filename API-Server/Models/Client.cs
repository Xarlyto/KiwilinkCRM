using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Server.Models
{
    public class Client
    {
        public ObjectId Id { get; set; } 
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
        public string Name { get; set; }
        public string Passport { get; set; }
        public string PathwayProgram1 { get; set; }
        public string PathwayProgram2 { get; set; }
        public string Surname { get; set; }
        public DateTime VisaAppliedDate { get; set; }
        public DateTime VisaApprovedDate { get; set; }
        public string VisaStatus { get; set; }

        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
