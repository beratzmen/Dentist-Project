using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.Dapper.Repository;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Dto;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class DatabaseController : ApiController
    {
        DatabaseManager _databaseService = new DatabaseManager(new DpDatabaseRepository());

        [HttpGet]
        public HomeViewModel GetMainPageItems()
        {
            return _databaseService.GetMainPageItems();
        }

        [HttpGet]
        public AboutViewModel GetAbout()
        {
            return _databaseService.GetAbout();
        }

        [HttpGet]
        public ServiceUIViewModel GetService()
        {
            return _databaseService.GetService();
        }

        [HttpGet]
        public List<Service> GetPricing()
        {
            return _databaseService.GetPricing();
        }

        [HttpGet]
        public BlogViewModel GetBlog(int id)
        {
            return _databaseService.GetBlog(id);
        }

        [HttpGet]
        public BlogDetailViewModel GetBlogDetail(int id)
        {
            return _databaseService.GetBlogDetail(id);
        }
    }
}
