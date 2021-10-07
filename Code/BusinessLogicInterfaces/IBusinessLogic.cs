
using System.Collections.Generic;

namespace BusinessLogicInterfaces
{
    public interface IBusinessLogic<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        T Add(T t);
        T Update(int Id, T t);
        ResponseMessage Delete(int Id);
    }
}
