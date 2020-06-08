using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApiSample.ApiEntities;  

namespace TodoApiSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        public TodoController()
        {

        }

        [HttpGet]
        public IEnumerable<TodoItem> List()
        {
            return null;
        }

        [HttpGet("{id}")]
        public TodoItem Get(int id)
        {
            return null;
        }

        [HttpPost]
        public IActionResult Create(TodoItem item)
        {
            //Code to insert values into DB 
            item.Id = 1;
            return CreatedAtAction(nameof(Create), new { id =item.Id}, item);
        }


        [HttpPost]
        [Route("bulkcreate")]
        public IActionResult BulkCreate(IEnumerable<TodoItem> items)
        {
            //Code to insert values into DB 
            return CreatedAtAction(nameof(BulkCreate), items);
        }


        [HttpPut]
        public IActionResult Update(TodoItem item)
        {
            if(item == null || !item.Id.HasValue) return BadRequest();
            
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
