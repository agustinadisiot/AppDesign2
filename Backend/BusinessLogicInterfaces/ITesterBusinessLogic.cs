using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterfaces
{
    public interface ITesterBusinessLogic : IUserBusinessLogic<Tester>
    {
        List<Bug> GetBugsByStatus(int idTester, bool filter);
        List<Bug> GetBugsByName(int idTester, string filter);
        List<Bug> GetBugsByProject(int idTester, int filter);
    }
}

