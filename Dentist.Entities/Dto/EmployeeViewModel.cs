using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dentist.Entities.Dto
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string JobName { get; set; }
        [Required]
        [StringLength(150)]
        public string FullName { get; set; }
        public string ImagePath { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public short AuditStatus { get; set; }
        public DateTime AuditDate { get; set; }
        public List<Job> JobList { get; set; }
    }
    public class EmployeeUIViewModel
    {
        public string FullName { get; set; }
        public string ImagePath { get; set; }
        public string JobName { get; set; }
    }
}
