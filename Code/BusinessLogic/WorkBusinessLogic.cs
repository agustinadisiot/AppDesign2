using Domain;
using RepositoryInterfaces;
using System;

namespace BusinessLogic
{
    public class WorkBusinessLogic
    {
        private IWorkDataAccess WorkDataAccess;

        public WorkBusinessLogic(IWorkDataAccess newWorkDataAccess)
        {
            WorkDataAccess = newWorkDataAccess;
        }

        public object Add(Work work)
        {
            work.Validate();
            WorkDataAccess.Create(work);
            return work;
        }

        public Work GetById(int id)
        {
            Work work = WorkDataAccess.GetById(id);
            return work;
        }
    }
}