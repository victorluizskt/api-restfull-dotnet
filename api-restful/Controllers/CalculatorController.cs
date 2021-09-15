using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;
        public CalculatorController(ILogger<CalculatorController> logger)
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
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("subtraction/{fistNumber}/{secondNumber}")]
        public IActionResult Subtraction(
            [FromRoute] string firstNumber,
            [FromRoute] string secondNumber
        )
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtraction.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(
            [FromRoute] string firstNumber,
            [FromRoute] string secondNumber
        )
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiplication.ToString());
            }

            return BadRequest("Invalid input");
        }
        
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division (
            [FromRoute] string firstNumber,
            [FromRoute] string secondNumber
        )
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(division.ToString());
            }

            return BadRequest("Invalid input");
        }
        #endregion

        private static bool IsNumeric(string strNumber)
        {
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out _);

            return isNumber;
        }

        private static decimal ConvertToDecimal(string strNumber)
        {
            if (decimal.TryParse(strNumber, out decimal decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }
    }
}
