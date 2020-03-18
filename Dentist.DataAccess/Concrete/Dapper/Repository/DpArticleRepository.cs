using Dentist.DataAccess.Abstract;
using Dentist.DataAccess.Concrete.Dapper.Context;
using Dentist.Entities.Dto;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.DataAccess.Concrete.Dapper.Repository
{
    public class DpArticleRepository : IArticleDal
    {
        DapperContext dc = new DapperContext();

        public ArticleBlock Search(int pageNumber, string keyword)
        {
            ArticleBlock ab = new ArticleBlock();
            ab.PageCount = Math.Ceiling((dc.QuerySingle<double>("select count(Id) as TotalArticleCount from Article where AuditStatus != " + (short)AuditStatus.deleted + " AND (Title LIKE '%" + keyword + "%' OR Description LIKE '%" + keyword + "%')") / 5));
            if (pageNumber <= 0)
                pageNumber = 1;
            string articleQuery = "declare @pageNumber INT = " + (pageNumber - 1) + ", @pageSize INT = 5 ";
            articleQuery += "SELECT art.Id,art.Title,art.Description,art.ImagePath,art.CreatedDate, (SELECT Count(Id) from Comment where Comment.ArticleId = art.Id) AS CommentCount ";
            articleQuery += "FROM Article art ";
            articleQuery += "where art.AuditStatus != " + (short)AuditStatus.deleted + " AND (art.Title LIKE '%" + keyword + "%' OR art.Description LIKE '%" + keyword + "%') ";
            articleQuery += "order by art.Id offset @pageNumber * @pageSize rows fetch next @pageSize rows only ";
            ab.ArticleList = dc.Query<ArticleUIViewModel>(articleQuery).ToList();
            return ab;
        }

        public ArticleBlock GetByCategoryId(int pageNumber, int categoryId)
        {
            ArticleBlock ab = new ArticleBlock();
            ab.PageCount = Math.Ceiling((dc.QuerySingle<double>("select count(Id) as TotalArticleCount from Article where AuditStatus != " + (short)AuditStatus.deleted + " AND categoryId = " + categoryId + " ") / 5));
            if (pageNumber <= 0)
                pageNumber = 1;
            string articleQuery = "declare @pageNumber INT = " + (pageNumber - 1) + ", @pageSize INT = 5 ";
            articleQuery += "SELECT art.Id,art.Title,art.Description,art.ImagePath,art.CreatedDate, (SELECT Count(Id) from Comment where Comment.ArticleId = art.Id) AS CommentCount ";
            articleQuery += "FROM Article art ";
            articleQuery += "where art.AuditStatus != " + (short)AuditStatus.deleted + " AND art.CategoryId = " + categoryId + " ";
            articleQuery += "order by art.Id offset @pageNumber * @pageSize rows fetch next @pageSize rows only ";
            ab.ArticleList = dc.Query<ArticleUIViewModel>(articleQuery).ToList();
            return ab;
        }

        public bool Add(Article entity)
        {
            return false;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public ArticleViewModel Get(int id)
        {
            return null;
        }

        public List<ArticleViewModel> GetAll()
        {
            return null;
        }

        public List<ArticleViewModel> PopulerBlogPost()
        {
            return null;
        }

        public bool Update(Article entity)
        {
            return false;
        }
    }
}
