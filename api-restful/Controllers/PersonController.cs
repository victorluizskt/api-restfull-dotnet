using api_restful.Controllers.Model;
using api_restful.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;
        public PersonController(
            ILogger<PersonController> logger,
            IPersonService personService
        )
        {
            _logger = logger;
            _personService = personService;

        }

        #region 
        [HttpGet]
        public IActionResult Get(
        )
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(
            [FromRoute] long id
        )
        {
            var person = _personService.FindById(id);

            if(person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Pott(
            [FromBody] Person person
        )
        {
            if (person == null)
            {
                return BadRequest();
            }

            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put(
            [FromBody] Person person
        )
        {
            if (person == null)
            {
                return BadRequest();
            }

            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            [FromRoute] long id
        )
        {
            _personService.Delete(id);
            return NoContent();
        }
        #endregion
    }
}
