using Domain;
using System;
using BusinessLogicInterfaces;
using System.Collections.Generic;
using System.Linq;
using RepositoryInterfaces;
using Domain.Utils;
using BugParser;

namespace BusinessLogic
{
    public class BugBusinessLogic : IBugBusinessLogic
    {
        public IBugDataAccess BugDataAccess { get; set; }

        public BugBusinessLogic(IBugDataAccess newBugDataAccess)
        {
            BugDataAccess = newBugDataAccess;
        }

        public Bug GetById(int idBug)
        {
            Bug bug = BugDataAccess.GetById(idBug);
            return bug;
        }

        public IEnumerable<Bug> GetAll()
        {
            return BugDataAccess.GetAll();
        }

        public Bug Add(Bug bug)
        {
            bug.Validate();
            BugDataAccess.Create(bug);
            return bug;
        }

        public Bug Update(int Id, Bug bug)
        {
            bug.Validate();
            return BugDataAccess.Update(Id, bug);
        }


        public ResponseMessage Delete(int Id)
        {
            return BugDataAccess.Delete(Id);

        }

        public void ImportBugs(string path, ImportCompany format, IParserFactory factory = null)
        {
            // This is to allow the tests to include their own mock factory
            if (factory == null)
                factory = new ParserFactory();
            IBugParser parser = factory.GetBugParser(format);
            List<Bug> bugsToImport = parser.GetBugs(path);
            foreach (var bug in bugsToImport)
            {
                Add(bug);
            }
        }

    }


}