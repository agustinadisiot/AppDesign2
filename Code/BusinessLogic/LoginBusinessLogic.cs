using BusinessLogicInterfaces;
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
            loginDataAccess.VerifyUser(username, password);
            LoginToken token = new LoginToken { Token = "as;ldfkjasd" };
            loginDataAccess.SaveLogin(token);
            return token;
        }
    }


}