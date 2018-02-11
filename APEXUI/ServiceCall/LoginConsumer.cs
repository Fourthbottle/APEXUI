using System.Configuration;
using RestSharp;
using APEXUI.Models;
using Newtonsoft.Json;

namespace APEXUI.ServiceCall
{
    public class LoginConsumer
    {
        public string Url;
        public LoginConsumer()
        {
            Url = ConfigurationManager.AppSettings["DomainName"].ToString();
        }
        public IRestResponse CheckUser(LoginBO credentials)
        {
            var client = new RestClient(Url + ApexConfig.CheckUser);
            var request = new RestRequest(Method.POST);
            string jsonRequest = JsonConvert.SerializeObject(credentials);
            request.AddParameter(
                              "application/json; charset=utf-8",
                              jsonRequest,
                              ParameterType.RequestBody);
            request.AddBody(jsonRequest);
            var response = client.Execute(request);
            return response;
        }
    }
}