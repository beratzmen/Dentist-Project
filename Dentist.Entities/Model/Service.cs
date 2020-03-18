namespace Dentist.Entities.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("Service")]
    public partial class Service
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string Description { get; set; }

        [Required]
        [StringLength(150)]
        public string Period { get; set; }

        public decimal Price { get; set; }

        public short AuditStatus { get; set; }

        public DateTime AuditDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
