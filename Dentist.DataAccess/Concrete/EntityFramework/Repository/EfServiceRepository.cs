using Dentist.DataAccess.Abstract;
using Dentist.Entities.Dto;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dentist.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfServiceRepository : IServiceDal
    {
        public bool Add(Service entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                entity.AuditStatus = (short)AuditStatus.created;
                entity.AuditDate = DateTime.Now;
                entity.CreatedDate = DateTime.Now;
                cx.Service.Add(entity);
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public bool Delete(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.Service.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
                entity.AuditStatus = (short)AuditStatus.deleted;
                entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public ServiceViewModel Get(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                var result = (from service in cx.Service
                              where service.AuditStatus != (short)AuditStatus.deleted && service.Id == id
                              select new ServiceViewModel
                              {
                                  Id = service.Id,
                                  CategoryId = service.CategoryId,
                                  Title = service.Title,
                                  Description = service.Description,
                                  Period = service.Period,
                                  Price = service.Price,
                                  AuditDate = service.AuditDate
                              }).FirstOrDefault();
                return result;
                //return cx.Service.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
            }
        }

        public List<ServiceViewModel> GetAll()
        {
            using (DentistContext cx = new DentistContext())
            {
                return (from service in cx.Service
                        join category in cx.Category on service.CategoryId equals category.Id 
                        where service.AuditStatus != (short)AuditStatus.deleted && category.AuditStatus != (short)AuditStatus.deleted
                        select new ServiceViewModel
                        {
                            Id = service.Id,
                            CategoryId = category.Id,
                            CategoryName = category.Title,
                            Title = service.Title,
                            Period = service.Period,
                            Price = service.Price,
                            AuditDate = service.AuditDate,
                            Description = service.Description
                        }).ToList();
                //cx.Service.Where(p => p.AuditStatus != (short)AuditStatus.deleted).ToList();
            }
        }

        public bool Update(Service entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                var _entity = cx.Service.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == entity.Id);
                _entity.Period = entity.Period;
                _entity.Price = entity.Price;
                _entity.CategoryId = entity.CategoryId;
                _entity.Description = entity.Description;
                _entity.Title = entity.Title;
                _entity.AuditStatus = (short)AuditStatus.updated;
                _entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }
    }
}
