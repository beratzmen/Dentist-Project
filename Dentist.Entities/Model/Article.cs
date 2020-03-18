namespace Dentist.Entities.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("Article")]
    public partial class Article
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        //[Required]
        //[UIHint("tinymce_jquery_full"), AllowHtml]
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public int Counter { get; set; }

        public short AuditStatus { get; set; }

        public DateTime AuditDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
