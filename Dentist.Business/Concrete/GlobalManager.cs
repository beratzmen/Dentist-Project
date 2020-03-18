using Dentist.DataAccess.Abstract;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.Business.Concrete
{
    public class GlobalManager : IGlobalDal
    {
        IGlobalDal _globalDal;
        public GlobalManager(IGlobalDal globalDal)
        {
            this._globalDal = globalDal;
        }
        public bool Add(Global entity)
        {
            return _globalDal.Add(entity);
        }

        public bool Delete(int id)
        {
            return _globalDal.Delete(id);
        }

        public Global Get(TableType tableType)
        {
            return _globalDal.Get(tableType);
        }

        public Global GetById(int id)
        {
            return _globalDal.GetById(id);
        }

        public List<Global> GetAll(TableType tableType)
        {
            return _globalDal.GetAll(tableType);
        }

        public bool Update(Global entity)
        {
            return _globalDal.Update(entity);
        }
    }
}
