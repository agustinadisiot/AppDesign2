using Domain;
using Domain.Utils;
using System.Collections.Generic;

namespace BusinessLogicInterfaces
{
    public interface IBugBusinessLogic : IBusinessLogic<Bug>
    {
        List<Bug> ImportBugs(string path, ImportCompany xML);
    }
}