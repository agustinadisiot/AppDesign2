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


        public Tester Add(Tester newTester)
        {
            newTester.Validate();
            return testerDataAccess.Create(newTester);
        }

        public List<Bug> GetBugsByStatus(int idTester, bool filter)
        {
            return testerDataAccess.GetBugsByStatus(idTester, filter);

        }

        public List<Bug> GetBugsByName(int idTester, string filter)
        {
            return testerDataAccess.GetBugsByName(idTester, filter);

        }

        public List<Bug> GetBugsByProject(int idTester, int filter)
        {
            return testerDataAccess.GetBugsByProject(idTester, filter);

        }
        public bool VerifyRole(string token)
        {
            return testerDataAccess.VerifyRole(token);
        }
    }


}