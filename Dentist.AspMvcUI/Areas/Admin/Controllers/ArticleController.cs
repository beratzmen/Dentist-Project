using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Dto;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<ArticleViewModel>>(HttpService.Get("article", "GetAll").ToString()));
        }

        public ActionResult Add()
        {
            return View(JsonConvert.DeserializeObject<List<Category>>(HttpService.Get("category", "GetAll?DataType=" + (short)DataType.Article).ToString()));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(Article entity, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                WebImage img = new WebImage(uploadImage.InputStream);
                FileInfo fotoInfo = new FileInfo(uploadImage.FileName);
                string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                img.Resize(720, 720);
                img.Save("~/Uploads/ArticleImage/" + newFoto);
                entity.ImagePath = "/Uploads/ArticleImage/" + newFoto;
            }
            HttpService.Post("article", "Add", entity);
            return RedirectToAction("List");
        }


        public ActionResult Update(int id)
        {
            var entity = JsonConvert.DeserializeObject<ArticleViewModel>(HttpService.Get("article", "Get", id).ToString());
            ArticleViewModel model = new ArticleViewModel();
            model.Title = entity.Title;
            //model.Description = entity.Description;
            model.Description = entity.Description.Replace("<img src=\"../../", "<img src=\"../../../");
            model.CategoryId = entity.CategoryId;
            model.Id = entity.Id;
            model.ImagePath = entity.ImagePath;
            model.CategoryList = JsonConvert.DeserializeObject<List<Category>>(HttpService.Get("category", "GetAll?DataType=" + (short)DataType.Article).ToString());
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Update(Article entity, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                string filepath = Path.GetFileName(entity.ImagePath);
                var location = Path.Combine("/Uploads/ArticleImage/" + filepath);
                uploadImage.SaveAs(Server.MapPath("~" + location));
                entity.ImagePath = location;
            }
            HttpService.Update("article", "Put", entity);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            HttpService.Delete("article", "Delete", id);
            return RedirectToAction("List");
        }
    }
}