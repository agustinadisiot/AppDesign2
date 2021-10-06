using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugParser
{
    public class ParserFactory : IParserFactory
    {
        public IBugParser GetBugParser(ImportCompany format)
        {
            throw new NotImplementedException();
        }

    }
}
