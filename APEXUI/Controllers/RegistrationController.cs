using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APEXUI.Models;
using APEXUI.ServiceCall;
using RestSharp;

namespace APEXUI.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult confirmlogin()
        {
            return View();
        }
        public ActionResult Index(RegistrationBO reg)
        {
            try
            {
                RegisterConsumer regSer = new RegisterConsumer();
                IRestResponse response = regSer.RegisterNewUser(reg);
                if ((int)response.StatusCode == 201)
                {
                    return View("RegistrationConfirmation");
                }
                // code for user created Successfully.
                else if ((int)response.StatusCode == 409)
                {
                    ModelState.AddModelError(string.Empty, "Email Id already registered. please login to continue.");
                }
                // show use that Email already registered.
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

        public ActionResult RegistrationConfirmation()
        {
            return View();
        }
    }
}