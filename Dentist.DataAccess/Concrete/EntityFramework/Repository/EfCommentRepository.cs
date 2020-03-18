using Dentist.DataAccess.Abstract;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dentist.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCommentRepository : ICommentDal
    {
        public bool Add(Comment entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                entity.AuditStatus = (short)AuditStatus.created;
                entity.AuditDate = DateTime.Now;
                entity.CreatedDate = DateTime.Now;
                cx.Comment.Add(entity);
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public void Delete(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.Comment.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
                entity.AuditStatus = (short)AuditStatus.deleted;
                entity.AuditDate = DateTime.Now;
                cx.SaveChanges();
            }
        }

        public Comment Get(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Comment.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
            }
        }

        public List<Comment> GetAll()
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Comment.Where(p => p.AuditStatus != (short)AuditStatus.deleted).ToList();
            }
        }

        public void Update(Comment entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                var _entity = cx.Comment.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == entity.Id);
                _entity.Description = entity.Description;
                _entity.FullName = entity.FullName;
                _entity.AuditStatus = (short)AuditStatus.updated;
                _entity.AuditDate = DateTime.Now;
                cx.SaveChanges();
            }
        }
    }
}
