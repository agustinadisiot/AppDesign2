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

        public void AddBusinessLogicService()
        { // TODO cambiar nombre de funcion y clase 
            // TODO cambiar a scoped, el singleton es solo para las pruebas sin data access
            serviceCollection.AddScoped<IBugDataAccess, BugDataAccess>();
            serviceCollection.AddScoped<IBugBusinessLogic, BugBusinessLogic>();
        }

        public void AddDbContextService(string connectionString)
        {
            serviceCollection.AddDbContext<DbContext, BugManagerContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
