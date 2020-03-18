using Dentist.DataAccess.Abstract;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dentist.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfBulletinRepository : IBulletinDal
    {
        public bool Add(Bulletin entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                entity.AuditStatus = (short)AuditStatus.created;
                entity.AuditDate = DateTime.Now;
                entity.CreatedDate = DateTime.Now;
                cx.Bulletin.Add(entity);
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public bool Delete(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.Bulletin.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
                entity.AuditStatus = (short)AuditStatus.deleted;
                entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public Bulletin Get(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Bulletin.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
            }
        }

        public List<Bulletin> GetAll()
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Bulletin.Where(p => p.AuditStatus != (short)AuditStatus.deleted).ToList();
            }
        }

        public bool Update(Bulletin entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                var _entity = cx.Bulletin.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == entity.Id);
                _entity.Email = entity.Email;
                _entity.AuditStatus = (short)AuditStatus.updated;
                _entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }
    }
}
