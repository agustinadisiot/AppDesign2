using BugParser;
using Domain;
using Domain.Utils;

namespace BusinessLogicInterfaces
{
    public interface IBugBusinessLogic : IBusinessLogic<Bug>
    {
        void ImportBugs(string path, ImportCompany format, IParserFactory factory = null);
    }
}