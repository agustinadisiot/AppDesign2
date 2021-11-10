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
            if (format == ImportCompany.XML)
                return new BugParserXML();
            else
                throw new NotImplementedException("Bug parsers for this company not available");
        }

    }
}
