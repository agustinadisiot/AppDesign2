using CustomBugImportation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBugImporter
{
    public interface  ICustomBugImporter
    {

        public List<ImportedBug> ImportBugs(string importerName, List<Parameter> parameters, string path);

        public List<ImporterInfo> GetAvailableImportersInfo(string path);
        }
}
