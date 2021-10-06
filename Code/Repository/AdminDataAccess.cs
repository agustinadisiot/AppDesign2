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
    public class AdminDataAccess : IAdminDataAccess
    {
        private readonly DbSet<Admin> admins;
        private readonly BugManagerContext context;

        public AdminDataAccess(DbContext newContext)
        {
            context = (BugManagerContext)newContext;
            admins = context.Set<Admin>();
        }

        public Admin Create(Admin admin)
        {

            if (admin is null)
            {
                // TODO
            }

            context.Add(admin);
            context.SaveChanges();

            return admin;
        }
    }
}
