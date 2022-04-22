using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techdome.API.Model;
using static Techdome.API.Model.MyClass;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Techdome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly InlineDatabaseContext Context;
        public TodoController(InlineDatabaseContext context)
        {
            Context = context;
        }
        // GET api/<TodoController>/5

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // GET: api/<TodoController>
        [HttpGet("getall")]
        public IEnumerable<Member> GetAll()
        {
            return Context.Config.ToList();
        }
        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // POST api/<TodoController>
        [HttpPost("create/{id}")]
        public void Post([FromBody] string value)
        {
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
