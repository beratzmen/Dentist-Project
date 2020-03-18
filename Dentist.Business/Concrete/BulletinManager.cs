using Dentist.DataAccess.Abstract;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.Business.Concrete
{
    public class BulletinManager : IBulletinDal
    {
        IBulletinDal _bulletinDal;
        public BulletinManager(IBulletinDal bulletinDal)
        {
            this._bulletinDal = bulletinDal;
        }
        public bool Add(Bulletin entity)
        {
            return _bulletinDal.Add(entity);
        }

        public bool Delete(int id)
        {
            return _bulletinDal.Delete(id);
        }

        public Bulletin Get(int id)
        {
            return _bulletinDal.Get(id);
        }

        public List<Bulletin> GetAll()
        {
            return _bulletinDal.GetAll();
        }

        public bool Update(Bulletin entity)
        {
            return _bulletinDal.Update(entity);
        }
    }
}
