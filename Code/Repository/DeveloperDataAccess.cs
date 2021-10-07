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
    public class DeveloperDataAccess : IDeveloperDataAccess
    {
        private readonly DbSet<Developer> devs;
        private readonly BugManagerContext context;

        public DeveloperDataAccess(DbContext newContext)
        {
            context = (BugManagerContext)newContext;
            devs = context.Set<Developer>();
        }

        public Developer Create(Developer dev)
        {

            if (dev is null)
            {
                // TODO
            }

            context.Add(dev);
            context.SaveChanges();

            return dev;
        }

        public BugsQuantity GetQuantityBugsResolved(int idDev)
        {
            throw new NotImplementedException();
        }
    }
}
