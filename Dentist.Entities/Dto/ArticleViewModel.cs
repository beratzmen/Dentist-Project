using Dentist.Entities.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dentist.Entities.Dto
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string Description { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public int Counter { get; set; }
        public short AuditStatus { get; set; }
        public DateTime AuditDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Category> CategoryList { get; set; }
        public IPagedList<Article> blogList { get; set; }
        public List<ArticleViewModel> populerBlogList { get; set; }
    }
    public class ArticleUIViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CommentCount { get; set; }
        public List<CommentUIViewModel> Comments { get; set; } // (act) bir kaç yerde bu kullanılmadığı için tekrar yorumları çekmek yerine count çekiyorum
    }
    public class BlogViewModel
    {
        public ArticleBlock ArticleBlock { get; set; }
        public List<Category> Categories { get; set; }
        public List<ArticleUIViewModel> LastAddedArticleList { get; set; }
    }
    public class BlogDetailViewModel
    {
        public ArticleUIViewModel Article { get; set; }
        public List<ArticleUIViewModel> LastAddedArticleList { get; set; }
    }
    public class ArticleBlock
    {
        public List<ArticleUIViewModel> ArticleList { get; set; }
        public double PageCount { get; set; }
    }
}
