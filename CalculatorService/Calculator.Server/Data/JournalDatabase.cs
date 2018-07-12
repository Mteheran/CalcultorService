namespace Calculator.Server.Data
{
    using CalculatorService.Models;
    using System.Collections.Generic;

    public class JournalDatabase: IJournalDatabase
    {
        public bool Save(OperationModel operationModel)
        {
            //save everything in the database
            return true;
        }

        public IEnumerable<OperationModel> GetOperations(string trackingId)
        {
            //get the list from the database
            return new List<OperationModel>();
        }
    }
}
