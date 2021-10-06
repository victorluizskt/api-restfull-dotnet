using api_restful.Business.Implementations;
using api_restful.Controllers.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(
            ILogger<PersonController> logger,
            IPersonBusiness personBusiness
        )
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        #region 
        [HttpGet]
        public IActionResult Get(
        )
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(
            [FromRoute] long id
        )
        {
            var person = _personBusiness.FindById(id);

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

            return Ok(_personBusiness.Create(person));
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

            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            [FromRoute] long id
        )
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
        #endregion
    }
}
