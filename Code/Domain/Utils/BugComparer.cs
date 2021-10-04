using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils
{
    public class BugComparer : IComparer
    {
        // TODO create model and put this function inside BugModel 
        public int Compare(object x, object y)
        {
            Bug bugExpected = x as Bug;
            Bug bugReturned = x as Bug;

            bool equals = bugExpected.Id == bugReturned.Id &&
                        bugExpected.Description == bugReturned.Description &&
                        bugExpected.Name == bugReturned.Name &&
                        bugExpected.IsActive == bugReturned.IsActive &&
                        bugExpected.Version == bugReturned.Version &&
                        ((bugExpected.CompletedBy == null && bugReturned.CompletedBy == null) ||
                        (bugExpected.Equals(bugReturned)));
            ;

            return equals ? 0 : -1;
        }
    }
}
