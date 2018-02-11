using System.Configuration;
using RestSharp;
using APEXUI.Models;
using Newtonsoft.Json;


namespace APEXUI.ServiceCall
{
    public class EmployeeConsumer
    {
        public string Url;
        public EmployeeConsumer()
        {
            Url = ConfigurationManager.AppSettings["DomainName"].ToString();
        }

        public IRestResponse InsertEmployeeDetails(EmployeeDetailsBO EmpBO)
        {
            var client = new RestClient(Url + ApexConfig.AddEmployeeDetails);
            var request = new RestRequest(Method.POST);
            string jsonRequest = JsonConvert.SerializeObject(EmpBO);
            request.AddParameter(
                              "application/json; charset=utf-8",
                              jsonRequest,
                              ParameterType.RequestBody);
            request.AddBody(jsonRequest);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse GetEmployeeDetails(int Uid)
        {
            var client = new RestClient(Url + ApexConfig.GetEmployeeDetails+Uid.ToString());
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse UpdateEmployeeDetails(EmployeeDetailsBO EmpBO)
        {
            var client = new RestClient(Url + ApexConfig.UdpateEmployeeDetails+EmpBO.UserId);
            var request = new RestRequest(Method.PUT);
            string jsonRequest = JsonConvert.SerializeObject(EmpBO);
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