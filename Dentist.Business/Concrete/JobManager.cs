using Dentist.DataAccess.Abstract;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.Business.Concrete
{
    public class JobManager : IJobDal
    {
        IJobDal _jobDal;
        public JobManager(IJobDal jobDal)
        {
            this._jobDal = jobDal;
        }
        public bool Add(Job entity)
        {
          return  _jobDal.Add(entity);
        }

        public bool Delete(int id)
        {
            return _jobDal.Delete(id);
        }

        public Job Get(int id)
        {
            return _jobDal.Get(id);
        }

        public List<Job> GetAll()
        {
            return _jobDal.GetAll();
        }

        public bool Update(Job entity)
        {
            return _jobDal.Update(entity);
        }
    }
}
