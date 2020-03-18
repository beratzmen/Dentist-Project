using Dentist.AspMvcUI.Models.Enum;
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
    public class BlogController : Controller
    {
        public ActionResult Index(int id = 1)
        {
            ViewData["currentPage"] = id;
            return View(JsonConvert.DeserializeObject<BlogViewModel>(HttpService.Get("database", "GetBlog?id=" + ViewData["currentPage"]).ToString()));
        }

        public ActionResult Detail(int id)
        {
            return View(JsonConvert.DeserializeObject<BlogDetailViewModel>(HttpService.Get("database", "GetBlogDetail?id=" + id).ToString()));
        }

        public ActionResult Search(int pageNumber, string keyword)
        {
            ViewData["currentPage"] = pageNumber;
            ViewData["pagingType"] = ArticlePagingType.Search;
            return PartialView("~/Views/Partial/_ArticleList.cshtml", JsonConvert.DeserializeObject<ArticleBlock>(HttpService.Get("article", "Search?pageNumber=" + pageNumber + "&keyword=" + keyword).ToString()));
        }

        public ActionResult GetByCategoryId(int pageNumber, int categoryId)
        {
            ViewData["currentPage"] = pageNumber;
            ViewData["categoryId"] = categoryId;
            ViewData["pagingType"] = ArticlePagingType.Category;
            return PartialView("~/Views/Partial/_ArticleList.cshtml", JsonConvert.DeserializeObject<ArticleBlock>(HttpService.Get("article", "GetByCategoryId?pageNumber=" + pageNumber + "&categoryId=" + categoryId).ToString()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CommentAdd(Comment entity)
        {
            HttpService.Post("article", "CommentAdd", entity);
            return RedirectToAction("Detail", new { id = entity.ArticleId });
        }
    }
}