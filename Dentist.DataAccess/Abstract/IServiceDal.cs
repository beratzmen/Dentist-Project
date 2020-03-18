using Dentist.Entities.Dto;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.DataAccess.Abstract
{
    public interface IServiceDal
    {
        ServiceViewModel Get(int id);
        List<ServiceViewModel> GetAll();
        bool Add(Service entity);
        bool Delete(int id);
        bool Update(Service entity);
    }
}
