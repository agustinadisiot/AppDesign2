
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
        T GetById(int Id);

        T Update(int Id, T t);
        ResponseMessage Delete(int Id);
    }
}
