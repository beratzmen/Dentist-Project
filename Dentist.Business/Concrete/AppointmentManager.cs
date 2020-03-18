using Dentist.DataAccess.Abstract;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.Business.Concrete
{
    public class AppointmentManager : IAppointmentDal
    {
        IAppointmentDal _appointmentDal;
        public AppointmentManager(IAppointmentDal appointmentDal)
        {
            this._appointmentDal = appointmentDal;
        }
        public bool Add(Appointment entity)
        {
            return _appointmentDal.Add(entity);
        }

        public bool Delete(int id)
        {
            return _appointmentDal.Delete(id);
        }

        public Appointment Get(int id)
        {
            return _appointmentDal.Get(id);
        }

        public List<Appointment> GetAll()
        {
            return _appointmentDal.GetAll();
        }

        public bool Update(Appointment entity)
        {
            return _appointmentDal.Update(entity);
        }
        public bool StatusUpdate(int id, short status)
        {
            return _appointmentDal.StatusUpdate(id, status);
        }
    }
}
