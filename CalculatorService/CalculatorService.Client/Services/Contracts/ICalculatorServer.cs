namespace CalculatorService.Client.Services.Contracts
{
    using CalculatorService.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICalculatorServer
    {
        Task<double> Add(IEnumerable<double> numericList);

        Task<double> Sub(SubEntity SubModel);
    }
}
