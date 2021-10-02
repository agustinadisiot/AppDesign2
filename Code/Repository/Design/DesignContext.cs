using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Repository.Design
{
    public class DesignContext : IDesignTimeDbContextFactory<BugManagerContext>
    {
        public BugManagerContext CreateDbContext(string[] args)
        {
            DotNetEnv.Env.Load("./Environment/.env");
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);

            var bugManagerContext = new BugManagerContext(optionsBuilder.Options);

            return bugManagerContext;
        }
    }
}