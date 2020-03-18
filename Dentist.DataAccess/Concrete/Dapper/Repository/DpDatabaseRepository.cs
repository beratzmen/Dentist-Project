using Dentist.DataAccess.Abstract;
using Dentist.DataAccess.Concrete.Dapper.Context;
using Dentist.Entities.Dto;
using Dentist.Entities.Enum.Database;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.DataAccess.Concrete.Dapper.Repository
{
    public class DpDatabaseRepository : IDatabaseDal
    {
        DapperContext dc = new DapperContext();
        public HomeViewModel GetMainPageItems()
        {
            HomeViewModel hvm = new HomeViewModel();

            string employeeQuery = "select TOP(3) Employee.FullName, Employee.ImagePath, Job.Title as JobName from Employee ";
            employeeQuery += "inner join Job on Employee.JobId = Job.Id ";
            employeeQuery += "where Employee.AuditStatus != " + (short)AuditStatus.deleted + " AND Job.AuditStatus != " + (short)AuditStatus.deleted;
            hvm.Employee = dc.Query<EmployeeUIViewModel>(employeeQuery).ToList();

            string globalQuery = "select * from Global ";
            globalQuery += "where Global.AuditStatus != " + (short)AuditStatus.deleted + " AND (Global.TableType = " + (short)TableType.Home + " OR Global.TableType = " + (short)TableType.About + " OR Global.TableType = " + (short)TableType.Statistic + ")";
            var globalList = dc.Query<Global>(globalQuery).ToList();
            if (globalList != null && globalList.Count > 0)
            {
                hvm.Welcome = globalList.Where(p => p.TableType == (short)TableType.Home).Select(ppp => new HomeUIViewModel() { Title = ppp.Title, Description = ppp.Description, AreaType = ppp.AreaType }).FirstOrDefault();
                AboutViewModel aboutViewModel = new AboutViewModel();
                aboutViewModel.aboutus = globalList.FirstOrDefault(p => p.TableType == (short)TableType.About);
                aboutViewModel.statistic = globalList.FirstOrDefault(p => p.TableType == (short)TableType.Statistic);
                aboutViewModel.employeeList = hvm.Employee;
                hvm.About = aboutViewModel;
            }

            string serviceQuery = "select TOP(6) * from Category ";
            serviceQuery += "where Category.AuditStatus != " + (short)AuditStatus.deleted + " AND Category.DataType = " + (short)DataType.Service;
            hvm.Service = dc.Query<CategoryUIViewModel>(serviceQuery).ToList();

            string pricingQuery = "select TOP(10) * from Service ";
            pricingQuery += "where Service.AuditStatus != " + (short)AuditStatus.deleted;
            hvm.Pricing = dc.Query<Service>(pricingQuery).ToList();

            string articleQuery = "SELECT top(3) art.Id,art.Title,art.Description,art.ImagePath,art.CreatedDate, COUNT(comm.Id) AS CommentCount FROM Article art ";
            articleQuery += "INNER JOIN Comment comm ON comm.ArticleId = art.Id ";
            articleQuery += "where art.AuditStatus != 3 AND comm.AuditStatus != " + (short)AuditStatus.deleted + " ";
            articleQuery += "GROUP BY art.Id,art.Title,art.Id,art.Title,art.Description,art.ImagePath,art.CreatedDate";
            hvm.Article = dc.Query<ArticleUIViewModel>(articleQuery).ToList();
            return hvm;
        }
        public AboutViewModel GetAbout()
        {
            AboutViewModel avm = new AboutViewModel();

            string globalQuery = "select * from Global ";
            globalQuery += "where Global.AuditStatus != " + (short)AuditStatus.deleted + " AND (Global.TableType = " + (short)TableType.About + " OR Global.TableType = " + (short)TableType.Statistic + ")";
            var globalList = dc.Query<Global>(globalQuery).ToList();
            if (globalList != null)
            {
                avm.aboutus = globalList.FirstOrDefault(p => p.TableType == (short)TableType.About);
                avm.statistic = globalList.FirstOrDefault(p => p.TableType == (short)TableType.Statistic);
            }

            string employeeQuery = "select TOP(3) Employee.FullName, Employee.ImagePath, Job.Title as JobName from Employee ";
            employeeQuery += "inner join Job on Employee.JobId = Job.Id ";
            employeeQuery += "where Employee.AuditStatus != " + (short)AuditStatus.deleted + " AND Job.AuditStatus != " + (short)AuditStatus.deleted;
            avm.employeeList = dc.Query<EmployeeUIViewModel>(employeeQuery).ToList();

            return avm;
        }
        public ServiceUIViewModel GetService()
        {
            ServiceUIViewModel svm = new ServiceUIViewModel();

            string serviceQuery = "select * from Category ";
            serviceQuery += "where Category.AuditStatus != " + (short)AuditStatus.deleted + " AND Category.DataType = " + (short)DataType.Service;
            svm.ServiceList = dc.Query<Category>(serviceQuery).ToList();

            string articleQuery = "SELECT top(3) art.Id,art.Title,art.Description,art.ImagePath,art.CreatedDate, COUNT(comm.Id) AS CommentCount FROM Article art ";
            articleQuery += "INNER JOIN Comment comm ON comm.ArticleId = art.Id ";
            articleQuery += "where art.AuditStatus != 3 AND comm.AuditStatus != " + (short)AuditStatus.deleted + " ";
            articleQuery += "GROUP BY art.Id,art.Title,art.Id,art.Title,art.Description,art.ImagePath,art.CreatedDate";
            svm.ArticleList = dc.Query<ArticleUIViewModel>(articleQuery).ToList();

            return svm;
        }
        public List<Service> GetPricing()
        {
            string pricingQuery = "select Srv.Title, Srv.Period, Srv.Price from Service as Srv ";
            pricingQuery += "INNER JOIN Category as Cat ON Cat.Id = Srv.CategoryId AND Cat.AuditStatus != " + (short)AuditStatus.deleted + " ";
            pricingQuery += "where Srv.AuditStatus != " + (short)AuditStatus.deleted;
            return dc.Query<Service>(pricingQuery).ToList();
        }
        public BlogViewModel GetBlog(int pageNumber)
        {
            BlogViewModel bvm = new BlogViewModel();
            bvm.ArticleBlock = new ArticleBlock();
            bvm.ArticleBlock.PageCount = Math.Ceiling((dc.QuerySingle<double>("select count(Id) as TotalArticleCount from Article where AuditStatus != " + (short)AuditStatus.deleted) / 5));
            if (pageNumber <= 0)
                pageNumber = 1;
            string articleQuery = "declare @pageNumber INT = " + (pageNumber - 1) + ", @pageSize INT = 5 ";
            articleQuery += "SELECT art.Id,art.Title,art.Description,art.ImagePath,art.CreatedDate, (SELECT Count(Id) from Comment where Comment.ArticleId = art.Id) AS CommentCount ";
            articleQuery += "FROM Article art ";
            articleQuery += "where art.AuditStatus != " + (short)AuditStatus.deleted + " ";
            articleQuery += "order by art.Id offset @pageNumber * @pageSize rows fetch next @pageSize rows only ";
            bvm.ArticleBlock.ArticleList = dc.Query<ArticleUIViewModel>(articleQuery).ToList();

            string serviceQuery = "select * from Category ";
            serviceQuery += "where Category.AuditStatus != " + (short)AuditStatus.deleted + " AND Category.DataType = " + (short)DataType.Article;
            bvm.Categories = dc.Query<Category>(serviceQuery).ToList();

            string lastArticlesQuery = "SELECT top(3) art.Id,art.Title,art.Description,art.ImagePath,art.CreatedDate, (SELECT Count(Id) from Comment where Comment.ArticleId = art.Id) AS CommentCount ";
            lastArticlesQuery += "FROM Article art ";
            lastArticlesQuery += "where art.AuditStatus != " + (short)AuditStatus.deleted;
            bvm.LastAddedArticleList = dc.Query<ArticleUIViewModel>(lastArticlesQuery).ToList();
            return bvm;
        }
        public BlogDetailViewModel GetBlogDetail(int id)
        {
            BlogDetailViewModel bdvm = new BlogDetailViewModel();
            string articleQuery = "SELECT art.Id,art.Title,art.Description,art.ImagePath,art.CreatedDate, (SELECT Count(Id) from Comment where Comment.ArticleId = art.Id) AS CommentCount ";
            articleQuery += "FROM Article art ";
            articleQuery += "where art.AuditStatus != " + (short)AuditStatus.deleted + " AND art.Id = " + id;
            bdvm.Article = dc.QuerySingle<ArticleUIViewModel>(articleQuery);

            string lastArticlesQuery = "SELECT top(3) art.Id,art.Title,art.Description,art.ImagePath,art.CreatedDate, (SELECT Count(Id) from Comment where Comment.ArticleId = art.Id) AS CommentCount ";
            lastArticlesQuery += "FROM Article art ";
            lastArticlesQuery += "where art.AuditStatus != " + (short)AuditStatus.deleted;
            bdvm.LastAddedArticleList = dc.Query<ArticleUIViewModel>(lastArticlesQuery).ToList();

            string commentQuery = "select comm.Id, comm.ReplyId, comm.FullName, comm.Description, comm.CreatedDate from Comment comm ";
            commentQuery += "where comm.AuditStatus != " + (short)AuditStatus.deleted + " AND comm.ArticleId = " + id;
            if (bdvm.Article != null)
                bdvm.Article.Comments = dc.Query<CommentUIViewModel>(commentQuery).ToList();

            return bdvm;
        }
    }
}
