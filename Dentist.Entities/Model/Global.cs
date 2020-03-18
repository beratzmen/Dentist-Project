namespace Dentist.Entities.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("Global")]
    public partial class Global
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Title { get; set; }
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string Description { get; set; }

        [StringLength(50)]
        public string Day { get; set; }

        //[DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? StartTime { get; set; }
        //[DataType(DataType.Time)]
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan? EndTime { get; set; }

        public int? Since { get; set; }

        public int? Patient { get; set; }

        public int? Certificate { get; set; }

        public int? Doctor { get; set; }

        public byte? Experience { get; set; }

        public byte? ModernEquipment { get; set; }

        public byte? Sincerity { get; set; }
        public string FaceAddress { get; set; }
        public string GoogleAddress { get; set; }
        public string LinkedinAddress { get; set; }
        public string TwitterAddress { get; set; }
        public string Address { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public string ImagePath { get; set; }

        [StringLength(100)]
        public string AreaType { get; set; }

        public short TableType { get; set; }

        public short AuditStatus { get; set; }

        public DateTime AuditDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
