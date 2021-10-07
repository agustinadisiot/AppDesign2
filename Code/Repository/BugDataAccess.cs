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
            Bug bug = bugs.First(bug => bug.Id == id);
            if (bug == null) throw new NonexistentBugException();
            return bug;
        }

        public IEnumerable<Bug> GetAll()
        {
            return context.Bugs;
        }

        public Bug Update(int Id, Bug bugUpdated)
        {
            if (bugs is null)
                throw new NonexistentBugException();
            //bugs.Update(bugUpdated); // TODO ver porque no anda  esto, seguramente tenga que 
            // ver con el context
            Bug bugToUpdate = GetById(Id);
            bugToUpdate.Name = bugUpdated.Name;
            bugToUpdate.Version = bugUpdated.Version;
            bugToUpdate.IsActive = bugUpdated.IsActive;
            bugToUpdate.ProjectName = bugUpdated.ProjectName;
            bugToUpdate.CompletedBy = bugUpdated.CompletedBy;
            bugToUpdate.Project = bugUpdated.Project;
            bugToUpdate.Description = bugUpdated.Description;
            context.SaveChanges();
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
