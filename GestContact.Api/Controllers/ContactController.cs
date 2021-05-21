using GestContact.Api.Models.Entities;
using GestContact.Api.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestContact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _repository.Get();
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpGet("ByName/{name?}")]
        public IEnumerable<Contact> Get(string name)
        {
            if (name is null)
                name = "";

            return _repository.Get(name);
        }

        // POST api/<ContactController>
        [HttpPost]
        public void Post([FromBody] Contact value)
        {
            _repository.Insert(value);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact value)
        {
            return _repository.Update(id, value) ? Ok() : BadRequest();
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _repository.Delete(id) ? Ok() : BadRequest();
        }
    }
}
