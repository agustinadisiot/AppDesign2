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
        List<Developer> GetDevelopers(int id);
        List<Tester> GetTesters(int id);
        ResponseMessage RemoveDeveloperFromProject(int idproject, int idDev);
        ResponseMessage RemoveTesterFromProject(int idproject, int idTester);
        Developer AddDeveloperToProject(int idproject, int idDev);
        Tester AddTesterToProject(int idproject, int idTester);
        ProjectCost GetProjectCost(int id);
        ProjectDuration GetProjectDuration(int id);
    }
}

