namespace CalculatorService.Client.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICalculatorServer
    {
        Task<double> Add(IEnumerable<double> numericList);
    }
}
