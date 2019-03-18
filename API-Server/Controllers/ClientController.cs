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
            var x = (from c in DB.Collection<Client>() select c).ToArray();

            return x.First();
        }
    }
}