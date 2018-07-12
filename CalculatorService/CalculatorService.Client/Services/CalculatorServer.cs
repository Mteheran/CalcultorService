namespace CalculatorService.Client.Services
{
    using CalculatorService.Client.Services.Contracts;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using CalculatorService.Models;

    public class CalculatorServer: ICalculatorServer
    {
       HttpClient _httpClient => new HttpClient();

       string serviceUri = "calculator";
       string baseUrl = "http://localhost:50726/";

       public string TrackingID { get; set; }
        
       private string buildUrl(string Method) => baseUrl + serviceUri + "/"  + Method;

       private StringContent builContent<T>(T content)
       {
            return new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json");
       }

       private void AddHeaderParameters()
       {
            if(!string.IsNullOrEmpty(TrackingID))
                _httpClient.DefaultRequestHeaders.Add("X‐Evi‐Tracking‐Id", TrackingID);
       }

       public async Task<double> Add(IEnumerable<double> numericList)
       {
            AddHeaderParameters();

            var response = await _httpClient.PostAsync(buildUrl("add"), builContent(numericList) );

            return JsonConvert.DeserializeObject<double>(await response.Content.ReadAsStringAsync());
       }

        public async Task<double> Sub(SubModel SubModel)
        {
            AddHeaderParameters();

            var response = await _httpClient.PostAsync(buildUrl("sub"), builContent(SubModel));

            return JsonConvert.DeserializeObject<double>(await response.Content.ReadAsStringAsync());
        }

        public async Task<double> Mult(IEnumerable<double> numericList)
        {
            AddHeaderParameters();

            var response = await _httpClient.PostAsync(buildUrl("mult"), builContent(numericList));

            return JsonConvert.DeserializeObject<double>(await response.Content.ReadAsStringAsync());
        }


        public async Task<double> Div(DivModel divModel)
        {
            AddHeaderParameters();

            var response = await _httpClient.PostAsync(buildUrl("div"), builContent(divModel));

            return JsonConvert.DeserializeObject<double>(await response.Content.ReadAsStringAsync());
        }

        public async Task<double> Sqrt(double number)
        {
            AddHeaderParameters();

            var response = await _httpClient.PostAsync(buildUrl("sqrt"), builContent(number));

            return JsonConvert.DeserializeObject<double>(await response.Content.ReadAsStringAsync());
        }

    }
}
