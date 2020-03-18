using Dentist.DataAccess.Abstract;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dentist.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCategoryRepository : ICategoryDal
    {
        public bool Add(Category entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                entity.AuditStatus = (short)AuditStatus.created;
                entity.AuditDate = DateTime.Now;
                entity.CreatedDate = DateTime.Now;
                cx.Category.Add(entity);
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public bool Delete(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.Category.Where(x => x.Id == id).FirstOrDefault();
                entity.AuditStatus = (short)AuditStatus.deleted;
                entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public Category Get(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Category.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
            }
        }

        public List<Category> GetAll(DataType dataType)
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Category.Where(p => p.AuditStatus != (short)AuditStatus.deleted && p.DataType == (short)dataType).ToList();
            }
        }

        public bool Update(Category entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                var model = cx.Category.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == entity.Id);
                model.Description = entity.Description;
                model.Title = entity.Title;
                model.ImagePath = entity.ImagePath;
                model.AuditStatus = (short)AuditStatus.updated;
                model.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public List<Category> Search(DataType dataType, string keyword)
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Category.Where(p => p.AuditStatus != (short)AuditStatus.deleted && p.DataType == (short)dataType && (p.Title.ToLower().Contains(keyword.ToLower()) || p.Description.ToLower().Contains(keyword.ToLower()))).ToList();
            }
        }
    }
}
