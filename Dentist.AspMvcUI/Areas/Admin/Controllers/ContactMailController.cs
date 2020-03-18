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
    public class ContactMailController : Controller
    {
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<ContactMail>>(HttpService.Get("contactMail", "GetAll").ToString()));
        }

        public ActionResult Delete(int id)
        {
            HttpService.Delete("contactMail", "Delete", id);
            return RedirectToAction("List");
        }

        [HttpPost]
        public JsonResult ContactMailRead(int id, short status)
        {
            HttpService.Get("contactMail", "StatusUpdate?id=" + id + "&status=" + status);
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}