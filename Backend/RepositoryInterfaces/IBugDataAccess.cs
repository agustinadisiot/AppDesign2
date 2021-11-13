﻿using BusinessLogicInterfaces;
using Domain;
using System;
using System.Collections.Generic;

namespace RepositoryInterfaces
{
    public interface IBugDataAccess
    {
        public Bug Create(Bug bug);
        public Bug GetById(int id);

        public IEnumerable<Bug> GetAll(string token);

        public Bug Update(int id, Bug bugUpdated);

        ResponseMessage Delete(int id);
        Bug ResolveBug(int id);
        Bug UnresolveBug(int id);
    }
}
