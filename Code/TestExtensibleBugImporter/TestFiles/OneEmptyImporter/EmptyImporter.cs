using Domain;
using ExtensibleBugImporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingImporters
{
    public class EmptyImporter : IBugImporter
    {
        public ImporterInfo GetImporterInfo()
        {
            return new ImporterInfo
            {
                ImporterName = "Empty Importer",
                Params = new List<Parameter> { }
            };
        }

        public List<Bug> ImportBugs(List<Parameter> parameters)
        {
            return new List<Bug> { };
        }
    }
}
