using BusinessLogic;
using BusinessLogicInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Design;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DeveloperDataAccess : UserDataAccess<Developer>, IDeveloperDataAccess
    {
        public DeveloperDataAccess(DbContext newContext) : base(newContext)
        {
            users = context.Set<Developer>();
        }

        public int GetQuantityBugsResolved(int idDev)
        {
            return context.Bugs.Count(b => b.CompletedById == idDev);
        }
    }
}
