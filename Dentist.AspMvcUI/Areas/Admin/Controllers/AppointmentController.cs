using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Areas.Admin.Controllers
{
    public class AppointmentController : Controller
    {
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<Appointment>>(HttpService.Get("appointment", "GetAll").ToString()));
        }

        public ActionResult Delete(int id)
        {
            HttpService.Delete("appointment", "Delete", id);
            return RedirectToAction("List");
        }

        [HttpPost]
        public JsonResult AppointmentRead(int id, short status)
        {
            HttpService.Get("appointment", "StatusUpdate?id=" + id + "&status=" + status);
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}