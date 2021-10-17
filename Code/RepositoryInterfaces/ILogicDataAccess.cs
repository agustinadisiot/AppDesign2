using BusinessLogicInterfaces;
using BusinessLogicInterfaces.Utils; // TODO poner el token en otro lado o que el data access te pase solo el guid
using Domain;
using System;
using System.Collections.Generic;

namespace RepositoryInterfaces
{
    public interface ILoginDataAccess
    {
        LoginToken Login(string username, string password);
    }
}
