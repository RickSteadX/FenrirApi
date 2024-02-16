using FenrirApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace FenrirApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRepository _personRepository;

        public PersonController(ILogger<PersonController> logger, IPersonRepository personRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _personRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(Guid id)
        {
            var person = _personRepository.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public ActionResult<Person> Create(Person person)
        {
            _personRepository.Add(person);
            _personRepository.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        [HttpPut]
        public IActionResult Update([FromQuery] Guid Id, Person person)
        {
            if (Id != person.Id)
            {
                return BadRequest();
            }

            _personRepository.Update(person);
            _personRepository.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] Guid Id)
        {
            var person = _personRepository.GetById(Id);

            if (person == null)
            {
                return NotFound();
            }

            _personRepository.Delete(person);
            _personRepository.SaveChanges();

            return Ok();
        }
    }
}
