using Microsoft.EntityFrameworkCore;
using schooldayOne.Models;

namespace schooldayOne.Dbcontext
{
    public class DbContexxt:DbContext
    {
        public DbContexxt(DbContextOptions<DbContexxt> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }




    }
}
