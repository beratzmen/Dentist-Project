using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class HomeController : ApiController
    {
        GlobalManager _globalService = new GlobalManager(new EfGlobalRepository());
        public Global Get(TableType tableType)
        {
            return _globalService.Get(tableType);
        }

        [HttpPut]
        public bool Put(Global entity)
        {
            return _globalService.Update(entity);
        }
    }
}