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
    public class BusinessLogicFactory
    {
        private readonly IServiceCollection serviceCollection;

        public BusinessLogicFactory(IServiceCollection newServiceCollection)
        {
            serviceCollection = newServiceCollection;
        }

        public void AddCustomServices()
        {
            serviceCollection.AddScoped<IBugBusinessLogic, BugBusinessLogic>();
            serviceCollection.AddScoped<IProjectBusinessLogic, ProjectBusinessLogic>();
            serviceCollection.AddScoped<IAdminBusinessLogic, AdminBusinessLogic>();
            serviceCollection.AddScoped<IDeveloperBusinessLogic, DeveloperBusinessLogic>();
            serviceCollection.AddScoped<ITesterBusinessLogic, TesterBusinessLogic>();
            serviceCollection.AddScoped<ILoginBusinessLogic, LoginBusinessLogic>();
        }

    }
}
