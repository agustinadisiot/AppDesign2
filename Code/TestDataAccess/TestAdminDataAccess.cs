using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Domain;
using Domain.Utils;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using RepositoryInterfaces;

namespace TestDataAccess
{
    [TestClass]
    public class TestAdminDataAccess : TestUserDataAccess<Admin>
    {
        public TestAdminDataAccess() : base()
        {
            userDataAccess = new AdminDataAccess(bugManagerContext);
            user = new Admin();
            users = bugManagerContext.Admins;
            userDifferentRole = new Tester();
            role = Roles.Admin;
        }

    }
}
