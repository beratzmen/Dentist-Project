using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Dto;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Controllers
{
    public class PartialController : Controller
    {
        public PartialViewResult _Footer()
        {
            FooterViewModel model = new FooterViewModel();
            model.contactModel = JsonConvert.DeserializeObject<List<Global>>(HttpService.Get("contact", "GetAll?TableType=" + TableType.Contact).ToString());
            model.workingHourModel = JsonConvert.DeserializeObject<List<Global>>(HttpService.Get("workinghour", "GetAll?TableType=" + TableType.WorkingHour).ToString());
            return PartialView(model);
        }

        public PartialViewResult _TopHeader()
        {
            FooterViewModel model = new FooterViewModel();
            var entity = JsonConvert.DeserializeObject<List<Global>>(HttpService.Get("contact", "GetAll?TableType=" + TableType.Contact).ToString());
            model.Address = entity[0].Address;
            model.Phone = entity[0].Phone;
            model.FaceIconAddress = entity[0].FaceAddress;
            model.GoogleIconAddress = entity[0].GoogleAddress;
            model.LinkedinIconAddress = entity[0].LinkedinAddress;
            model.TwitterIconAddress = entity[0].TwitterAddress;
            //model.contactModel = JsonConvert.DeserializeObject<List<Global>>(HttpService.Get("contact", "GetAll?TableType=" + TableType.Contact).ToString());
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Bulletin entity)
        {
            HttpService.Post("bulletin", "Add", entity);
            return Redirect("/Home/Index");
        }
    }
}