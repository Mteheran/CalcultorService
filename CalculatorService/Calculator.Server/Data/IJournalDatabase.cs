namespace Calculator.Server.Data
{
    using CalculatorService.Models;
    using System.Collections.Generic;

    public interface IJournalDatabase
    {
        bool Save(OperationModel operationModel);

        IEnumerable<OperationModel> GetOperations(string trackingId);
    }
}
