using Domain;

namespace BusinessLogicInterfaces
{
    public interface IProjectBusinessLogic : IBusinessLogic<Project>
    {
        Project GetByName(string name);
    }
}

