namespace Dentist.Entities.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DentistContext : DbContext
    {
        public DentistContext()
            : base("name=DentistContext")
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Bulletin> Bulletin { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<ContactMail> ContactMail { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Global> Global { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
