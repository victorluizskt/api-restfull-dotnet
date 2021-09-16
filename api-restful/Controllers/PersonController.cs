using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        #region 
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(
            [FromRoute] string firstNumber,
            [FromRoute] string secondNumber
        )
        {
           

            return BadRequest("Invalid input");
        }
        #endregion
    }
}
