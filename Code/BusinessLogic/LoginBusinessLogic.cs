using BusinessLogicInterfaces;
using Domain;
using RepositoryInterfaces;
using System;
using System.Security.Authentication;

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
            string validCredentials = loginDataAccess.VerifyUser(username, password);
            if (validCredentials == null)
                throw new AuthenticationException();

            LoginToken token = new LoginToken { 
                Token = Guid.NewGuid().ToString(),
                Username = username 
            };
            loginDataAccess.SaveLogin(token);
            return token;
        }
    }


}