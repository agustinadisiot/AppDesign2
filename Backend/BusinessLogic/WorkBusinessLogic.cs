using Domain;
using DTO;
using RepositoryInterfaces;
using System.Collections.Generic;

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

        public List<WorkDTO> GetAll(string token)
        {
            return WorkDataAccess.GetAll(token).ConvertAll(w => new WorkDTO(w));
        }
    }
}