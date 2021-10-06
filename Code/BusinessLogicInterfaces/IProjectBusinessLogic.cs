using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterfaces
{
    public interface IProjectBusinessLogic : IBusinessLogic<Project>
    {
        Project GetByName(string name);

        Project UpdateByName(string name, Project projectUpdated);

        ResponseMessage DeleteByName(string name);
        Bug AddBug(int id, Bug bugExpected);
        List<Bug> GetBugs(int id);
    }
}

