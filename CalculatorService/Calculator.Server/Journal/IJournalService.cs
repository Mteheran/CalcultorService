namespace Calculator.Server.Journal
{
    using CalculatorService.Models;
    using System.Collections.Generic;

    public interface IJournalService
    {
        void Sum(string trakingId, IEnumerable<double> numericList);

        void Sub(string trakingId, SubModel subModel);

        void Mult(string trakingId, IEnumerable<double> numericList);

        void Div(string trakingId, DivModel divModel);

        void Sqrt(string trakingId, double number);
    }
}
