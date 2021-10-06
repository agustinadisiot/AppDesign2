using BusinessLogicInterfaces;
using Domain;
using System;
using System.Collections.Generic;

namespace RepositoryInterfaces
{
    public interface IDeveloperDataAccess : IUserDataAccess<Developer>
    {
    }
}
