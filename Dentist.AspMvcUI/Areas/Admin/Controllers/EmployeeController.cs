using Dentist.AspMvcUI.Utility.API;
using Dentist.Entities.Dto;
using Dentist.Entities.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Dentist.AspMvcUI.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<EmployeeViewModel>>(HttpService.Get("employee", "GetAll").ToString()));
        }

        public ActionResult Add()
        {
            return View(JsonConvert.DeserializeObject<List<Job>>(HttpService.Get("job", "GetAll").ToString()));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Employee entity, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                WebImage img = new WebImage(uploadImage.InputStream);
                FileInfo fotoInfo = new FileInfo(uploadImage.FileName);
                string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                img.Resize(720, 720);
                img.Save("~/Uploads/EmployeeImage/" + newFoto);
                entity.ImagePath = "/Uploads/EmployeeImage/" + newFoto;
            }
            HttpService.Post("employee", "Add", entity);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            HttpService.Delete("employee", "Delete", id);
            return RedirectToAction("List");
        }

        public ActionResult Update(int id)
        {
            var entity = JsonConvert.DeserializeObject<EmployeeViewModel>(HttpService.Get("employee", "get", id));
            EmployeeViewModel model = new EmployeeViewModel();
            model.Id = entity.Id;
            model.JobId = entity.JobId;
            model.FullName = entity.FullName;
            model.ImagePath = entity.ImagePath;
            model.Phone = entity.Phone;
            model.Email = entity.Email;
            model.JobList = JsonConvert.DeserializeObject<List<Job>>(HttpService.Get("job", "GetAll").ToString());
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employee entity, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                string filepath = Path.GetFileName(entity.ImagePath);
                var location = Path.Combine("/Uploads/EmployeeImage/" + filepath);
                uploadImage.SaveAs(Server.MapPath("~" + location));
                entity.ImagePath = location;
            }
            HttpService.Update("employee", "Put", entity);
            return RedirectToAction("List");
        }
    }
}