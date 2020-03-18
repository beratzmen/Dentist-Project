using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Help;
using Dentist.Entities.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class JobController : ApiController
    {
        JobManager _jobService = new JobManager(new EfJobRepository());

        [HttpGet]
        public List<Job> GetAll()
        {
            return _jobService.GetAll();
        }

        [HttpGet]
        public Job Get(int id)
        {
            return _jobService.Get(id);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _jobService.Delete(id);
        }
        [HttpPost]
        public ApiResponse Add(Job entity)
        {
            ApiResponse response = new ApiResponse();
            response.Status = _jobService.Add(entity);
            response.Data = entity;
            return response;
        }
        [HttpPut]
        public bool Put(Job entity)
        {
            return _jobService.Update(entity);
        }
    }
}
