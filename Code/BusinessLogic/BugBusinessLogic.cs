using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BugBusinessLogic
    {
        public List<Bug> Bugs { get; set; }

        public BugBusinessLogic()
        {
            Bugs = new List<Bug>();
        }

        public void AddBug(Bug bug)
        {
            Bugs.Add(bug);
        }

        public void DeleteBug(int idbugToDelete)
        {
            Bug bug = Bugs.FirstOrDefault(i => i.ID == idbugToDelete);

            if (bug is null)
            {
                throw new NonexistentBugException();
            }

            Bugs.Remove(bug);
        }

        public Bug GetById(int idBug)
        {
            Bug bug = Bugs.FirstOrDefault((i) => i.ID == idBug);

            return bug;
        }

        public IEnumerable<Bug> GetAll()
        {
            return Bugs;
        }

        public void UpdateBug(int idbugToUpdate, Bug bugModified)
        {
            Bug bug = Bugs.FirstOrDefault(i => i.ID == idbugToUpdate);

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
    }
}