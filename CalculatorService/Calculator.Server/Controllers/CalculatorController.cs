namespace Calculator.Server.Controllers
{
    using Calculator.Server.Helpers;
    using Calculator.Server.Journal;
    using CalculatorService.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    [Produces("application/json")]
    [Route("calculator")]
    public class CalculatorController : Controller
    {
        IJournalService journal { get; set; }

        public CalculatorController(IJournalService journalParameter)
        {
            journal = journalParameter;
        }

        [HttpPost]
        [Route("add")]
        public double Add([FromBody] IEnumerable<double> numericList)
        {
            journal.Sum(TrackingHelper.GetHeaderValue(Request), numericList);
            return numericList.ToList().Sum();
        }

        [HttpPost]
        [Route("sub")]
        public double Sub([FromBody] SubModel subModel)
        {
            journal.Sub(TrackingHelper.GetHeaderValue(Request), subModel);
            return (subModel.Minuend - subModel.Subtrahend);
        }

        [HttpPost]
        [Route("mult")]
        public double Mult([FromBody] IEnumerable<double> numericList)
        {
            journal.Mult(TrackingHelper.GetHeaderValue(Request), numericList);
            return numericList.ToList().Aggregate((a, b) => a * b);
        }

        [HttpPost]
        [Route("div")]
        public double Div([FromBody] DivModel divModel)
        {
            journal.Div(TrackingHelper.GetHeaderValue(Request), divModel);
            return (divModel.Dividend / divModel.Divisor);
        }

        [HttpPost]
        [Route("sqrt")]
        public double Sqrt([FromBody] double number)
        {
            journal.Sqrt(TrackingHelper.GetHeaderValue(Request), number);
            return System.Math.Sqrt(number);
        }
    }
}