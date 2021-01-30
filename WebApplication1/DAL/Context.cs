using WebApplication1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication1.DAL
{
    public class Context : DbContext
    {

        public Context() : base("DefaultConnection")
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}