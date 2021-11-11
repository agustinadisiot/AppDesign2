using Domain;
using System;
using BusinessLogicInterfaces;
using System.Collections.Generic;
using System.Linq;
using RepositoryInterfaces;
using Domain.Utils;
using BugParser;
using DTO;
using CustomBugImportation;

namespace BusinessLogic
{
    public class BugBusinessLogic : IBugBusinessLogic
    {
        public IBugDataAccess BugDataAccess { get; set; }

        public BugBusinessLogic(IBugDataAccess newBugDataAccess)
        {
            BugDataAccess = newBugDataAccess;
        }

        public BugDTO GetById(int idBug)
        {
            Bug bug = BugDataAccess.GetById(idBug); 
            return new BugDTO(bug);
        }

        public IEnumerable<BugDTO> GetAll(TokenIdDTO idRole)
        {
            List<Bug> bugs = (List<Bug>)BugDataAccess.GetAll();
            if (idRole.Role == Roles.Dev) {
                List<Bug> myBugs = bugs.FindAll(b => b.Project.Developers.Exists(d => d.Id == idRole.Id));
                return myBugs.ConvertAll(b => new BugDTO(b));
            }
            if (idRole.Role == Roles.Tester)
            {
                List<Bug> myBugs = bugs.FindAll(b => b.Project.Testers.Exists(t => t.Id == idRole.Id));
                return myBugs.ConvertAll(b => new BugDTO(b));
            }
            return bugs.ConvertAll(b => new BugDTO(b));
        }

        public BugDTO Add(BugDTO bugDTO)
        {
            Bug bug = bugDTO.ConvertToDomain();
            bug.Validate();
            BugDataAccess.Create(bug);
            return bugDTO;
        }

        public BugDTO Update(int Id, BugDTO bugDTO)
        {
            Bug bugMod = bugDTO.ConvertToDomain();
            bugMod.Validate();
            return new BugDTO(BugDataAccess.Update(Id, bugMod));
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
                Add(new BugDTO(bug));
            }
        }

        public List<ImporterInfo> GetCustomImportersInfo()
        {
            throw new NotImplementedException();
        }
    }


}