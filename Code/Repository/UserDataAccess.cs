using Domain;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class UserDataAccess<T> where T : User
    {
        protected DbSet<T> users;
        protected readonly BugManagerContext context;

        protected UserDataAccess(DbContext newContext)
        {
            context = (BugManagerContext)newContext;
        }

        public T Create(T user)
        {

            if (user is null)
            {
                throw new NonexistentUserException();
            }

            context.Add(user);
            context.SaveChanges();

            return user;
        }
    }
}
