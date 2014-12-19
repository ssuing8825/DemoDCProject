using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace DemoDCProject.Services
{
    public class DCService
    {
        public string CallDuckCreek(string request)
        {
            using (var httpClient = new HttpClient())
            {
                var req = new HttpRequestMessage
                {
                    RequestUri = new Uri(ConfigurationManager.AppSettings["DCServiceUrl"]),
                    Method = HttpMethod.Post,
                    Content = new StringContent(request, Encoding.UTF8, "application/xml")
                };
             //   req.Headers.Add("Authorization", "Basic " + ConfigurationManager.AppSettings["AzureAuth"]);
                var resp = httpClient.SendAsync(req).Result;
                return resp.Content.ReadAsStringAsync().Result;
            }
        }
    }
}