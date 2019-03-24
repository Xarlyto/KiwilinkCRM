using System;
using System.Collections.Generic;
using System.Linq;
using API_Server.Data;
using API_Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using API_Server.ViewModels;

namespace API_Server.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("api/home")]
        public ActionResult<vHome> Home()
        {
            //System.Threading.Tasks.Task.Delay(3000).Wait();
            var vm = new vHome();
            vm.Load();
            return vm;
        }    

        [HttpGet("api/client/load/{id}")]
        public ActionResult<Client> LoadClient(string id)
        {
            var client = new Client();
            return client.Load(id);
        }

        [HttpPost("api/client/save")]
        public ActionResult<string> SaveClient(Client client)
        {
            client.Save();
            return client.Id.ToString();
        }

        [HttpPost("api/task/save")]
        public ActionResult<string> SaveTask(Task task)
        {
            task.Save();
            return task.Id.ToString();
        }

        [HttpGet("api/task/complete/{id}")]
        public IActionResult CompleteTask(string id)
        {
            var task = new Task();
            task.MarkComplete(new ObjectId(id));
            return Ok();
        }

        [HttpGet("api/add-employee/{name}/{pass}")]
        public ActionResult<Employee> AddEmployee(string name, string pass)
        {
            var emp = new Employee() { Name = name.TitleCaseMe(), Password =pass };
            emp.Save();
            return emp;
        }

        [HttpPost("api/employee/authenticate")]
        public ActionResult<Employee> Authenticate(vLogin vm)
        {
            var employee = vm.Authenticate();
            if (employee !=null) {
                return employee;
            }

            return BadRequest();
        }
    }

}