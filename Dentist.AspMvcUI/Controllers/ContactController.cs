using Dentist.AspMvcUI.Utility.API;
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
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {

            return View(JsonConvert.DeserializeObject<Global>(HttpService.Get("contact", "Get?TableType=" + TableType.Contact).ToString()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ContactMail entity)
        {
            HttpService.Post("contactMail", "Add", entity);
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