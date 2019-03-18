using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Server.Data;
using API_Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Server.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet("api/client/{id}")]
        public ActionResult<Client> EditClient(string id)
        {
            var client = new Client();
            client.Address = "15 veediya bandara mawatha, ethul kotte, sri jayawardanapura";
            client.ArrivalDate = DateTime.UtcNow;
            client.Background = "background notes are here";
            client.CommissionAmount = "USD 500";
            client.CommissionDate = DateTime.UtcNow;
            client.Course = "Diploma in sexual studies";
            client.CourseCountry = "Malaysia";
            client.CourseDuration = "13 years";
            client.CourseFee = "MYR 23,000.00";
            client.CourseIntakeDate = DateTime.UtcNow;
            client.CourseLink = "http://google.com";
            client.CourseStartDate = DateTime.UtcNow;
            client.CV = "http://dropbox.com";
            client.Email1 = "damith@posturetop.com";
            client.Email1 = "";
            client.Institute = "Sunway College";
            client.Landline = "";
            client.LeadSource = "Facebook";
            client.MinIELTS = "4.0";
            client.Mobile = "012348744";
            client.Name = "Damith Ranjan";
            client.Passport = "ND3544";
            client.PathwayProgram1 = "";
            client.PathwayProgram2 = "";
            client.Surname = "Gunathilake";
            client.VisaAppliedDate = DateTime.UtcNow;
            client.VisaApprovedDate = DateTime.UtcNow;
            client.VisaStatus = "Pending";

            client.Save();

            return client;

        }
    }
}