using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APEXUI.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Configuration;

namespace APEXUI.ServiceCall
{
    public class EmployerConsumer
    {
        public string Url;
        public EmployerConsumer()
        {
            Url = ConfigurationManager.AppSettings["DomainName"].ToString();
        }

        public IRestResponse InsertEmployerDetails(EmployerBO EmpBO)
        {
            var client = new RestClient(Url + ApexConfig.InsertEmployerDetails);
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


        //public IRestResponse GetEmployerDetails(int Uid)
        //{
        //    var client = new RestClient(Url + ApexConfig.GetEmployerDetails + Uid.ToString());
        //    var request = new RestRequest(Method.GET);
        //    var response = client.Execute(request);
        //    return response;
        //}
    }
}