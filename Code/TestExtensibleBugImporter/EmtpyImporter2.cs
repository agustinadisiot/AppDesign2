using System;
using System.Collections.Generic;
using CustomBugImportation;

namespace TestExtensibleBugImporter
{
    public class EmptyImporter2 : IBugImporter
    {
        public ImporterInfo GetImporterInfo()
        {
            return new ImporterInfo
            {
                ImporterName = "Empty Importer",
                Params = new List<Parameter> { }
            };
        }

        public List<ImportedBug> ImportBugs(List<Parameter> parameters)
        {
            return new List<ImportedBug> { };
        }
    }
}