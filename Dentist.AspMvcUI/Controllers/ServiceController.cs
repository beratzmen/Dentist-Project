using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View(JsonConvert.DeserializeObject<ServiceUIViewModel>(HttpService.Get("database", "GetService").ToString()));
        }
    }
}