﻿using Domain;
using System;
using BusinessLogicInterfaces;
using System.Collections.Generic;
using System.Linq;
using RepositoryInterfaces;

namespace BusinessLogic
{
    public class BugBusinessLogic : IBugBusinessLogic
    {
        public IBugDataAccess bugDataAccess { get; set; }

        public BugBusinessLogic(IBugDataAccess newbugDataAccess)
        {
            bugDataAccess = newbugDataAccess;
        }

        public Bug GetById(int idBug)
        {
            Bug bug = bugDataAccess.GetById(idBug);
            return bug;
        }

        public IEnumerable<Bug> GetAll()
        {
            return bugDataAccess.GetAll();
        }

        public Bug Add(Bug bug)
        {
            bugDataAccess.Create(bug);
            return bug;
        }

        public Bug Update(int Id, Bug bug)
        {
            return bugDataAccess.Update(Id, bug);
        }


        public ResponseMessage Delete(int Id)
        {
            return bugDataAccess.Delete(Id);

        }
    }


}