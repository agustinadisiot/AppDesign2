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
    public class ServiceFactory
    {
        private readonly IServiceCollection serviceCollection;

        public ServiceFactory(IServiceCollection newServiceCollection)
        {
            serviceCollection = newServiceCollection;
        }

        public void AddCustomServices()
        {
            serviceCollection.AddScoped<IBugDataAccess, BugDataAccess>();
            serviceCollection.AddScoped<IProjectDataAccess, ProjectDataAccess>();
            serviceCollection.AddScoped<IBugBusinessLogic, BugBusinessLogic>();
            serviceCollection.AddScoped<IProjectBusinessLogic, ProjectBusinessLogic>();

        }

        public void AddDbContextService(string connectionString)
        {
            serviceCollection.AddDbContext<DbContext, BugManagerContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
