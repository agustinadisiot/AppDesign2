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
using CustomBugImporter;

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

        public IEnumerable<BugDTO> GetAll()
        {
            List<Bug> bugs = (List<Bug>)BugDataAccess.GetAll();
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
                bug.Validate();
                BugDataAccess.Create(bug);
            }
        }

        public List<ImporterInfo> GetCustomImportersInfo(ICustomBugImporter importerManager = null)
        {
            // This is to allow the tests to include their own mock custom importer
            if (importerManager == null)
                importerManager = new CustomBugImporterManager();
            List<ImporterInfo> importersInfo = importerManager.GetAvailableImportersInfo();
            return importersInfo;

        }

        public void ImportBugsCustom(string importerName, List<Parameter> parameters, ICustomBugImporter importerManager = null)
        {
            // This is to allow the tests to include their own mock custom importer
            if (importerManager == null)
                importerManager = new CustomBugImporterManager();

            List<ImportedBug> bugsToImport = importerManager.ImportBugs(importerName, parameters);
            foreach (var importedBug in bugsToImport)
            {
                Bug convertedBug = convertImportedBugToBug(importedBug);
                convertedBug.Validate();
                BugDataAccess.Create(convertedBug);
            }

        }

        private Bug convertImportedBugToBug(ImportedBug importedBug)
        {
            return new Bug()
            {
                Name = importedBug.Name,
                Description = importedBug.Description,
                Version = importedBug.Version,
                CompletedById = importedBug.CompletedById,
                IsActive = importedBug.IsActive,
                ProjectId = importedBug.ProjectId,
                ProjectName = importedBug.ProjectName,
                Time = importedBug.Time
            };
        }
    }


}