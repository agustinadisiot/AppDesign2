using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibleBugImporter
{
    public interface IBugImporter
    {
        public ImporterInfo GetImporterInfo();

        public List<ImportedBug> ImportBugs(List<Parameter> parameters);
    }
}
