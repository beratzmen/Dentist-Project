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
    public class JobController : Controller
    {
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<Job>>(HttpService.Get("job", "GetAll").ToString()));
        }

        public ActionResult Update(int id)
        {
            return View(JsonConvert.DeserializeObject<Job>(HttpService.Get("job", "get", id)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Job entity)
        {
            HttpService.Update("job", "Put", entity);
            return RedirectToAction("List");
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Job entity)
        {
            HttpService.Post("job", "Add", entity);
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            HttpService.Delete("job", "Delete", id);
            return RedirectToAction("List");
        }
    }
}