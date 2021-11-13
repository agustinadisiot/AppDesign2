using BugParser;
using CustomBugImportation;
using Domain;
using Domain.Utils;
using DTO;
using System.Collections.Generic;

namespace BusinessLogicInterfaces
{
    public interface IBugBusinessLogic
    {
        IEnumerable<BugDTO> GetAll(string token);
        BugDTO Add(BugDTO bugdto);
        BugDTO Update(int Id, BugDTO t);
        ResponseMessage Delete(int Id);
        BugDTO GetById(int Id);
        List<ImporterInfo> GetCustomImportersInfo();

        void ImportBugs(string path, ImportCompany format, IParserFactory factory = null);
        BugDTO ResolveBug(int id, string token);
        BugDTO UnresolveBug(int id, string token);
    }
}