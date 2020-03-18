using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dentist.AspMvcUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult List()
        {
            return View(GetCategoryList(DataType.Service));
        }
        [HttpPost]
        public JsonResult List(int id)
        {
            return Json(GetCategoryList((DataType)id), JsonRequestBehavior.AllowGet);
        }

        public List<Category> GetCategoryList(DataType dataType)
        {
            return JsonConvert.DeserializeObject<List<Category>>(HttpService.Get("category", "GetAll?DataType=" + dataType).ToString());
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category category)
        {
            HttpService.Post("category", "Add", category);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            HttpService.Delete("category", "Delete", id);
            return RedirectToAction("List");
        }

        public ActionResult Update(int id)
        {
            return View(JsonConvert.DeserializeObject<Category>(HttpService.Get("category", "get", id)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Category category)
        {
            HttpService.Update("category", "Put", category);
            return RedirectToAction("List");
        }

        [HttpGet]
        public JsonResult Search(DataType dataType, string keyword)
        {
            return Json(JsonConvert.DeserializeObject<List<Category>>(HttpService.Get("category", "Search?dataType=" + dataType.ToString() + "&keyword=" + keyword).ToString()), JsonRequestBehavior.AllowGet);
        }
    }
}