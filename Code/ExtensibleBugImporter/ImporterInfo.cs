using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibleBugImporter
{
    public struct ImporterInfo
    {
        public string ImporterName { get; set; }
        public List<Parameter> Params { get; set; }
    }
}
