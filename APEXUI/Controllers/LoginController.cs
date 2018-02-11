using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APEXUI.Models;
using Newtonsoft.Json;
using APEXUI.ServiceCall;

namespace APEXUI.Controllers
{
    public class LoginController : Controller
    {
        LoginConsumer consumer = new LoginConsumer();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginBO credentials)
        {
            try
            {
                LoginBO login = new LoginBO();
                var response = consumer.CheckUser(credentials);
                if ((int)response.StatusCode == 200)
                {
                    var user = JsonConvert.DeserializeObject<LoginBO>(response.Content);
                    Session["Uid"] = user.id;
                    if (!user.Empid.Equals(0))
                        Session["EmpId"] = user.Empid;
                    return RedirectToAction("Details", "Employee");
                }
                else if ((int)response.StatusCode == 401)
                {
                    ModelState.AddModelError(string.Empty, "UserId and password missmatch");
                }
                else if((int)response.StatusCode==0)
                {
                    if (ModelState.IsValid)
                        ModelState.AddModelError(string.Empty, "Apex service unavilable");
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