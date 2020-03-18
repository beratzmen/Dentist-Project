using Dentist.DataAccess.Abstract;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dentist.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfContactMailRepository : IContactMailDal
    {
        public bool Add(ContactMail entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                entity.AuditStatus = (short)AuditStatus.created;
                entity.AuditDate = DateTime.Now;
                entity.CreatedDate = DateTime.Now;
                entity.Status = (short)ProcessStatus.unread;
                cx.ContactMail.Add(entity);
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public bool Delete(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.ContactMail.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
                entity.AuditStatus = (short)AuditStatus.deleted;
                entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public ContactMail Get(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.ContactMail.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
            }
        }

        public List<ContactMail> GetAll()
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.ContactMail.Where(p => p.AuditStatus != (short)AuditStatus.deleted).OrderBy(p => p.Status).ToList();
            }
        }

        public bool Update(ContactMail entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                var _entity = cx.ContactMail.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == entity.Id);
                _entity.Status = entity.Status;
                _entity.AuditStatus = (short)AuditStatus.updated;
                _entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public bool StatusUpdate(int id, short status)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.ContactMail.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
                entity.Status = status;
                return (cx.SaveChanges() > 0) ? true : false;
            }

        }
    }
}
