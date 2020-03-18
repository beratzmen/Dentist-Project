using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class AboutController : ApiController
    {
        GlobalManager _aboutService = new GlobalManager(new EfGlobalRepository());

        [HttpGet]
        public Global Get(TableType tableType)
        {
            return _aboutService.Get(tableType);
        }

        [HttpGet]
        public List<Global> GetAll(TableType tableType)
        {
            return _aboutService.GetAll(tableType);
        }

        [HttpPut]
        public bool Put(Global entity)
        {
            return _aboutService.Update(entity);
        }
    }
}
