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

        public async Task<IEnumerable<TodoItem>> GetToDoItem()
        {
            var todoitems = await _context.TodoItems.AsNoTracking().ToListAsync();
            return todoitems;
        }


        [HttpPost("{id:int}")]

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
        
            var todo = await _context.TodoItems.FindAsync(id);
           
            if(todo == null)
            {
                return NotFound();
            }
           
            _context.Remove(todo);
           
            var result = await _context.SaveChangesAsync();
        
            if (result > 0)
            {
                return Ok("Item was deleted");
            }
         
            return BadRequest("Unable to remove item");


        }

         [HttpGet("{id:int}")]
        public async Task<ActionResult<TodoItem>> GetToDoItems(int id)
        {
            var toDoItem = await _context.TodoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound($"Sorry, item {id} was not found...");
            }
            return Ok(toDoItem);
        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> EditToDoItem(int id, TodoItem toDoItems)
        {
          
            var toDoItemFromDb = await _context.TodoItems.FindAsync(id);
          
            if(toDoItemFromDb == null)
            {
                return BadRequest($"toDoItem {id} was not found.");
            }
            // if the item at the id requested is found
            toDoItemFromDb.TaskOne = toDoItems.TaskOne;
            toDoItemFromDb.TaskTwo = toDoItems.TaskTwo;
            toDoItemFromDb.TaskThree = toDoItems.TaskThree;

        
            var result = await _context.SaveChangesAsync();

         
            if(result > 0)
            {
                return Ok($"toDoItem update {id} was updated");
            }

            // if the result was not saved properly
            return BadRequest($"Unable to update toDoItem {id} info");

        }

        }

       
}