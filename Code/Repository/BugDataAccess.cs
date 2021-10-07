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
    public class BugDataAccess : IBugDataAccess
    {
        private readonly DbSet<Bug> bugs;
        private readonly BugManagerContext context;

        public BugDataAccess(DbContext newContext)
        {
            context = (BugManagerContext)newContext;
            bugs = context.Set<Bug>();
        }

        public Bug Create(Bug bug)
        {

            if (bug is null)
            {
                throw new NonexistentBugException();
            }
            AddProjectIdToBug(bug);

            context.Add(bug);
            context.SaveChanges();

            return bug;


        }

        private void AddProjectIdToBug(Bug bug)
        {
            if ((bug.ProjectId == 0) && (bug.ProjectName != null))
            {
                Project bugsProject = context.Projects.First(p => p.Name == bug.ProjectName);
                bug.ProjectId = bugsProject.Id;
            }
        }
        public Bug GetById(int id)
        {
            Bug bug;
            try
            {
                bug = bugs.First(bug => bug.Id == id);
            }
            catch (InvalidOperationException e)
            {
                throw new NonexistentBugException();
            }
            return bug;
        }

        public IEnumerable<Bug> GetAll()
        {
            return context.Bugs;
        }

        public Bug Update(int Id, Bug bugUpdated)
        {
            if (bugUpdated is null)
                throw new NonexistentBugException();
            Bug bugToUpdate = GetById(Id);
            bugToUpdate.Name = bugUpdated.Name;
            bugToUpdate.Version = bugUpdated.Version;
            bugToUpdate.IsActive = bugUpdated.IsActive;
            bugToUpdate.ProjectName = bugUpdated.ProjectName;
            bugToUpdate.ProjectId = bugUpdated.ProjectId;
            bugToUpdate.CompletedBy = bugUpdated.CompletedBy;
            bugToUpdate.CompletedById = bugUpdated.CompletedById;
            bugToUpdate.Description = bugUpdated.Description;
            context.SaveChanges();
            bugToUpdate.Project = null;
            return bugToUpdate;
        }

        public ResponseMessage Delete(int id)
        {
            Bug bugDelete = GetById(id);
            bugs.Remove(bugDelete);
            context.SaveChanges();
            return new ResponseMessage("Deleted successfully");
        }
    }
}
