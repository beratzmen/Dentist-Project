using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Dto;
using Dentist.Entities.Help;
using Dentist.Entities.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class ServiceController : ApiController
    {
        ServiceManager _serviceService = new ServiceManager(new EfServiceRepository());

        [HttpGet]
        public List<ServiceViewModel> GetAll()
        {
            return _serviceService.GetAll();
        }

        public ServiceViewModel Get(int id)
        {
            return _serviceService.Get(id);
        }

        [HttpPost]
        public ApiResponse Add(Service entity)
        {
            ApiResponse response = new ApiResponse();
            response.Status = _serviceService.Add(entity);
            response.Data = entity;
            return response;
        }

        [HttpPut]
        public bool Put(Service entity)
        {
            return _serviceService.Update(entity);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _serviceService.Delete(id);
        }
    }
}
