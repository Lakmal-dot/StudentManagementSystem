using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
      
        public DbSet<ClassRoom> ClassRooms { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<AllocateSubject> AllocateSubjects { get; set; }

        public DbSet<AllocateClass> AllocateClasses { get; set; }

        public DbSet<StdTeacherSubMap> StdTeacherSubMaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StudentMgmtDB;Integrated Security=True;Pooling=False;TrustServerCertificate= True");
        }
    }
}
