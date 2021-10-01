﻿using System.Collections.Generic;

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
