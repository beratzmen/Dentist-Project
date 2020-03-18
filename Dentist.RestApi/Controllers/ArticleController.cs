using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.Dapper.Repository;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Dto;
using Dentist.Entities.Help;
using Dentist.Entities.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class ArticleController : ApiController
    {
        ArticleManager _articleDpService = new ArticleManager(new DpArticleRepository());
        ArticleManager _articleService = new ArticleManager(new EfArticleRepository());
        CommentManager _commentService = new CommentManager(new EfCommentRepository());

        [HttpGet]
        public List<ArticleViewModel> GetAll()
        {
            return _articleService.GetAll();
        }
        public ArticleViewModel Get(int id)
        {
            return _articleService.Get(id);
        }

        [HttpPost]
        public ApiResponse Add(Article entity)
        {
            ApiResponse response = new ApiResponse();
            response.Status = _articleService.Add(entity);
            response.Data = entity;
            return response;
        }

        [HttpPut]
        public bool Put(Article entity)
        {
            return _articleService.Update(entity);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _articleService.Delete(id);
        }
        [HttpGet]
        public List<ArticleViewModel> PopulerBlogPost()
        {
            return _articleService.PopulerBlogPost();
        }

        [HttpPost]
        public bool CommentAdd(Comment entity)
        {
            return _commentService.Add(entity);
        }

        [HttpGet]
        public ArticleBlock Search(int pageNumber, string keyword)
        {
            return _articleDpService.Search(pageNumber, keyword);
        }

        [HttpGet]
        public ArticleBlock GetByCategoryId(int pageNumber, int categoryId)
        {
            return _articleDpService.GetByCategoryId(pageNumber, categoryId);
        }
    }
}
