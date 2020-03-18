using Dentist.Entities.Dto;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.DataAccess.Abstract
{
    public interface IArticleDal
    {
        ArticleViewModel Get(int id);
        List<ArticleViewModel> GetAll();
        bool Add(Article entity);
        bool Delete(int id);
        bool Update(Article entity);
        List<ArticleViewModel> PopulerBlogPost();
        ArticleBlock Search(int pageNumber, string keyword);
        ArticleBlock GetByCategoryId(int pageNumber, int categoryId);
    }
}
