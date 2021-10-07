using Domain;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
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
                throw new NonexistentUserException();
            }

            context.Add(tester);
            context.SaveChanges();

            return tester;
        }

        public List<Bug> GetBugsByName(int idTester, string filter)
        {
            Tester tester = testers.FirstOrDefault(t => t.Id == idTester);
            List<Bug> filteredBugs = new List<Bug>();
            foreach (Project project in tester.Projects)
            {
                foreach (Bug bug in project.Bugs)
                {
                    if (bug.Name == filter)
                    {
                        filteredBugs.Add(bug);
                    }
                }
            }

            return filteredBugs;
        }

        public List<Bug> GetBugsByProject(int idTester, int filter)
        {
            Tester tester = testers.FirstOrDefault(t => t.Id == idTester);
            List<Bug> filteredBugs = new List<Bug>();
            foreach (Project project in tester.Projects)
            {
                foreach (Bug bug in project.Bugs)
                {
                    if (bug.ProjectId == filter)
                    {
                        filteredBugs.Add(bug);
                    }
                }
            }
            return filteredBugs;
        }

        public List<Bug> GetBugsByStatus(int idTester, bool filter)
        {
            Tester tester = testers.FirstOrDefault(t => t.Id == idTester);
            List<Bug> filteredBugs = new List<Bug>();
            foreach (Project project in tester.Projects)
            {
                foreach (Bug bug in project.Bugs)
                {
                    if (bug.IsActive == filter)
                    {
                        filteredBugs.Add(bug);
                    }
                }
            }
            return filteredBugs;
        }
    }
}
