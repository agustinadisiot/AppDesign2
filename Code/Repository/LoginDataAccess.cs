using BusinessLogic;
using BusinessLogicInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Design;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class LoginDataAccess : ILoginDataAccess
    {
        private readonly BugManagerContext context;

        public LoginDataAccess(DbContext newContext)
        {
            context = (BugManagerContext)newContext;
        }

        public LoginToken Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void SaveLogin(LoginToken loginToken)
        {
            context.Add(loginToken);
            context.SaveChanges();
        }

        public bool VerifyUser(string username, string password)
        {
            bool verified = context.Admins.Any(u => u.Username == username && u.Password == password) ||
                            context.Developer.Any(u => u.Username == username && u.Password == password) ||
                            context.Tester.Any(u => u.Username == username && u.Password == password);
            return verified;
        }
    }
}
