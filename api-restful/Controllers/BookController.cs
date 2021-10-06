using api_restful.Business.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api_restful.Controllers.Model;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(
            ILogger<BookController> logger,
            IBookBusiness bookBusiness
        )
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        #region 
        [HttpGet]
        public IActionResult Get(
        )
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(
            [FromRoute] int id
        )
        {
            var book = _bookBusiness.FindById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Pott(
            [FromBody] Book book
        )
        {
            if (book == null)
            {
                return BadRequest();
            }

            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Put(
            [FromBody] Book book
        )
        {
            if (book == null)
            {
                return BadRequest();
            }

            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            [FromRoute] int id
        )
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
        #endregion
    }
}
