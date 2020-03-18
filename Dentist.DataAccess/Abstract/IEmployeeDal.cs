using Dentist.Entities.Dto;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.DataAccess.Abstract
{
    public interface IEmployeeDal
    {
        Employee Get(int id);
        List<EmployeeViewModel> GetAll();
        bool Add(Employee entity);
        bool Delete(int id);
        bool Update(Employee entity);
    }
}
