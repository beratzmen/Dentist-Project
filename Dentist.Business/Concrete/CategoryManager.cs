using Dentist.DataAccess.Abstract;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.Business.Concrete
{
    public class CategoryManager : ICategoryDal
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }
        public bool Add(Category entity)
        {
            return _categoryDal.Add(entity);
        }

        public bool Delete(int id)
        {
            return _categoryDal.Delete(id);
        }

        public Category Get(int id)
        {
            return _categoryDal.Get(id);
        }

        public List<Category> GetAll(DataType dataType)
        {
            return _categoryDal.GetAll(dataType);
        }

        public bool Update(Category entity)
        {
            return _categoryDal.Update(entity);
        }
        public List<Category> Search(DataType dataType, string keyword)
        {
            if (string.IsNullOrEmpty(keyword) || string.IsNullOrWhiteSpace(keyword))
                return GetAll(dataType);
            return _categoryDal.Search(dataType, keyword);
        }
    }
}
