using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Areas.Admin.Controllers
{
    public class StatisticController : Controller
    {

        public ActionResult Index()
        {
            return View(JsonConvert.DeserializeObject<Global>(HttpService.Get("statistic", "Get?TableType=" + TableType.Statistic).ToString()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Global entity)
        {
            entity.TableType = (short)TableType.Statistic;
            HttpService.Update("statistic", "Put", entity);
            return RedirectToAction("Index");
        }
    }
}