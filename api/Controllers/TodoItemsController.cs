using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ControllerBase
    {
        [HttpGet]
        public string SayHi(){
             return "Hi from me";
    }
        }

       
}