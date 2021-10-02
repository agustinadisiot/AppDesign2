using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class BugDataAccess
    {
        private readonly DbSet<Bug> bugs;
        private readonly BugManagerContext context;

        public BugDataAccess(BugManagerContext newContext)
        {
            context = newContext;
            bugs = context.Set<Bug>();
        }

        public Bug Create(Bug bug)
        {
            if (bug is null)
            {
                throw new ArgumentNullException("Bug can't be null");// TODO cambiar excepcion
            }

            bugs.Add(bug);
            context.SaveChanges();

            return bug;
        }


        public IEnumerable<Bug> GetAll()
        {

            return context.Bugs;
        }

        public void UpdateAll(Bug bugUpdated)
        {
            if (bugs is null)
                throw new ArgumentNullException("Bugs can't be null"); // TODO cambiar excepcion
            bugs.Update(bugUpdated);
            context.SaveChanges();
        }
    }
}
