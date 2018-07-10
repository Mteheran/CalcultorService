namespace Calculator.Server.Controllers
{
    using CalculatorService.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;


    [Produces("application/json")]
    [Route("calculator")]
    public class CalculatorController : Controller
    {
       [HttpPost]
       [Route("add")]
       public double Add([FromBody] IEnumerable<double> numericList) => numericList.ToList().Sum();

       [HttpPost]
       [Route("sub")]
       public double Sub([FromBody] SubModel subModel) => (subModel.Minuend - subModel.Subtrahend);

       [HttpPost]
       [Route("mult")]
       public double Mult([FromBody] IEnumerable<double> numericList) => numericList.ToList().Aggregate((a, b) => a * b);

       [HttpPost]
       [Route("div")]
       public double Div([FromBody] DivModel divModel) => (divModel.Dividend/ divModel.Divisor);
    }
}