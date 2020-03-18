using Dentist.DataAccess.Abstract;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dentist.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfJobRepository : IJobDal
    {
        public bool Add(Job entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                entity.AuditStatus = (short)AuditStatus.created;
                entity.AuditDate = DateTime.Now;
                entity.CreatedDate = DateTime.Now;
                cx.Job.Add(entity);
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public bool Delete(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.Job.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
                entity.AuditStatus = (short)AuditStatus.deleted;
                entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public Job Get(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Job.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
            }
        }

        public List<Job> GetAll()
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Job.Where(p => p.AuditStatus != (short)AuditStatus.deleted).ToList();
            }
        }

        public bool Update(Job entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                var _entity = cx.Job.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == entity.Id);
                _entity.Title = entity.Title;
                _entity.AuditStatus = (short)AuditStatus.updated;
                _entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }
    }
}
