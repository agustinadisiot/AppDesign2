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
            // TODO separar en dos funciones o en dos clases
            serviceCollection.AddScoped<IBugDataAccess, BugDataAccess>();
            serviceCollection.AddScoped<IProjectDataAccess, ProjectDataAccess>();
            serviceCollection.AddScoped<IAdminDataAccess, AdminDataAccess>();
            serviceCollection.AddScoped<IDeveloperDataAccess, DeveloperDataAccess>();
            serviceCollection.AddScoped<ITesterDataAccess, TesterDataAccess>();

            serviceCollection.AddScoped<IBugBusinessLogic, BugBusinessLogic>();
            serviceCollection.AddScoped<IProjectBusinessLogic, ProjectBusinessLogic>();
            serviceCollection.AddScoped<IAdminBusinessLogic, AdminBusinessLogic>();
            serviceCollection.AddScoped<IDeveloperBusinessLogic, DeveloperBusinessLogic>();
            serviceCollection.AddScoped<ITesterBusinessLogic, TesterBusinessLogic>();
        }

        public void AddDbContextService(string connectionString)
        {
            serviceCollection.AddDbContext<DbContext, BugManagerContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
