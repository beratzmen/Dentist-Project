using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Entities.Dto
{
    public class HomeViewModel
    {
        public HomeUIViewModel Welcome { get; set; }
        public AboutViewModel About { get; set; }
        public List<CategoryUIViewModel> Service { get; set; }
        public List<Service> Pricing { get; set; }
        public List<EmployeeUIViewModel> Employee { get; set; }
        public List<ArticleUIViewModel> Article { get; set; }
    }
    public class HomeUIViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AreaType { get; set; }
    }
}
