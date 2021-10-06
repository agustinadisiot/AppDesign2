using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterfaces
{
    public interface IProjectBusinessLogic : IBusinessLogic<Project>
    {
        Project GetByName(string name);

        Project UpdateByName(string name, Project projectUpdated);

        ResponseMessage DeleteByName(string name);
        List<Bug> GetBugs(int id);
        BugsQuantity GetBugsQuantity(int idProject);
    }
}

