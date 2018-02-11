using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APEXUI.Models;
using APEXUI.ServiceCall;
using Newtonsoft.Json;

namespace APEXUI.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillConsumer consumer = new SkillConsumer();
        public ActionResult Youhave()
        {
            if (Session["EmpId"] == null || Session["EmpId"].Equals(0))
                return RedirectToAction("Details", "Employee", new { E = 1 });
            int EmpId = Convert.ToInt32(Session["EmpId"]);
            var response = consumer.GetSkills(EmpId);
            if ((int)response.StatusCode == 200)
            {
                var skillSets = JsonConvert.DeserializeObject<List<SkillsBO>>(response.Content);
                return View(skillSets);
            }
            return View();
        }

        [HttpPost]
        public ActionResult InsertSkills(SkillsBO skills)
        {
            skills.EmpId = (int)Session["EmpId"];
            var response = consumer.AddnewSkill(skills);

            var skillset = JsonConvert.DeserializeObject<WorkHistoryBO>(response.Content);
            if ((int)response.StatusCode == 201)
            {
                return Json(skillset);
            }
            else if ((int)response.StatusCode == 401)
            {
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                    ModelState.AddModelError(string.Empty, "Something wrong, please raise the issue with support");
                return View();
            }
        }
    }
}