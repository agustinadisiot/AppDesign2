using BusinessLogicInterfaces;
using Domain;
using System;
using System.Collections.Generic;

namespace RepositoryInterfaces
{
    public interface ITesterDataAccess : IUserDataAccess<Tester>
    {
        List<Bug> GetBugsByStatus(int idTester, bool v);
        List<Bug> GetBugsByName(int idTester, string v);
        List<Bug> GetBugsByProject(int idTester, int v);
    }
}
