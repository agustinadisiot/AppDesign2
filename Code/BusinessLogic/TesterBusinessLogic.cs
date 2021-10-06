using BusinessLogicInterfaces;
using Domain;
using RepositoryInterfaces;

namespace BusinessLogic
{
    public class TesterBusinessLogic : ITesterBusinessLogic
    {
        public ITesterDataAccess testerDataAccess { get; set; }

        public TesterBusinessLogic(ITesterDataAccess newTesterDataAccess)
        {
            testerDataAccess = newTesterDataAccess;
        }


        public Tester Add(Tester newDev)
        {
            return testerDataAccess.Create(newDev);
        }
    }


}