using BusinessLogicInterfaces;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface BusinessLogic<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        T Add(T t);
        T Update(int Id, T t);
        ResponseMessage Delete(int Id);
    }
}
