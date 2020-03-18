using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.DataAccess.Abstract
{
    public interface ICategoryDal
    {
        Category Get(int id);
        List<Category> GetAll(DataType dataType);
        bool Add(Category entity);
        bool Delete(int id);
        bool Update(Category entity);
        List<Category> Search(DataType dataType, string keyword);
    }
}
