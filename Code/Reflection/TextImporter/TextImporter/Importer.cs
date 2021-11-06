using CustomBugImportation;
using System;
using System.Collections.Generic;

namespace TextImporter
{
    public class Importer : IBugImporter
    {
        private ImporterInfo info;
        private const string fileExtension = ".txt";
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

            string fullPath = GetFilePath(parameters);
            List<ImportedBug> bugs = ImportBugsFromPath(fullPath);
            return bugs;

        }

        private string GetFilePath(List<Parameter> parameters)
        {
            string path = parameters.Find(p => p.Name == "Folder path").Value;
            string fileNameText = parameters.Find(p => p.Name == "File Name").Value;

            int fileName;
            bool parsed = Int32.TryParse(fileNameText, out fileName);
            if (!parsed)
                throw new CustomImporterException("File Name must be an integer");

            string fullPath = path + fileName + fileExtension;
            return fullPath;
        }

        private List<ImportedBug> ImportBugsFromPath(string fullPath)
        {
            string[] lines;
            try
            {
                lines = System.IO.File.ReadAllLines(fullPath);
            }
            catch (Exception)
            {
                throw new CustomImporterException("Error reading file");
            }

            List<ImportedBug> bugs;
            try
            {
                bugs = ImportBugsFromLines(lines);
            }
            catch (Exception)
            {
                throw new CustomImporterException("Error importing bugs");
            }

            return bugs;
        }

        private List<ImportedBug> ImportBugsFromLines(string[] lines)
        {
            List<ImportedBug> bugs = new List<ImportedBug>();
            foreach (string line in lines)
            {
                bugs.Add(new ImportedBug()
                {
                    ProjectName = line.Substring(0, 30).Trim(),
                    Name = line.Substring(34, 60).Trim(),
                    Description = line.Substring(94, 150).Trim(),
                    Version = line.Substring(244, 10).Trim(),
                    IsActive = (line[254].ToString()) == "1",
                    Time = Int32.Parse(line.Substring(255, 4).Trim()),
                });
            }
            return bugs;
        }
    }
}
