﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

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
            optionsBuilder.LogTo(Console.WriteLine);
            var bugManagerContext = new BugManagerContext(optionsBuilder.Options);
            return bugManagerContext;
        }
    }
}