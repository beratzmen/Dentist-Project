using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Areas.Admin.Controllers
{
    public class WorkingHourController : Controller
    {
        // GET: Admin/WorkingHour
        public ActionResult Index()
        {
            return View(JsonConvert.DeserializeObject<List<Global>>(HttpService.Get("workinghour", "GetAll?TableType=" + TableType.WorkingHour).ToString()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Global entity)
        {
            entity.TableType = (short)TableType.WorkingHour;
            HttpService.Post("workinghour", "Add", entity);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            return View(JsonConvert.DeserializeObject<Global>(HttpService.Get("workingHour", "getbyId?id=" + id)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Global entity)
        {
            entity.TableType = (short)TableType.WorkingHour;
            HttpService.Update("workingHour", "Put", entity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            HttpService.Delete("workingHour", "Delete", id);
            return RedirectToAction("Index");
        }
    }
}