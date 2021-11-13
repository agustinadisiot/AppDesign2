using BugParser;
using CustomBugImportation;
using CustomBugImporter;
using Domain;
using Domain.Utils;
using DTO;
using System.Collections.Generic;

namespace BusinessLogicInterfaces
{
    public interface IBugBusinessLogic
    {
        IEnumerable<BugDTO> GetAll();
        BugDTO Add(BugDTO bugdto);
        BugDTO Update(int Id, BugDTO t);
        ResponseMessage Delete(int Id);
        BugDTO GetById(int Id);
        void ImportBugs(string path, ImportCompany format, IParserFactory factory = null);

        List<ImporterInfo> GetCustomImportersInfo(ICustomBugImporter importerManager = null);
        void ImportBugsCustom(string importerName, List<Parameter> parameters, ICustomBugImporter importerManager = null);
    }
}