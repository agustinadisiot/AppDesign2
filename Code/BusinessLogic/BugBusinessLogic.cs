using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BugBusinessLogic : IBusinessLogic<Bug>
    {
        public List<Bug> Bugs { get; set; }

        public BugBusinessLogic()
        {
            Bugs = new List<Bug>();
        }

        public Bug GetById(int idBug)
        {
            Bug bug = Bugs.FirstOrDefault((i) => i.Id == idBug);

            return bug;
        }

        public IEnumerable<Bug> GetAll()
        {
            return Bugs;
        }

        public Bug Add(Bug bug)
        {
            Bugs.Add(bug);
            return bug;
        }

        public void Update(int idbugToUpdate, Bug bugModified)
        {
            Bug bug = Bugs.FirstOrDefault(i => i.Id == idbugToUpdate);

            if (bug is null)
            {
                throw new NonexistentBugException();
            }

            bug.Name = bugModified.Name;
            bug.Description = bugModified.Description;
            bug.Version = bugModified.Version;
            bug.CompletedBy = bugModified.CompletedBy;
            bug.IsActive = bugModified.IsActive;
        }

        public void Delete(int idbugToDelete)
        {
            Bug bug = Bugs.FirstOrDefault(i => i.Id == idbugToDelete);

            if (bug is null)
            {
                throw new NonexistentBugException();
            }

            Bugs.Remove(bug);
        }
    }
}