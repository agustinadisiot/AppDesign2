using CustomBugImportation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
namespace ExtensibleBugImporter
{
    public class ExtensibleBugImporterManager
    {
        const string defaultPath = ""; // TODO define folder for custom importers

        // Path parameter is only for testing, defaultPath is use in production
        public List<ImporterInfo> GetAvailableImporters(string path = defaultPath)
        {
            List<ImporterInfo> importerInfos = new List<ImporterInfo>();

            string[] filePaths = Directory.GetFiles(path);
            foreach (string filePath in filePaths)
            {
                FileInfo dllFile = new FileInfo(filePath);
                Assembly assembly = Assembly.LoadFile(dllFile.FullName);
                foreach (Type type in assembly.GetTypes())
                {
                    try
                    {
                        if (typeof(IBugImporter).IsAssignableFrom(type))
                        {
                            IBugImporter provider = (IBugImporter)Activator.CreateInstance(type);
                            importerInfos.Add(provider.GetImporterInfo());
                        }

                    }
                    catch (Exception e)
                    {
                        // TODO revise error handling
                        // example: when a importer doesn't compile?
                    }
                }
            }
            return importerInfos;
        }

        public List<ImportedBug> ImportBugs(string importerName, List<Parameter> parameters, string path = defaultPath)
        {
            List<ImportedBug> bugs = new List<ImportedBug>();

            string[] filePaths = Directory.GetFiles(path);
            foreach (string filePath in filePaths)
            {
                FileInfo dllFile = new FileInfo(filePath);
                Assembly assembly = Assembly.LoadFile(dllFile.FullName);
                foreach (Type type in assembly.GetTypes())
                {
                    try
                    {
                        if (typeof(IBugImporter).IsAssignableFrom(type))
                        {
                            IBugImporter provider = (IBugImporter)Activator.CreateInstance(type);
                            string actualImportName = provider.GetImporterInfo().ImporterName;
                            if (actualImportName == importerName)
                            {
                                bugs = provider.ImportBugs(parameters);
                                return bugs;
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        // TODO revise error handling
                        // example: when a importer doesn't compile?
                    }
                }
            }
            return bugs;
        }
    }
}
