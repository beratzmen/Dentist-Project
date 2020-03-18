using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Areas.Admin.Controllers
{
    public class BulletinController : Controller
    {
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<Bulletin>>(HttpService.Get("bulletin", "GetAll").ToString()));
        }
        public ActionResult Delete(int id)
        {
            HttpService.Delete("bulletin", "Delete", id);
            return RedirectToAction("List");
        }
    }
}