using System;
using System.Collections.Generic;
using System.Linq;
using APEXUI.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Web;
using System.Configuration;

namespace APEXUI.ServiceCall
{
    public class WorkHistoryConsumer
    {
        public string Url;
        public WorkHistoryConsumer()
        {
            Url = ConfigurationManager.AppSettings["DomainName"].ToString();
        }
        public IRestResponse InsertWorkHistory(WorkHistoryBO work)
        {
            var client = new RestClient(Url + ApexConfig.AddWorkHistory);
            var request = new RestRequest(Method.POST);
            string jsonRequest = JsonConvert.SerializeObject(work);
            request.AddParameter(
                              "application/json; charset=utf-8",
                              jsonRequest,
                              ParameterType.RequestBody);
            request.AddBody(jsonRequest);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse GetWorkHistory(int Uid)
        {
            var client = new RestClient(Url + ApexConfig.GetWorkHistory + Uid.ToString());
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse GetWorkHistory(int WHID, int EmpId)
        {
            var client = new RestClient(Url + ApexConfig.GetWorkHistory + "?WHID=" + WHID + "&EmpId=" + EmpId);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse UpdateWorkHistory(WorkHistoryBO work)
        {
            var client = new RestClient(Url + ApexConfig.UdpateWorkHistory);
            var request = new RestRequest(Method.PUT);
            string jsonRequest = JsonConvert.SerializeObject(work);
            request.AddParameter(
                              "application/json; charset=utf-8",
                              jsonRequest,
                              ParameterType.RequestBody);
            request.AddBody(jsonRequest);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse DeleteWorkHistory(int id, int EmpId)
        {
            var client = new RestClient(Url + ApexConfig.DeleteWorkHistory+"?id="+id+"&EmpId="+EmpId);
            var request = new RestRequest(Method.DELETE);
            var response = client.Execute(request);
            return response;
        }
    }
}