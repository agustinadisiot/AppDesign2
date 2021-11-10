using Domain;

namespace BusinessLogicInterfaces
{
    public interface IUserBusinessLogic<T>
    {
        bool VerifyRole(string token);
    }
}

