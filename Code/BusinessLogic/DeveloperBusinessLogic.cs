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
            newDev.Validate();
            return devDataAccess.Create(newDev);
        }

        public int GetQuantityBugsResolved(int idDev)
        {
            return devDataAccess.GetQuantityBugsResolved(idDev);
        }

        public bool VerifyRole(string token)
        {
            return devDataAccess.VerifyRole(token);
        }
    }


}