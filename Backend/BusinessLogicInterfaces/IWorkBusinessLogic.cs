using Domain;
using DTO;
using System.Collections.Generic;

namespace BusinessLogicInterfaces
{
    public interface IWorkBusinessLogic : IBusinessLogic<Work>
    {
        IEnumerable<WorkDTO> GetAll(string token);
        WorkDTO Add(WorkDTO t);
    }
}