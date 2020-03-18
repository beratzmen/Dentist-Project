using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Dto;
using Dentist.Entities.Help;
using Dentist.Entities.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeManager _employeeService = new EmployeeManager(new EfEmployeeRepository());

        [HttpGet]
        public List<EmployeeViewModel> GetAll()
        {
            return _employeeService.GetAll();
        }

        [HttpGet]
        public Employee Get(int id)
        {
            return _employeeService.Get(id);
        }

        [HttpPost]
        public ApiResponse Add(Employee entity)
        {
            ApiResponse response = new ApiResponse();
            response.Status = _employeeService.Add(entity);
            response.Data = entity;
            return response;
        }

        [HttpPut]
        public bool Put(Employee entity)
        {
            return _employeeService.Update(entity);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _employeeService.Delete(id);
        }
    }
}
