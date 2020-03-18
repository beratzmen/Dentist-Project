using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View(JsonConvert.DeserializeObject<Global>(HttpService.Get("home", "Get?TableType=" + TableType.Home).ToString()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Global entity)
        {
            HttpService.Update("home", "Put", entity);
            return RedirectToAction("Index");
        }
    }
}