using System.Collections.Generic;
using Calculator.Server.Data;
using CalculatorService.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/journal")]
    public class JournalController : Controller
    {
        IJournalDatabase journaldatabase { get; set; }

        public JournalController(IJournalDatabase journalParameter)
        {
            journaldatabase = journalParameter;
        }

        [HttpPost]
        [Route("query")]
        public IEnumerable<OperationModel> Query([FromBody] string Id)
        {
            return journaldatabase.GetOperations(Id);
        }
    }
}