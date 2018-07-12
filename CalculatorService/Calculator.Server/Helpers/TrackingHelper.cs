namespace Calculator.Server.Helpers
{
    using Microsoft.AspNetCore.Http;

    public static class TrackingHelper
    {
        public static string GetHeaderValue(HttpRequest httpRequest)
        {
            return httpRequest.Headers["X‐Evi‐Tracking‐Id"];
        }    
        
    }
}
