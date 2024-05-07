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

        public async Task<IEnumerable<TodoItem>> getToDoItem()
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

 [HttpDelete("{id:int}")]
        // this http request will delete a todo item
        public async Task<IActionResult> Delete(int id)
        {
            // make variable to hold the data from our AppDBContext 
            var todo = await _context.TodoItems.FindAsync(id);
            // Check if empty and give notfound
            if(todo == null)
            {
                return NotFound();
            }
            // remove the item toDoItem based on id from parameter
            _context.Remove(todo);
            // save the result of the changes
            var result = await _context.SaveChangesAsync();
            // if the result ocurred give okay response
            if (result > 0)
            {
                return Ok("Item was deleted");
            }
            // if result > 0 failed return badrequest & custom response
            return BadRequest("Unable to delete todo item");


        }

        }

       
}