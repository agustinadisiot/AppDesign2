using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugParser
{
    public interface IBugParser
    {
        List<Bug> GetBugs(string fullPath);
    }
}