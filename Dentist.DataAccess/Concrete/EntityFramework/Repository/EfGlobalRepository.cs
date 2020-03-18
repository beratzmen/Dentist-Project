using Dentist.DataAccess.Abstract;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dentist.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfGlobalRepository : IGlobalDal
    {
        public bool Add(Global entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                entity.AuditStatus = (short)AuditStatus.created;
                entity.AuditDate = DateTime.Now;
                entity.CreatedDate = DateTime.Now;
                cx.Global.Add(entity);
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public bool Delete(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                var entity = cx.Global.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
                entity.AuditStatus = (short)AuditStatus.deleted;
                entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }

        public Global Get(TableType tableType)
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Global.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.TableType == (short)tableType);
            }
        }

        public List<Global> GetAll(TableType tableType)
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Global.Where(p => p.AuditStatus != (short)AuditStatus.deleted && p.TableType == (short)tableType).ToList();
            }
        }

        public Global GetById(int id)
        {
            using (DentistContext cx = new DentistContext())
            {
                return cx.Global.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == id);
            }
        }

        public bool Update(Global entity)
        {
            using (DentistContext cx = new DentistContext())
            {
                var _entity = cx.Global.FirstOrDefault(p => p.AuditStatus != (short)AuditStatus.deleted && p.Id == entity.Id);
                if (_entity == null)
                    return false;
                if (entity.TableType == (short)TableType.Home || entity.TableType == (short)TableType.About)
                {
                    _entity.Title = entity.Title;
                    _entity.Description = entity.Description;
                    _entity.ImagePath = entity.ImagePath;
                    _entity.AreaType = entity.AreaType;
                }
                else if (entity.TableType == (short)TableType.Contact)
                {
                    _entity.Address = entity.Address;
                    _entity.Phone = entity.Phone;
                    _entity.Fax = entity.Fax;
                    _entity.Email = entity.Email;
                    _entity.FaceAddress = entity.FaceAddress;
                    _entity.TwitterAddress = entity.TwitterAddress;
                    _entity.GoogleAddress = entity.GoogleAddress;
                    _entity.LinkedinAddress = entity.LinkedinAddress;
                }
                else if (entity.TableType == (short)TableType.Statistic)
                {
                    if (entity.Experience > 100)
                    {
                        entity.Experience = 100;
                    }
                    if (entity.Sincerity > 100)
                    {
                        entity.Sincerity = 100;
                    }
                    if (entity.ModernEquipment > 100)
                    {
                        entity.ModernEquipment = 100;
                    }
                    _entity.Since = entity.Since;
                    _entity.Patient = entity.Patient;
                    _entity.Certificate = entity.Certificate;
                    _entity.Doctor = entity.Doctor;
                    _entity.Experience = entity.Experience;
                    _entity.ModernEquipment = entity.ModernEquipment;
                    _entity.Sincerity = entity.Sincerity;
                }
                else if (entity.TableType == (short)TableType.WorkingHour)
                {
                    _entity.Day = entity.Day;
                    _entity.StartTime = entity.StartTime;
                    _entity.EndTime = entity.EndTime;
                }
                else if (entity.TableType == (short)TableType.Global)
                    _entity.AreaType = entity.AreaType;
                _entity.AuditStatus = (short)AuditStatus.updated;
                _entity.AuditDate = DateTime.Now;
                return (cx.SaveChanges() > 0) ? true : false;
            }
        }
    }
}
