using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Help;
using Dentist.Entities.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class BulletinController : ApiController
    {
        BulletinManager _bulletinService = new BulletinManager(new EfBulletinRepository());
        [HttpGet]
        public List<Bulletin> GetAll()
        {
            return _bulletinService.GetAll();
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _bulletinService.Delete(id);
        }

        [HttpPost]
        public ApiResponse Add(Bulletin entity)
        {
            ApiResponse response = new ApiResponse();
            response.Status = _bulletinService.Add(entity);
            response.Data = entity;
            return response;
        }
    }
}
