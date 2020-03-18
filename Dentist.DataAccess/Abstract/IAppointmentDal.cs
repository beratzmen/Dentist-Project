using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.DataAccess.Abstract
{
    public interface IAppointmentDal
    {
        Appointment Get(int id);
        List<Appointment> GetAll();
        bool Add(Appointment entity);
        bool Delete(int id);
        bool Update(Appointment entity);
        bool StatusUpdate(int id, short status);
    }
}
