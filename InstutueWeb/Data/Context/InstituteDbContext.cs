using InstutueWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstutueWeb.Data.Context
{
    public class InstituteDbContext : DbContext
    {
        public InstituteDbContext(DbContextOptions<InstituteDbContext>  options): base(options)
        {
           
        }

       public DbSet<Department> Departments { get; set; }
       public DbSet<Course> Courses { get; set; }

    }
}
