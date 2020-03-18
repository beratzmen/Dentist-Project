using Dentist.Entities.Dto;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.DataAccess.Abstract
{
    public interface IDatabaseDal
    {
        HomeViewModel GetMainPageItems();
        AboutViewModel GetAbout();
        ServiceUIViewModel GetService();
        List<Service> GetPricing();
        BlogViewModel GetBlog(int pageNumber);
        BlogDetailViewModel GetBlogDetail(int id);
    }
}
