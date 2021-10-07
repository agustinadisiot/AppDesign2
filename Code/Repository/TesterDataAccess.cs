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
    public class TesterDataAccess : ITesterDataAccess
    {
        private readonly DbSet<Tester> testers;
        private readonly BugManagerContext context;

        public TesterDataAccess(DbContext newContext)
        {
            context = (BugManagerContext)newContext;
            testers = context.Set<Tester>();
        }

        public Tester Create(Tester tester)
        {

            if (tester is null)
            {
                // TODO
            }

            context.Add(tester);
            context.SaveChanges();

            return tester;
        }

        public List<Bug> GetBugsByName(int idTester, string v)
        {
            throw new NotImplementedException();
        }

        public List<Bug> GetBugsByProject(int idTester, int v)
        {
            throw new NotImplementedException();
        }

        public List<Bug> GetBugsByStatus(int idTester, bool v)
        {
            throw new NotImplementedException();
        }
    }
}
