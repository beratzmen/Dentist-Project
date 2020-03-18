using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.Entities.Dto
{
    public class AboutViewModel
    {
        public Global aboutus { get; set; }
        public List<EmployeeUIViewModel> employeeList { get; set; }
        public Global statistic { get; set; }
    }
}
