using BusinessLogicInterfaces;
using Domain;
using System;
using System.Collections.Generic;

namespace RepositoryInterfaces
{
    public interface IAdminDataAccess : IUserDataAccess<Admin>
    {
    }
}
