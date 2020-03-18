using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.DataAccess.Abstract
{
    public interface IJobDal
    {
        Job Get(int id);
        List<Job> GetAll();
        bool Add(Job entity);
        bool Delete(int id);
        bool Update(Job entity);
    }
}
