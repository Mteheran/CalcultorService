namespace Calculator.Server.Journal
{
    using Calculator.Server.Data;
    using CalculatorService.Models;
    using System;
    using System.Collections.Generic;

    public class JournalService: IJournalService
    {
        IJournalDatabase _journalDatabase { get; set; }

        public JournalService(IJournalDatabase journalDatabase)
        {
            _journalDatabase = journalDatabase;
        }

        public void Sum(string trakingId, IEnumerable<double> numericList)
        {
            if (!string.IsNullOrEmpty(trakingId))
            {
                var operationModel = new OperationModel();
                operationModel.Id = trakingId;
                operationModel.Operation = "Sum";
                operationModel.Calculation = string.Join("+", numericList);
                operationModel.Date = DateTime.Now;

                _journalDatabase.Save(operationModel);
            }
        }

        public void Sub(string trakingId, SubModel subModel)
        {
            if (!string.IsNullOrEmpty(trakingId))
            {
                var operationModel = new OperationModel();
                operationModel.Id = trakingId;
                operationModel.Operation = "Sub";
                operationModel.Calculation = $"{subModel.Minuend}-{subModel.Subtrahend}";
                operationModel.Date = DateTime.Now;

                _journalDatabase.Save(operationModel);
            }
        }

        public void Mult(string trakingId, IEnumerable<double> numericList)
        {
            if (!string.IsNullOrEmpty(trakingId))
            {
                var operationModel = new OperationModel();
                operationModel.Id = trakingId;
                operationModel.Operation = "Mult";
                operationModel.Calculation = string.Join("*", numericList);
                operationModel.Date = DateTime.Now;

                _journalDatabase.Save(operationModel);
            }
        }

        public void Div(string trakingId, DivModel divModel)
        {
            if (!string.IsNullOrEmpty(trakingId))
            {
                var operationModel = new OperationModel();
                operationModel.Id = trakingId;
                operationModel.Operation = "Div";
                operationModel.Calculation = $"{divModel.Dividend}-{divModel.Divisor}";
                operationModel.Date = DateTime.Now;

                _journalDatabase.Save(operationModel);
            }
        }

        public void Sqrt(string trakingId, double number)
        {
            if (!string.IsNullOrEmpty(trakingId))
            {
                var operationModel = new OperationModel();
                operationModel.Id = trakingId;
                operationModel.Operation = "Sqrt";
                operationModel.Calculation = $"Sqrt({number})";
                operationModel.Date = DateTime.Now;

                _journalDatabase.Save(operationModel);
            }
        }
    }
}
