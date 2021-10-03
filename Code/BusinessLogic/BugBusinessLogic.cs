using Domain;
using System;
using BusinessLogicInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BugBusinessLogic : IBugBusinessLogic
    {
        /* public IBugDataAccess bugDataAccess { get; set; }

         public BugBusinessLogic(IBugDataAccess newbugDataAccess)
         {
             bugDataAccess = newbugDataAccess;
         }*/


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

        public Bug Update(int idbugToUpdate, Bug bugModified)
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

            return bug;
        }

        public ResponseMessage Delete(int idbugToDelete)
        {
            Bug bug = Bugs.FirstOrDefault(i => i.Id == idbugToDelete);

            if (bug is null)
            {
                throw new NonexistentBugException();
            }

            Bugs.Remove(bug);
            return new ResponseMessage(""); //todo agregar mensaje
        }
    }


}