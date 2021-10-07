using BusinessLogic;
using BusinessLogicInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Design;
using RepositoryInterfaces;
using System;

namespace Factory
{
    public class DataAccessFactory
    {
        private readonly IServiceCollection serviceCollection;

        public DataAccessFactory(IServiceCollection newServiceCollection)
        {
            serviceCollection = newServiceCollection;
        }

        public void AddCustomServices()
        {
            serviceCollection.AddScoped<IBugDataAccess, BugDataAccess>();
            serviceCollection.AddScoped<IProjectDataAccess, ProjectDataAccess>();
            serviceCollection.AddScoped<IAdminDataAccess, AdminDataAccess>();
            serviceCollection.AddScoped<IDeveloperDataAccess, DeveloperDataAccess>();
            serviceCollection.AddScoped<ITesterDataAccess, TesterDataAccess>();
        }

        public void AddDbContextService(string connectionString)
        {
            serviceCollection.AddDbContext<DbContext, BugManagerContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
