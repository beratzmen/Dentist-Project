using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Help;
using Dentist.Entities.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class CategoryController : ApiController
    {
        CategoryManager _categoryService = new CategoryManager(new EfCategoryRepository());

        [HttpGet]
        public List<Category> GetAll(DataType dataType)
        {
            return _categoryService.GetAll(dataType);
        }
        [HttpGet]
        public Category Get(int id)
        {
            return _categoryService.Get(id);
        }
        [HttpPost]
        public ApiResponse Add(Category entity)
        {
            ApiResponse response = new ApiResponse();
            response.Status = _categoryService.Add(entity);
            response.Data = entity;
            return response;
        }

        [HttpPut]
        public bool Put(Category entity)
        {
            return _categoryService.Update(entity);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _categoryService.Delete(id);
        }

        [HttpGet]
        public List<Category> Search(DataType dataType, string keyword)
        {
            return _categoryService.Search(dataType, keyword);
        }
    }
}
