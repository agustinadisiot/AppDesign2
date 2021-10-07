using BusinessLogicInterfaces;
using Domain;
using System.Collections.Generic;

namespace RepositoryInterfaces
{
    public interface IBugDataAccess
    {
        public Bug Create(Bug bug);
        public Bug GetById(int id);

        public IEnumerable<Bug> GetAll();

        public Bug Update(int id, Bug bugUpdated);

        ResponseMessage Delete(int id);
    }
}
