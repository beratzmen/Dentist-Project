using Dentist.DataAccess.Abstract;
using Dentist.Entities.Dto;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dentist.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfArticleRepository : IArticleDal
    {
        public bool Add(Article entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                entity.AuditStatus = (short)AuditStatus.created;
                entity.AuditDate = DateTime.Now;
                entity.CreatedDate = DateTime.Now;
                cx.Article.Add(entity);
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public bool Delete(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.Article.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
                entity.AuditStatus = (short)AuditStatus.deleted;
                entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public ArticleViewModel Get(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.Article.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
                entity.Counter += 1;
                cx.SaveChanges();
                var result = (from article in cx.Article
                              where article.AuditStatus != (short)AuditStatus.deleted && article.Id == id
                              select new ArticleViewModel
                              {
                                  Id = article.Id,
                                  CategoryId = article.CategoryId,
                                  Title = article.Title,
                                  Description = article.Description,
                                  ImagePath = article.ImagePath,
                                  CreatedDate = article.CreatedDate,
                                  Counter = article.Counter
                              }).FirstOrDefault();
                return result;
                //return cx.Article.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
            }
        }

        public List<ArticleViewModel> GetAll()
        {
            using (DentistContext cx = new DentistContext())
            {
                return (from category in cx.Category
                        join article in cx.Article on category.Id equals article.CategoryId
                        where article.AuditStatus != (short)AuditStatus.deleted && category.DataType == (short)DataType.Article
                        orderby article.CreatedDate descending
                        select new ArticleViewModel
                        {
                            Id = article.Id,
                            CategoryId = category.Id,
                            CategoryName = category.Title,
                            Title = article.Title,
                            Description = article.Description,
                            ImagePath = article.ImagePath,
                            Counter = article.Counter,
                            AuditDate = article.AuditDate,
                            CreatedDate = article.CreatedDate
                        }).ToList();
            }
        }

        public bool Update(Article entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                var _entity = cx.Article.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == entity.Id);
                _entity.CategoryId = entity.CategoryId;
                _entity.Description = entity.Description;
                _entity.Title = entity.Title;
                _entity.AuditStatus = (short)AuditStatus.updated;
                _entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }


        public List<ArticleViewModel> PopulerBlogPost()
        {
            using (DentistContext cx = new DentistContext())
            {
                return (from category in cx.Category
                        join article in cx.Article on category.Id equals article.CategoryId
                        where article.AuditStatus != (short)AuditStatus.deleted && category.DataType == (short)DataType.Article
                        orderby article.Counter descending
                        select new ArticleViewModel
                        {
                            Id = article.Id,
                            CategoryId = category.Id,
                            CategoryName = category.Title,
                            Title = article.Title,
                            Description = article.Description,
                            Counter = article.Counter,
                            AuditDate = article.AuditDate,
                            CreatedDate = article.CreatedDate
                        }).Take(3).ToList();
            }
        }

        public ArticleBlock Search(int pageNumber, string keyword)
        {
            return null;
        }

        public ArticleBlock GetByCategoryId(int pageNumber, int categoryId)
        {
            return null;
        }
    }
}
