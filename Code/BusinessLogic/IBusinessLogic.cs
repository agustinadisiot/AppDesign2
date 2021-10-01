<<<<<<< HEAD
﻿using System.Collections.Generic;
=======
﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 5d59545... Adds web api first tests. Stage red

namespace BusinessLogic
{
    public interface IBusinessLogic<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        T Add(T t);
        void Update(int Id, T t);
        void Delete(int Id);
    }
}
