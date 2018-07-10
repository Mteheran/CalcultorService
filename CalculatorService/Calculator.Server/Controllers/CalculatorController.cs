namespace Calculator.Server.Controllers
{
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
    }
}