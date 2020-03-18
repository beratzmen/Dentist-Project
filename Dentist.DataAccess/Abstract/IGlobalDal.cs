using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.DataAccess.Abstract
{
    public interface IGlobalDal
    {
        Global Get(TableType tableType);
        Global GetById(int id);
        List<Global> GetAll(TableType tableType);
        bool Add(Global entity);
        bool Delete(int id);
        bool Update(Global entity);
    }
}
