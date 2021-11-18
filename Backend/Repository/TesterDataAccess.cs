using Domain;
using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class TesterDataAccess : UserDataAccess<Tester>, ITesterDataAccess
    {
        private readonly DbSet<Tester> testers;

        public TesterDataAccess(DbContext newContext) : base(newContext)
        {
            testers = context.Set<Tester>();
            users = testers;
        }

        public List<Tester> GetAllTesters()
        {
            return testers.ToList();
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
            Tester tester = testers.Include("Projects").FirstOrDefault(t => t.Id == idTester);
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
