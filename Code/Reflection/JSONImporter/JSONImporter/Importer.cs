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
            string jsonString = "";
            try
            {
                jsonString = File.ReadAllText(fileName);
            }
            catch (FileNotFoundException e)
            {
                throw new CustomImporterException("Error acceding File");
            }
            var importedBugs = new List<ImportedBug>();
            try
            {
                importedBugs = JsonSerializer.Deserialize<List<ImportedBug>>(jsonString);
            }
            catch (JsonException e)
            {
                throw new CustomImporterException("Error reading JSON");
            }
            return importedBugs;
        }
    }
}
