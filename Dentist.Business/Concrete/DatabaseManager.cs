using Dentist.DataAccess.Abstract;
using Dentist.Entities.Dto;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Business.Concrete
{
    public class DatabaseManager : IDatabaseDal
    {
        IDatabaseDal _databaseDal;
        public DatabaseManager(IDatabaseDal databaseDal)
        {
            this._databaseDal = databaseDal;
        }

        public HomeViewModel GetMainPageItems()
        {
            return _databaseDal.GetMainPageItems();
        }

        public AboutViewModel GetAbout()
        {
            return _databaseDal.GetAbout();
        }

        public ServiceUIViewModel GetService()
        {
            return _databaseDal.GetService();
        }

        public List<Service> GetPricing()
        {
            return _databaseDal.GetPricing();
        }

        public BlogViewModel GetBlog(int pageNumber)
        {
            return _databaseDal.GetBlog(pageNumber);
        }

        public BlogDetailViewModel GetBlogDetail(int id)
        {
            var bdvm = _databaseDal.GetBlogDetail(id);
            if (bdvm != null && bdvm.Article != null)
                bdvm.Article.Comments = BuildTree(bdvm.Article.Comments);
            return bdvm;
        }
        private static List<CommentUIViewModel> BuildTree(List<CommentUIViewModel> items)
        {
            if (items == null || items.Count <= 0)
                return items;
            items.ForEach(i => i.Comments = items.Where(ch => ch.ReplyId == i.Id).ToList());
            return items.Where(i => i.ReplyId == null).ToList();
        }
    }
}
