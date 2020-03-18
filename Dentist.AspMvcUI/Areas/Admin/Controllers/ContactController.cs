using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        // GET: Admin/Contact
        public ActionResult Index()
        {
            return View(JsonConvert.DeserializeObject<Global>(HttpService.Get("contact", "Get?TableType=" + TableType.Contact).ToString()));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Global entity)
        {
            entity.TableType = (short)TableType.Contact;
            HttpService.Update("contact", "Put", entity);
            return RedirectToAction("Index");
        }
    }
}