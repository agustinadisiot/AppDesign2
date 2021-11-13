using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBugImporter
{
    public class ImporterManagerException : Exception
    {

        public ImporterManagerException(string message) : base(message) { }
    }
}
