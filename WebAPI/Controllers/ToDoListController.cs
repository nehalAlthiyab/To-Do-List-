using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToDoListController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public ToDoListController(AuthenticationContext context)
        {
            _context = context;
        }


        // GET: api/<ToDoList>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoList>>> GetToDoList()

        {
            var ToDoList = await _context.ToDoList.ToListAsync();
            return ToDoList;
        }
        
        // GET api/<ToDoList>id 
        [HttpGet("{id}")]
        
        public async Task<ActionResult<ToDoList>> GetToDoList(int id)
        {
            var ToDoList = await _context.ToDoList.FindAsync(id);

            if (ToDoList == null)
            {
                return NotFound();
            }
            ToDoList.Id = id;
            return ToDoList;
        }

        // POST api/<ToDoList>
        [HttpPost]
        public async Task<ActionResult<ToDoList>> PostToDoList(ToDoList toDoList)
        {
            if (!ModelState.IsValid)
                return NotFound();
            _context.ToDoList.Add(toDoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToDoList), new { id = toDoList.Id }, toDoList);
        }

        // PUT api/<ToDoList>/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoList(int id, ToDoList toDoList)
        {
            if (id != toDoList.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoList).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<ToDoList>/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            var toDoList = await _context.ToDoList.FindAsync(id);

            if (toDoList == null)
            {
                return NotFound();
            }

            _context.ToDoList.Remove(toDoList);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}