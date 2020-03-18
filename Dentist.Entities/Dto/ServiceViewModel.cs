using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dentist.Entities.Dto
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [StringLength(150)]
        public string Period { get; set; }
        public decimal Price { get; set; }
        public short AuditStatus { get; set; }
        public DateTime AuditDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<Category> CategoryList { get; set; }
    }
    public class ServiceUIViewModel
    {
        public List<Category> ServiceList { get; set; }
        public List<ArticleUIViewModel> ArticleList { get; set; }
    }
}
