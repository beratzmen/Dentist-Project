using Dentist.DataAccess.Abstract;
using Dentist.Entities.Dto;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.Business.Concrete
{
    public class ArticleManager : IArticleDal
    {
        IArticleDal _articleDal;
        public ArticleManager(IArticleDal articleDal)
        {
            this._articleDal = articleDal;
        }
        public bool Add(Article entity)
        {
            return _articleDal.Add(entity);
        }

        public bool Delete(int id)
        {
            return _articleDal.Delete(id);
        }

        public ArticleViewModel Get(int id)
        {
            return _articleDal.Get(id);
        }

        public List<ArticleViewModel> GetAll()
        {
            return _articleDal.GetAll();
        }

        public bool Update(Article entity)
        {
            return _articleDal.Update(entity);
        }

        public List<ArticleViewModel> PopulerBlogPost()
        {
            return _articleDal.PopulerBlogPost();
        }

        public ArticleBlock Search(int pageNumber, string keyword)
        {
            return _articleDal.Search(pageNumber, keyword);
        }
        public ArticleBlock GetByCategoryId(int pageNumber, int categoryId)
        {
            return _articleDal.GetByCategoryId(pageNumber, categoryId);
        }
    }
}
