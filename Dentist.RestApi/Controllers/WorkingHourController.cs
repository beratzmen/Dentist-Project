using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Help;
using Dentist.Entities.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class WorkingHourController : ApiController
    {
        GlobalManager _workingHourService = new GlobalManager(new EfGlobalRepository());

        public Global Get(TableType tableType)
        {
            return _workingHourService.Get(tableType);
        }

        public Global GetById(int id)
        {
            return _workingHourService.GetById(id);
        }

        [HttpGet]
        public List<Global> GetAll(TableType tableType)
        {
            return _workingHourService.GetAll(tableType);
        }

        [HttpPost]
        public ApiResponse Add(Global entity)
        {
            ApiResponse response = new ApiResponse();
            response.Status = _workingHourService.Add(entity);
            response.Data = entity;
            return response;
        }

        [HttpPut]
        public bool Put(Global entity)
        {
            return _workingHourService.Update(entity);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _workingHourService.Delete(id);
        }
    }
}
