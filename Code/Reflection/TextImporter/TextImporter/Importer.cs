using CustomBugImportation;
using System;
using System.Collections.Generic;

namespace TextImporter
{
    public class Importer : IBugImporter
    {
        public ImporterInfo GetImporterInfo()
        {
            throw new NotImplementedException();
        }

        public List<ImportedBug> ImportBugs(List<Parameter> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
