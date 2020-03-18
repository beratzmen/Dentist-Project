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
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View(JsonConvert.DeserializeObject<AboutViewModel>(HttpService.Get("database", "GetAbout").ToString()));
        }
    }
}