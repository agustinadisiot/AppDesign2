using Domain;

namespace BusinessLogicInterfaces
{
    public interface IUserBusinessLogic<T>
    {
        T Add(T newUser);
        bool VerifyRole(string token);
    }
}

