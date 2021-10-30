using BusinessLogicInterfaces;
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
            project.Validate();
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
            projectModified.Validate();
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
            projectModified.Validate();
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
            return projectDataAccess.RemoveDeveloperFromProject(idproject, idDev);

        }

        public ResponseMessage RemoveTesterFromProject(int idproject, int idTester)
        {
            return projectDataAccess.RemoveTesterFromProject(idproject, idTester);

        }

        public Developer AddDeveloperToProject(int idproject, int idDev)
        {
            return projectDataAccess.AddDeveloperToProject(idproject, idDev);

        }

        public Tester AddTesterToProject(int idproject, int idTester)
        {
            return projectDataAccess.AddTesterToProject(idproject, idTester);

        }

        public ProjectCost GetProjectCost(int id)
        {
            return projectDataAccess.GetProjectCost(id);
        }

        public ProjectDuration GetProjectDuration(int id)
        {
            return projectDataAccess.GetProjectDuration(id);
        }
    }
}