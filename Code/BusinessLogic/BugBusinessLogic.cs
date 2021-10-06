using Domain;
using System;
using BusinessLogicInterfaces;
using System.Collections.Generic;
using System.Linq;
using RepositoryInterfaces;
using Domain.Utils;

namespace BusinessLogic
{
    public class BugBusinessLogic : IBugBusinessLogic
    {
        public IBugDataAccess bugDataAccess { get; set; }

        public BugBusinessLogic(IBugDataAccess newBugDataAccess)
        {
            bugDataAccess = newBugDataAccess;
        }

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

        public Bug Update(int Id, Bug bug)
        {
            return bugDataAccess.Update(Id, bug);
        }


        public ResponseMessage Delete(int Id)
        {
            return bugDataAccess.Delete(Id);

        }

        public List<Bug> ImportBugs(string path, ImportCompany format)
        {
            throw new NotImplementedException();
        }
    }


}