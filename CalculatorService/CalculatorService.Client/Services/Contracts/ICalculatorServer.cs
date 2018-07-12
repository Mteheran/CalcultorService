namespace CalculatorService.Client.Services.Contracts
{
    using CalculatorService.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICalculatorServer
    {
        string TrackingID { get; set; }

        Task<double> Add(IEnumerable<double> numericList);

        Task<double> Sub(SubModel SubModel);

        Task<double> Mult(IEnumerable<double> numericList);

        Task<double> Div(DivModel divModel);

        Task<double> Sqrt(double number);
    }
}
