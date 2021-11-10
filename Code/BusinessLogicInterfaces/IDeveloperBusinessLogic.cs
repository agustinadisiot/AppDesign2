using Domain;
using DTO;

namespace BusinessLogicInterfaces
{
    public interface IDeveloperBusinessLogic : IUserBusinessLogic<Developer>
    {
        DeveloperDTO Add(DeveloperDTO newTester);

        int GetQuantityBugsResolved(int idDev);
    }
}

