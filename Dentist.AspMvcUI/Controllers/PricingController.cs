using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Dto;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Controllers
{
    public class PricingController : Controller
    {
        // GET: Pricing
        public ActionResult Index()
        {
            return View(JsonConvert.DeserializeObject<List<Service>>(HttpService.Get("database", "GetPricing").ToString()));
        }
    }
}