using System;
using System.Linq;
using Kiwilink.Models;
using Microsoft.AspNetCore.Mvc;
using Kiwilink.ViewModels;
using MongoDB.Driver.Linq;
using MongoDB.Entities;

namespace Kiwilink.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("api/init/{employee}")]
        public ActionResult<vHome> Init(string employee)
        {
            var vm = new vHome();
            vm.Load(employee);
            return vm;
        }

        [HttpGet("api/client/load/{cid}/{employee}/{all}")]
        public ActionResult<Client> LoadClient(string cid, string employee, bool all)
        {
            var client = new Client();
            return client.Load(cid, employee, all);
        }

        [HttpPost("api/client/save")]
        public ActionResult<string> SaveClient(Client client)
        {
            client.SaveChanges();
            return client.ID.ToString();
        }

        [HttpGet("api/client/delete/{cid}")]
        public IActionResult DeleteClient(string cid)
        {
            var client = new Client();
            client.Delete(cid);
            return Ok();
        }

        [HttpGet("api/tasks/fetch/{employee}/{all}/{cid}")]
        public ActionResult<Task[]> FetchTasks(string employee, Boolean all, string cid)
        {
            return new Task().FetchTasks(employee, all, cid);
        }

        [HttpPost("api/task/save")]
        public ActionResult<string> SaveTask(vTask vm)
        {
            return vm.SaveChanges();
        }

        [HttpGet("api/task/complete/{id}")]
        public IActionResult CompleteTask(string id)
        {
            var task = new Task();
            task.MarkComplete(id);
            return Ok();
        }

        [HttpGet("api/add-employee/{name}/{pass}")]
        public ActionResult<Employee> AddEmployee(string name, string pass)
        {
            var emp = new Employee() { Name = name.TitleCaseMe(), Password = pass };
            emp.SaveChanges();
            return emp;
        }

        [HttpPost("api/employee/authenticate")]
        public ActionResult<Employee> Authenticate(vLogin vm)
        {
            var employee = vm.Authenticate();
            if (employee != null)
            {
                return employee;
            }

            return BadRequest();
        }

        [HttpGet("api/search/{term}/{type}")]
        public ActionResult<vTeaser[]> Search(string term, string type)
        {

            var clients = from c in DB.Queryable<Client>()
                          select c;

            if (term != "null")
            {
                switch (type)
                {
                    case "Name":
                        clients = clients.Where(c => c.Name.ToLower().Contains(term.ToLower()));
                        break;
                    case "Passport":
                        clients = clients.Where(c => c.Passport.ToLower().Contains(term.ToLower()));
                        break;
                    case "Mobile":
                        clients = clients.Where(c => c.Mobile.ToLower().Contains(term.ToLower()));
                        break;
                    case "Country":
                        clients = clients.Where(c => c.CourseCountry.ToLower().Contains(term.ToLower()));
                        break;
                    case "Institute":
                        clients = clients.Where(c => c.Institute.ToLower().Contains(term.ToLower()));
                        break;
                    case "Course":
                        clients = clients.Where(c => c.Course.ToLower().Contains(term.ToLower()));
                        break;
                    default:
                        break;
                }
            }

            return (from c in clients
                    orderby c.ModifiedOn descending
                    select new vTeaser()
                    {
                        Course = c.Course,
                        ID = c.ID,
                        Institute = c.Institute,
                        Mobile = c.Mobile,
                        Name = c.Name + " " + c.Surname
                    }).Take(100).ToArray();
        }
    }

}