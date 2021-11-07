
using System.Collections.Generic;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
