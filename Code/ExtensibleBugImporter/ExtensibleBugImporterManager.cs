using CustomBugImportation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Domain; //TODO eliminar
namespace ExtensibleBugImporter
{
    public class ExtensibleBugImporterManager
    {
        const string defaultPath = ""; // TODO define folder for custom importers

        // Path parameter is only for testing, defaultPath is use in production
        public List<ImporterInfo> GetAvailableImporters(string path = defaultPath)
        {
            List<ImporterInfo> importerInfos = new List<ImporterInfo>();
            FileInfo dllFile = new FileInfo(path);
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
            return importerInfos;
        }
    }
}
