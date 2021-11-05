using CustomBugImportation;
using System;
using System.Collections.Generic;

namespace TextImporter
{
    public class Importer : IBugImporter
    {
        private ImporterInfo info;
        public Importer()
        {
            info = new ImporterInfo()
            {
                ImporterName = "Positional Text Importer",
                Params = new List<Parameter>
                {
                    new Parameter(){
                    Name = "Folder path",
                    Type = ParameterType.STRING,
                },
                new Parameter(){
                    Name = "File Name",
                    Type = ParameterType.INTEGER,
                }
                }
            };
        }
        public ImporterInfo GetImporterInfo()
        {
            return info;
        }

        public List<ImportedBug> ImportBugs(List<Parameter> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
