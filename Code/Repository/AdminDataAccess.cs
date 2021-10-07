using Domain;
using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;

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
            context.Add(admin);
            context.SaveChanges();

            return admin;
        }
    }
}
