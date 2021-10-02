using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApi.Utils
{
    class BugComparer : IComparer
    {
        // TODO create model and put this function inside BugModel
        public int Compare(object x, object y)
        {
            Bug bugExpected = x as Bug;
            Bug bugReturned = x as Bug;

            bool equals = bugExpected.ID == bugReturned.ID &&
                        bugExpected.Description == bugReturned.Description &&
                        bugExpected.Name == bugReturned.Name &&
                        bugExpected.CompletedBy.Equals(bugReturned.CompletedBy) &&
                        bugExpected.IsActive == bugReturned.IsActive &&
                        bugExpected.Version == bugReturned.Version;

            return equals ? 0 : -1;
        }
    }
}
