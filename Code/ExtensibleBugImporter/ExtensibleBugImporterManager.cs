using System;
using System.Collections.Generic;

namespace ExtensibleBugImporter
{
    public class ExtensibleBugImporterManager
    {
        const string defaultPath = ""; // TODO define folder for custom importers

        // Path parameter is only for testing, defaultPath is use in production
        public List<ImporterInfo> GetAvailableImporters(string path = defaultPath)
        {
            throw new NotImplementedException();
        }
    }
}
