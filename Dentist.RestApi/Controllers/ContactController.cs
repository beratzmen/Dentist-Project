using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class ContactController : ApiController
    {
        GlobalManager _contactService = new GlobalManager(new EfGlobalRepository());

        [HttpGet]
        public Global Get(TableType tableType)
        {
            return _contactService.Get(tableType);
        }

        [HttpGet]
        public List<Global> GetAll(TableType tableType)
        {
            return _contactService.GetAll(tableType);
        }

        [HttpPut]
        public bool Put(Global entity)
        {
            return _contactService.Update(entity);
        }


    }
}
