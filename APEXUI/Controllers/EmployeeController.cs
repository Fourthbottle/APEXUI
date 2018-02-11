using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using APEXUI.ServiceCall;
using APEXUI.Models;

namespace APEXUI.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeConsumer consumer = new EmployeeConsumer();
        // GET: Employee
     
        [HttpGet]

        public ActionResult Details()
        {
            try
            {
                if (Session["Uid"] == null || Session["Uid"].Equals(0))
                    return RedirectToAction("Login", "Login", new { E = 1 });
                if (Request.QueryString["E"]=="1")
                     ModelState.AddModelError(string.Empty, "Complete your basic details to go further");
                int UserId = Convert.ToInt32(Session["Uid"]);
                IRestResponse response = consumer.GetEmployeeDetails(UserId);
                if ((int)response.StatusCode == 200)
                {
                    var employee = JsonConvert.DeserializeObject<EmployeeDetailsBO>(response.Content);
                    Session["EmpId"] = employee.id;
                    return View(employee);
                }
                else
                {
                    if (ModelState.IsValid)
                        ModelState.AddModelError(string.Empty, "Something wrong, please raise the issue with support");
                }
            }
            catch (Exception es)
            {
                ModelState.AddModelError(string.Empty, es.Message);
            }
            return View();
        }

        public ActionResult Edit()
        {
            try
            {
                int UserId = Convert.ToInt32(Session["Uid"]);
                IRestResponse response = consumer.GetEmployeeDetails(UserId);
                if ((int)response.StatusCode == 200)
                {
                    var employee = JsonConvert.DeserializeObject<EmployeeDetailsBO>(response.Content);
                    if (Session["EmpId"] == null)
                    {
                        Session["EmpId"] = employee.id;
                    }
                    ViewBag.EmpId = employee.id;
                    return View(employee);
                }
                else
                {
                    if (ModelState.IsValid)
                        ModelState.AddModelError(string.Empty, "Something wrong, please raise the issue with support");
                }
            }
            catch (Exception es)
            {
                ModelState.AddModelError(string.Empty, es.Message);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(EmployeeDetailsBO emp)
        {
            try
            {
                int UserId = Convert.ToInt32(Session["Uid"]);
                emp.UserId = UserId;
                IRestResponse response = consumer.UpdateEmployeeDetails(emp);
                if ((int)response.StatusCode == 200)
                {
                    var employee = JsonConvert.DeserializeObject<EmployeeDetailsBO>(response.Content);
                    return RedirectToAction("Details", "Employee");
                }
                else
                {
                    if (ModelState.IsValid)
                        ModelState.AddModelError(string.Empty, "Something wrong, please raise the issue with support");
                }
            }
            catch (Exception es)
            {
                ModelState.AddModelError(string.Empty, es.Message);
            }
            return View();
        }
    }
}