namespace Dentist.Entities.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Job")]
    public partial class Job
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public short AuditStatus { get; set; }

        public DateTime AuditDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
