﻿using BusinessLogicInterfaces;
using Domain;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class ProjectBusinessLogic : IProjectBusinessLogic
    {
        public IProjectDataAccess projectDataAccess { get; set; }

        public ProjectBusinessLogic(IProjectDataAccess newProjectDataAccess)
        {
            projectDataAccess = newProjectDataAccess;
        }

        public Project Add(Project project)
        {
            return projectDataAccess.Create(project);
        }

        public ResponseMessage Delete(int Id)
        {
            return projectDataAccess.Delete(Id);
        }

        public IEnumerable<Project> GetAll()
        {
            return projectDataAccess.GetAll();
        }

        public Project GetById(int Id)
        {
            return projectDataAccess.GetById(Id);
        }

        public Project Update(int Id, Project projectModified)
        {
            return projectDataAccess.Update(Id, projectModified);
        }

        public ResponseMessage DeleteByName(string nameProject)
        {
            return projectDataAccess.DeleteByName(nameProject);
        }

        public Project GetByName(string nameProject)
        {
            return projectDataAccess.GetByName(nameProject);
        }

        public Project UpdateByName(string nameProjectToUpdate, Project projectModified)
        {
            return projectDataAccess.UpdateByName(nameProjectToUpdate, projectModified);
        }

        public List<Bug> GetBugs(int id)
        {
            return projectDataAccess.GetBugs(id);
        }

        public BugsQuantity GetBugsQuantity(int idProject)
        {
            return projectDataAccess.GetBugsQuantity(idProject);
        }

        public List<Developer> GetDevelopers(int id)
        {
            return projectDataAccess.GetDevelopers(id);
        }

        public List<Tester> GetTesters(int id)
        {
            return projectDataAccess.GetTesters(id);
        }

        public ResponseMessage RemoveDeveloperFromProject(int idproject, int idDev)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage RemoveTesterFromProject(int idproject, int idTester)
        {
            throw new NotImplementedException();
        }

        public Developer AddDeveloperToProject(int idproject, int idDev)
        {
            throw new NotImplementedException();
        }

        public Tester AddTesterToProject(int idproject, int idTester)
        {
            throw new NotImplementedException();
        }
    }
}