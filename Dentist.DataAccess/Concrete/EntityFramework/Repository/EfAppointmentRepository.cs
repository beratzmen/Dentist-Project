using Dentist.DataAccess.Abstract;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dentist.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfAppointmentRepository : IAppointmentDal
    {
        public bool Add(Appointment entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                entity.AuditStatus = (short)AuditStatus.created;
                entity.AuditDate = DateTime.Now;
                entity.CreatedDate = DateTime.Now;
                cx.Appointment.Add(entity);
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public bool Delete(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.Appointment.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
                entity.AuditStatus = (short)AuditStatus.deleted;
                entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public Appointment Get(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Appointment.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
            }
        }

        public List<Appointment> GetAll()
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Appointment.Where(p => p.AuditStatus != (short)AuditStatus.deleted).OrderBy(p => p.CreatedDate).ToList();
            }
        }

        public bool Update(Appointment entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                var _entity = cx.Appointment.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == entity.Id);
                //_entity.Date = entity.Date;
                _entity.Email = entity.Email;
                _entity.FullName = entity.FullName;
                _entity.Message = entity.Message;
                _entity.Phone = entity.Phone;
                _entity.AuditStatus = (short)AuditStatus.updated;
                _entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }
        public bool StatusUpdate(int id, short status)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.Appointment.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
                entity.Status = status;
                return (cx.SaveChanges() > 0) ? true : false;
            }

        }
    }
}
