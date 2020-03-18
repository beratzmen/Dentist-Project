using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Dto;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(JsonConvert.DeserializeObject<HomeViewModel>(HttpService.Get("database", "GetMainPageItems").ToString()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Appointment entity)
        {
            HttpService.Post("Appointment", "Add", entity);
            if (Response.StatusCode == 200)
            {
                Session["alertSession"] = 1;
            }
            else
            {
                Session["alertSession"] = 2;
            }
            return RedirectToAction("Index");
        }
    }
}