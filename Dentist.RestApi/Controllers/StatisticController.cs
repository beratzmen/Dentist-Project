using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class StatisticController : ApiController
    {
        GlobalManager _statisticService = new GlobalManager(new EfGlobalRepository());

        public Global Get(TableType tableType)
        {
            return _statisticService.Get(tableType);
        }

        [HttpGet]
        public List<Global> GetAll(TableType tableType)
        {
            return _statisticService.GetAll(tableType);
        }

        [HttpPut]
        public bool Put(Global entity)
        {
            return _statisticService.Update(entity);
        }
    }
}
