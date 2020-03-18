using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Dto;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<ServiceViewModel>>(HttpService.Get("service", "GetAll").ToString()));
        }

        public ActionResult Add()
        {
            return View(JsonConvert.DeserializeObject<List<Category>>(HttpService.Get("category", "GetAll?DataType=" + (short)DataType.Service).ToString()));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(Service entity)
        {
            HttpService.Post("service", "Add", entity);
            return RedirectToAction("List");
        }

        public ActionResult Update(int id)
        {
            var entity = JsonConvert.DeserializeObject<ServiceViewModel>(HttpService.Get("service", "Get", id).ToString());
            ServiceViewModel model = new ServiceViewModel();
            model.Title = entity.Title;
            model.Description = entity.Description.Replace("<img src=\"../../", "<img src=\"../../../");
            model.CategoryId = entity.CategoryId;
            model.Id = entity.Id;
            model.Period = entity.Period;
            model.Price = entity.Price;
            model.CategoryList = JsonConvert.DeserializeObject<List<Category>>(HttpService.Get("category", "GetAll?DataType=" + (short)DataType.Service).ToString());
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Update(Service entity)
        {
            HttpService.Update("service", "Put", entity);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            HttpService.Delete("service", "Delete", id);
            return RedirectToAction("List");
        }

    }
}