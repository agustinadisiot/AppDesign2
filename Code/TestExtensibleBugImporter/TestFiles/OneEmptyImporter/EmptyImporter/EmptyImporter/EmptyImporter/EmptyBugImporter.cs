using System;
using Domain;
using ExtensibleBugImporter;

namespace EmptyImporter
{
    public class EmptyBugImporter : IBugImporter
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
