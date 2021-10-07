using BusinessLogicInterfaces;
using Domain;
using RepositoryInterfaces;

namespace BusinessLogic
{
    public class DeveloperBusinessLogic : IDeveloperBusinessLogic
    {
        public IDeveloperDataAccess devDataAccess { get; set; }

        public DeveloperBusinessLogic(IDeveloperDataAccess newDevDataAccess)
        {
            devDataAccess = newDevDataAccess;
        }


        public Developer Add(Developer newDev)
        {
            return devDataAccess.Create(newDev);
        }

        public BugsQuantity GetQuantityBugsResolved(int idDev)
        {
            throw new System.NotImplementedException();
        }
    }


}