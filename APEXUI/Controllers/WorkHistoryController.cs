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
    public class WorkHistoryController : Controller
    {
        WorkHistoryConsumer consumer = new WorkHistoryConsumer();
        // GET: WorkHistory
        public ActionResult Details()
        {

            try
            {
                if (Session["EmpId"] == null || Session["EmpId"].Equals(0))
                    return RedirectToAction("Details", "Employee", new { E = 1 });

                int EmpId = Convert.ToInt32(Session["EmpId"]);
                var response = consumer.GetWorkHistory(EmpId);
                if ((int)response.StatusCode == 200)
                {
                    var WorkHistory = JsonConvert.DeserializeObject<List<WorkHistoryBO>>(response.Content);
                    return View(WorkHistory);
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
        public ActionResult InsertWorkHistory(WorkHistoryBO workHistory)
        {
            workHistory.EmpId = (int)Session["EmpId"];
            var response = consumer.InsertWorkHistory(workHistory);

            var responseWorkHistory = JsonConvert.DeserializeObject<WorkHistoryBO>(response.Content);
            if ((int)response.StatusCode == 201)
            {
                return Json(responseWorkHistory);
            }
            else if ((int)response.StatusCode == 401)
            {
                throw new HttpException(401, "Service failed to work as expected, bring it to our notice");
            }
            else
            {
                if (ModelState.IsValid)
                    ModelState.AddModelError(string.Empty, "Something wrong, please raise the issue with support");
                throw new HttpException(500, "Internal server error!!");
            }

        }

        [HttpGet]
        public ActionResult GetWorkHistory(int WHID)
        {
            if (Session["EmpId"] == null || Session["EmpId"].Equals(0))
                return RedirectToAction("Details", "Employee", new { E = 1 });
            int EmpId = Convert.ToInt32(Session["EmpId"]);
            var response = consumer.GetWorkHistory(WHID, EmpId);
            var responseWorkHistory = JsonConvert.DeserializeObject<WorkHistoryBO>(response.Content);
            if ((int)response.StatusCode == 201)
            {
                return Json(responseWorkHistory);
            }
            else if ((int)response.StatusCode == 401)
            {
                throw new HttpException(401, "Service failed to work as expected, bring it to our notice");
            }
            else
            {
                if (ModelState.IsValid)
                    ModelState.AddModelError(string.Empty, "Something wrong, please raise the issue with support");
                throw new HttpException(500, "Internal server error!!");
            }
        }
         
        [HttpPost]
        public ActionResult UpdateWorkHistory(WorkHistoryBO workHistory)
        {
            
            if (Session["EmpId"] == null || Session["EmpId"].Equals(0))
                return RedirectToAction("Details", "Employee", new { E = 1 });
            workHistory.EmpId = Convert.ToInt32(Session["EmpId"]);
            var response = consumer.UpdateWorkHistory(workHistory);
            var responseWorkHistory = JsonConvert.DeserializeObject<object>(response.Content);
            if ((int)response.StatusCode == 200)
            {
                return Json("Details Updated Successfully");
            }
            else if ((int)response.StatusCode == 400)
                throw new HttpException(400, "Details Not Udpated");
            else if ((int)response.StatusCode == 401)
                throw new HttpException(401, "Not Authorized to udpate details");
            else
                throw new HttpException(400, "Something wentwromg with the service");
        }

        [HttpPost]
        public ActionResult DeleteWorkHistory(int id)
        {

            if (Session["EmpId"] == null || Session["EmpId"].Equals(0))
                return RedirectToAction("Details", "Employee", new { E = 1 });

            var response = consumer.DeleteWorkHistory(id, Convert.ToInt32(Session["EmpId"]));
            if ((int)response.StatusCode == 200)
            {
                return Json("Details deleted Successfully");
            }
            else if ((int)response.StatusCode == 400)
                throw new HttpException(400, "Details Not deleted");
            else if ((int)response.StatusCode == 401)
                throw new HttpException(401, "Not Authorized to delete details");
            else
                throw new HttpException(400, "Something wentwromg with the service");

        }
    }
}