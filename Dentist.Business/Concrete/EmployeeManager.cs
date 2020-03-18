using Dentist.DataAccess.Abstract;
using Dentist.Entities.Dto;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.Business.Concrete
{
    public class EmployeeManager : IEmployeeDal
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            this._employeeDal = employeeDal;
        }
        public bool Add(Employee entity)
        {
            return _employeeDal.Add(entity);
        }

        public bool Delete(int id)
        {
            return _employeeDal.Delete(id);
        }

        public Employee Get(int id)
        {
            return _employeeDal.Get(id);
        }

        public List<EmployeeViewModel> GetAll()
        {
            return _employeeDal.GetAll();
        }

        public bool Update(Employee entity)
        {
            return _employeeDal.Update(entity);
        }
    }
}
