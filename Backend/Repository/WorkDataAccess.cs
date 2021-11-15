using Domain;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Repository;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class WorkDataAccess : IWorkDataAccess
    {
        private readonly DbSet<Work> works;
        private BugManagerContext context;

        public WorkDataAccess(BugManagerContext newContext)
        {
            context = (BugManagerContext)newContext;
            works = context.Set<Work>();
        }

        public Work Create(Work work)
        {
            if (work is null)
            {
                throw new NonexistentWorkException();
            }
            AddProjectIdToWork(work);

            context.Add(work);
            context.SaveChanges();

            return work;
        }

        private void AddProjectIdToWork(Work work)
        {
            if ((work.ProjectId == 0) && (work.ProjectName != null))
            {
                Project worksProject = context.Projects.First(p => p.Name == work.ProjectName);
                work.ProjectId = worksProject.Id;
            }
        }

        public Work GetById(int id)
        {
            Work work;
            try
            {
                work = works.First(work => work.Id == id);
            }
            catch (InvalidOperationException e)
            {
                throw new NonexistentWorkException();
            }
            return work;
        }

        public List<Work> GetAll(string token)
        {
            throw new NotImplementedException();
        }
    }
}