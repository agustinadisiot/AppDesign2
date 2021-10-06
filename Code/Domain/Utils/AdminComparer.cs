using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils
{
    public class AdminComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Admin adminExpected = x as Admin;
            Admin adminReturned = y as Admin;

            bool equals = adminExpected.Name == adminReturned.Name &&
                        adminExpected.Lastname == adminReturned.Lastname &&
                        adminExpected.Password == adminReturned.Password &&
                        adminExpected.Email == adminReturned.Email;
            ;

            return equals ? 0 : -1;
        }
    }
}
