using BusinessLogic;
using BusinessLogicInterfaces;
using Domain;
using Domain.Utils;
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

        public void SaveLogin(LoginToken loginToken)
        {
            context.Add(loginToken);
            context.SaveChanges();
        }

        public string VerifyUser(string username, string password)
        {
            string role = null;
            if(context.Admins.Any(u => u.Username == username && u.Password == password))
            {
                role = Roles.Admin;
            }else if(context.Developer.Any(u => u.Username == username && u.Password == password))
            {
                role = Roles.Dev;
            }else if(context.Tester.Any(u => u.Username == username && u.Password == password))
            {
                role = Roles.Tester;
            }
            return role;
        }


    }
}
