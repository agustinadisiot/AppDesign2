using BusinessLogicInterfaces;
using Domain;
using System;
using System.Collections.Generic;

namespace RepositoryInterfaces
{
    public interface ILoginDataAccess
    {
        string VerifyUser(string username, string password);
        void SaveLogin(LoginToken loginToken);
    }
}
