using BusinessLogicInterfaces;
using BusinessLogicInterfaces.Utils;
using Domain;
using RepositoryInterfaces;

namespace BusinessLogic
{
    public class LoginBusinessLogic : ILoginBusinessLogic
    {
        public ILoginDataAccess loginDataAccess { get; set; }

        public LoginBusinessLogic(ILoginDataAccess newLoginDataAccess)
        {
            loginDataAccess = newLoginDataAccess;
        }

        public LoginToken Login(string username, string password)
        {
            return loginDataAccess.Login(username, password);
        }
    }


}