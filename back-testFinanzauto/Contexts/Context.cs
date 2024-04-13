using back_testFinanzauto.Models;
using Microsoft.EntityFrameworkCore;

namespace back_testFinanzauto.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<StudentsModel> Students { get; set; }
        public DbSet<CoursesModel> Courses { get; set; }
        public DbSet<TeachersModel> Teachers { get; set; }
        public DbSet<QualificationModel> Qualification { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QualificationModel>().HasKey(q => new { q.IdStudent, q.IdTeacher, q.IdCourse });
        }
    }
}
