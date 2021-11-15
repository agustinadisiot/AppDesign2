using Domain;
using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DeveloperDataAccess : UserDataAccess<Developer>, IDeveloperDataAccess
    {
        private readonly DbSet<Developer> devs;

        public DeveloperDataAccess(DbContext newContext) : base(newContext)
        {
            devs = context.Set<Developer>();
            users = devs;
        }

        public List<Developer> GetAllDevs()
        {
            return devs.ToList();
        }

        public int GetQuantityBugsResolved(int idDev)
        {
            return context.Bugs.Count(b => b.CompletedById == idDev);
        }
    }
}
