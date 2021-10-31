using Domain;

namespace RepositoryInterfaces
{
    public interface IWorkDataAccess
    {
        Work Create(Work work);
        Work GetById(int id);
    }
}