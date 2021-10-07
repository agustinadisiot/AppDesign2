using Domain;

namespace BusinessLogicInterfaces
{
    public interface IDeveloperBusinessLogic : IUserBusinessLogic<Developer>
    {
        BugsQuantity GetQuantityBugsResolved(int idDev);
    }
}

