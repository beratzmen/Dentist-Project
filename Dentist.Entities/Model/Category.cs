namespace Dentist.Entities.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Category")]
    public partial class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public short DataType { get; set; }

        public short AuditStatus { get; set; }

        public DateTime AuditDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
