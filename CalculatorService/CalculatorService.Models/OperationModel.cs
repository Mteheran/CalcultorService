using System;

namespace CalculatorService.Models
{
    public class OperationModel
    {
        public string Id { get; set; }
        public string Operation { get; set; }
        public string Calculation { get; set; }
        public DateTime Date { get; set; }
    }
}
