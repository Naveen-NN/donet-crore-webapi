using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiDISample.Interfaces;

namespace WebApiDISample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        ITodoService todoService;
        public TodoController(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        [HttpGet("check")]
        public bool Check()
        {
            var result = true;
            try
            {
                this.todoService.Save(null);
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
