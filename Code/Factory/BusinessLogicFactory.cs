using BusinessLogic;
using BusinessLogicInterfaces;
using Microsoft.Extensions.DependencyInjection;
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
        {
            // TODO cambiar a scoped, el singleton es solo para las pruebas sin data acces
            serviceCollection.AddSingleton<IBugBusinessLogic, BugBusinessLogic>();
        }
    }
}
