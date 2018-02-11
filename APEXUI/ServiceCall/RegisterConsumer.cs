using System.Configuration;
using RestSharp;
using APEXUI.Models;
using Newtonsoft.Json;

namespace APEXUI.ServiceCall
{
    public class RegisterConsumer
    {
        public string Url;
        public RegisterConsumer()
        {
            Url = ConfigurationManager.AppSettings["DomainName"].ToString();
        }

        public IRestResponse RegisterNewUser(RegistrationBO regBO)
        {
            var client = new RestClient(Url + ApexConfig.RegisterNewUserUri);
            var request = new RestRequest(Method.POST);
            string jsonRequest = JsonConvert.SerializeObject(regBO);
            request.AddParameter(
                              "application/json; charset=utf-8",
                              jsonRequest,
                              ParameterType.RequestBody );
            request.AddBody(jsonRequest);
            var response = client.Execute(request);
            return response;
        }
    }
}