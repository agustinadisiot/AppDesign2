using Domain;

namespace RepositoryInterfaces
{
    public interface IDeveloperDataAccess : IUserDataAccess<Developer>
    {
        int GetQuantityBugsResolved(int idDev);
    }
}
