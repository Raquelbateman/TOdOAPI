using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ControllerBase
    {

        private readonly AppDbContext _context;
      public TodoItemsController(AppDbContext context)
      {
        _context = context;

      }
        

        }

       
}