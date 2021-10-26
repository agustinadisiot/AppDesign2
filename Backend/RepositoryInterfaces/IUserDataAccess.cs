using BusinessLogicInterfaces;
using Domain;
using System;
using System.Collections.Generic;

namespace RepositoryInterfaces
{
    public interface IUserDataAccess<T>
    {
        public T Create(T newUser);
    }
}
