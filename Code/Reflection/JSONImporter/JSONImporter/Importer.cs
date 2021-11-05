using CustomBugImportation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JSONImporter
{
    public class Importer : IBugImporter
    {
        public ImporterInfo GetImporterInfo()
        {
            throw new NotImplementedException();
        }

        public List<ImportedBug> ImportBugs(List<Parameter> parameters)
        {
            string fileName = parameters.Find(p => p.Name == "path").Value;
            string jsonString = File.ReadAllText(fileName);
            var importedBugs = JsonSerializer.Deserialize<List<ImportedBug>>(jsonString);
            return importedBugs;
        }
    }
}
