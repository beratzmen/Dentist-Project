namespace Dentist.Entities.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ContactMail")]
    public partial class ContactMail
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public short Status { get; set; }

        public short AuditStatus { get; set; }

        public DateTime AuditDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
