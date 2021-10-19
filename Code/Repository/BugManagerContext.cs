using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BugManagerContext : DbContext
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Developer> Developer { get; set; }
        public DbSet<Tester> Tester { get; set; }
        public DbSet<Work> Works { get; set; }

        public BugManagerContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
