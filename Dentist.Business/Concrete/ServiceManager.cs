using Dentist.DataAccess.Abstract;
using Dentist.Entities.Dto;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.Business.Concrete
{
    public class ServiceManager : IServiceDal
    {
        IServiceDal _serviceDal;
        public ServiceManager(IServiceDal serviceDal)
        {
            this._serviceDal = serviceDal;
        }
        public bool Add(Service entity)
        {
            return _serviceDal.Add(entity);
        }

        public bool Delete(int id)
        {
            return _serviceDal.Delete(id);
        }

        public ServiceViewModel Get(int id)
        {
            return _serviceDal.Get(id);
        }

        public List<ServiceViewModel> GetAll()
        {
            return _serviceDal.GetAll();
        }

        public bool Update(Service entity)
        {
            return _serviceDal.Update(entity);
        }
    }
}
