using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using APEXUI.Models;
using Newtonsoft.Json;
using System.Configuration;

namespace APEXUI.ServiceCall
{
    public class SkillConsumer
    {
        public string Url;
        public SkillConsumer()
        {
            Url = ConfigurationManager.AppSettings["DomainName"].ToString();
        }
        public IRestResponse AddnewSkill(SkillsBO skill)
        {
            try
            {
                var client = new RestClient(Url + ApexConfig.AddSkills);
                var request = new RestRequest(Method.POST);
                string jsonRequest = JsonConvert.SerializeObject(skill);
                request.AddParameter(
                                  "application/json; charset=utf-8",
                                  jsonRequest,
                                  ParameterType.RequestBody);
                request.AddBody(jsonRequest);
                var response = client.Execute(request);
                return response;
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public IRestResponse GetSkills(int EmpId)
        {
            try
            {
                var client = new RestClient(Url + ApexConfig.GetSkills + EmpId);
                var request = new RestRequest(Method.GET);
                return client.Execute(request);

            }
            catch (Exception es)
            {
                throw es;
            }
        }
    }
}