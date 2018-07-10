namespace CalculatorService.Client.Services
{
    using CalculatorService.Client.Services.Contracts;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    
    public class CalculatorServer: ICalculatorServer
    {
       HttpClient _httpClient => new HttpClient();

       string serviceUri = "calculator";
       string baseUrl = "http://localhost:50726/";

       private string buildUrl(string Method) => baseUrl + serviceUri + "/"  + Method;

       private StringContent builContent<T>(T content)
       {
            return new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json");
       }

       public async Task<double> Add(IEnumerable<double> numericList)
       {          
            var response = await _httpClient.PostAsync(buildUrl("add"), builContent(numericList) );

            return JsonConvert.DeserializeObject<double>(await response.Content.ReadAsStringAsync());
       }

    }
}
