using Domain;
using System;
using BusinessLogicInterfaces;
using System.Collections.Generic;
using System.Linq;
using RepositoryInterfaces;

namespace BusinessLogic
{
    public class BugBusinessLogic : IBugBusinessLogic
    {
        public IBugDataAccess bugDataAccess { get; set; }

        public BugBusinessLogic(IBugDataAccess newbugDataAccess)
        {
            bugDataAccess = newbugDataAccess;
        }


        /*      public List<Bug> Bugs { get; set; }

              public BugBusinessLogic()
              {
                  Bugs = new List<Bug>();
              }
      */
        public Bug GetById(int idBug)
        {
            Bug bug = bugDataAccess.GetById(idBug);
            return bug;
        }

        public IEnumerable<Bug> GetAll()
        {
            return bugDataAccess.GetAll();
        }

        public Bug Add(Bug bug)
        {
            bugDataAccess.Create(bug);
            return bug;
        }

        public Bug Update(int Id, Bug t)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Delete(int Id)
        {
            throw new NotImplementedException();
        }

        /*        public Bug Update(int idbugToUpdate, Bug bugModified)
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
                }*/
    }


}