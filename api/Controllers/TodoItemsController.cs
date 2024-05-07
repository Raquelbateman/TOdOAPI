using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {

        private readonly AppDbContext _context;
      public TodoItemsController(AppDbContext context)
      {
        _context = context;

      }
        [HttpGet]

        public async Task<IEnumerable<TodoItem>> getToDo()
        {
            var todoitems = await _context.TodoItems.AsNoTracking().ToListAsync();
            return todoitems;
        }
        [HttpPost]

        public async Task<IActionResult> Create(TodoItem todo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _context.AddAsync(todo);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        



        }

       
}