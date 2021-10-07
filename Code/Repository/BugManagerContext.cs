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

        public BugManagerContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Bug>().Ignore(bug => bug.CompletedBy);
            modelBuilder.Entity<Bug>().HasOne(b => b.CompletedBy).WithMany().IsRequired(false);
            //modelBuilder.Entity<Bug>().Property(bug => bug.CompletedBy).IsRequired(false);
        }
    }
}
