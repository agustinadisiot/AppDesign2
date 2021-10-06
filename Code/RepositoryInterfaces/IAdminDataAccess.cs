using BusinessLogicInterfaces;
using Domain;
using System;
using System.Collections.Generic;

namespace RepositoryInterfaces
{
    public interface IAdminDataAccess
    {
        public Admin Create(Admin admin);
    }
}
