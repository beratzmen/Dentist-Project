using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        // GET: Admin/About
        public ActionResult Index()
        {
            return View(JsonConvert.DeserializeObject<Global>(HttpService.Get("about", "Get?TableType=" + TableType.About).ToString()));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Index(Global entity)
        {
            entity.TableType = (short)TableType.About;
            HttpService.Update("about", "Put", entity);
            return RedirectToAction("Index");
        }
    }
}