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
    public class AdminDataAccess : UserDataAccess<Admin>, IAdminDataAccess
    {

        public AdminDataAccess(DbContext newContext) : base(newContext)
        {
            users = context.Set<Admin>();
        }
    }
}
