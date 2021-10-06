using Domain;

namespace BusinessLogicInterfaces
{
    public interface IProjectBusinessLogic : IBusinessLogic<Project>
    {
        Project GetByName(string name);

        Project UpdateByName(string name, Project projectUpdated);

        ResponseMessage DeleteByName(string name);
    }
}

