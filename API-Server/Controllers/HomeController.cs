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
            var a = ModelState;
            var x = client;
            return "ok";
        }
    }

}