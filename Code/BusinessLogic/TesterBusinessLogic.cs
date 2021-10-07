using BusinessLogicInterfaces;
using Domain;
using RepositoryInterfaces;
using System.Collections.Generic;

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

        public List<Bug> GetBugsByStatus(int idTester, bool filter)
        {
            throw new System.NotImplementedException();
        }

        public List<Bug> GetBugsByName(int idTester, string filter)
        {
            throw new System.NotImplementedException();
        }

        public List<Bug> GetBugsByProject(int idTester, int filter)
        {
            throw new System.NotImplementedException();
        }
    }


}