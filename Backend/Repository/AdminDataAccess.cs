using Domain;
using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;

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
