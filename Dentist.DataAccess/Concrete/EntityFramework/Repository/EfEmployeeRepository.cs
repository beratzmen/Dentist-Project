using Dentist.DataAccess.Abstract;
using Dentist.Entities.Dto;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfEmployeeRepository : IEmployeeDal
    {
        public bool Add(Employee entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                entity.AuditStatus = (short)AuditStatus.created;
                entity.AuditDate = DateTime.Now;
                entity.CreatedDate = DateTime.Now;
                cx.Employee.Add(entity);
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public bool Delete(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.Employee.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
                entity.AuditStatus = (short)AuditStatus.deleted;
                entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public Employee Get(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                //return from employee in cx.Employee
                //       join job in cx.Job on employee.JobId equals job.Id
                //       where p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id
                return cx.Employee.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
            }
        }

        public List<EmployeeViewModel> GetAll()
        {
            using (DentistContext cx = new DentistContext())
            {
                return (from employee in cx.Employee
                        join job in cx.Job on employee.JobId equals job.Id
                        where employee.AuditStatus != (short)AuditStatus.deleted
                        select new EmployeeViewModel
                        {
                            Id = employee.Id,
                            JobId = job.Id,
                            JobName = job.Title,
                            FullName = employee.FullName,
                            Phone = employee.Phone,
                            Email = employee.Email,
                            ImagePath = employee.ImagePath,
                            AuditDate = employee.AuditDate,
                            AuditStatus = employee.AuditStatus
                        }).ToList();
                //return cx.Employee.Where(p => p.AuditStatus != (short)AuditStatus.deleted).ToList();
            }
        }

        public bool Update(Employee entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                var _entity = cx.Employee.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == entity.Id);
                _entity.JobId = entity.JobId;
                _entity.Email = entity.Email;
                _entity.FullName = entity.FullName;
                _entity.ImagePath = entity.ImagePath;
                _entity.Phone = entity.Phone;
                _entity.AuditStatus = (short)AuditStatus.updated;
                _entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }
    }
}
