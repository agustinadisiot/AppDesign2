using BusinessLogic;
using BusinessLogicInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Design;
using RepositoryDataAccess;
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
            // TODO cambiar a scoped, el singleton es solo para las pruebas sin data acces
            serviceCollection.AddSingleton<IBugBusinessLogic, BugBusinessLogic>();
            serviceCollection.AddScoped<IBugDataAccess, BugDataAccess>();
        }

        public void AddDbContextService(string connectionString)
        {
            // TODO ver porque no hacer designContext estatica o hacerla estatica y justificar
            BugManagerContext bugManagerContext = new DesignContext().CreateDbContext(null);
            serviceCollection.AddDbContext<DbContext, BugManagerContext>();
        }
    }
}
