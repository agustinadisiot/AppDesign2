using Domain;
using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
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
            context.Add(dev);
            context.SaveChanges();

            return dev;
        }

        public int GetQuantityBugsResolved(int idDev)
        {
            return context.Bugs.Count(b => b.CompletedById == idDev);
        }
    }
}
