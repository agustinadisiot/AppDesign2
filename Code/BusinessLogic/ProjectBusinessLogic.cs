using BusinessLogicInterfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class ProjectBusinessLogic : IProjectBusinessLogic
    {
        public List<Project> Projects { get; set; }

        public ProjectBusinessLogic()
        {
            Projects = new List<Project>();
        }

        public Project Add(Project project)
        {
            Projects.Add(project);
            return project;
        }

        public ResponseMessage Delete(int Id)
        {
            Project project = Projects.FirstOrDefault(i => i.Id == Id);

            if (project is null)
            {
                throw new NonexistentProjectException();
            }

            Projects.Remove(project);
            return new ResponseMessage("Deleted successfully");
        }

        public IEnumerable<Project> GetAll()
        {
            return Projects;
        }

        public Project GetById(int Id)
        {
            Project project = Projects.FirstOrDefault((i) => i.Id == Id);
            if (project is null)
            {
                throw new NonexistentProjectException();
            }

            return project;
        }

        public Project Update(int Id, Project projectModified)
        {
            Project project = Projects.FirstOrDefault(i => i.Id == Id);

            if (project is null)
            {
                throw new NonexistentProjectException();
            }

            project.Name = projectModified.Name;
            project.Testers = projectModified.Testers;
            project.Developers = projectModified.Developers;
            project.Bugs = projectModified.Bugs;
            return project;
        }

        public ResponseMessage DeleteByName(string nameProject)
        {
            Project project = Projects.FirstOrDefault(i => i.Name == nameProject);

            if (project is null)
            {
                throw new NonexistentProjectException();
            }

            Projects.Remove(project);
            return new ResponseMessage("Deleted successfully");
        }

        public Project GetByName(string nameProject)
        {
            Project project = Projects.FirstOrDefault((i) => i.Name == nameProject);
            if (project is null)
            {
                throw new NonexistentProjectException();
            }

            return project;
        }

        public void UpdateByName(string nameProjectToUpdate, Project projectModified)
        {
            Project project = Projects.FirstOrDefault(i => i.Name == nameProjectToUpdate);

            if (project is null)
            {
                throw new NonexistentProjectException();
            }

            project.Name = projectModified.Name;
            project.Testers = projectModified.Testers;
            project.Developers = projectModified.Developers;
            project.Bugs = projectModified.Bugs;
        }
    }
}