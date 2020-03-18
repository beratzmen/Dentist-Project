using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.DataAccess.Abstract
{
    public interface IBulletinDal
    {
        Bulletin Get(int id);
        List<Bulletin> GetAll();
        bool Add(Bulletin entity);
        bool Delete(int id);
        bool Update(Bulletin entity);
    }
}
