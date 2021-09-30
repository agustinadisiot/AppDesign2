using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class ProjectBusinessLogic : IBusinessLogic<Project>
    {
        public List<Project> Projects { get; set; }

        public Project Add(Project project)
        {
            Projects.Add(project);
            return project;
        }

        public void Delete(int Id)
        {
            Project project = Projects.FirstOrDefault(i => i.ID == Id);

            if (project is null)
            {
                throw new NonexistentProjectException();
            }

            Projects.Remove(project);
        }

        public IEnumerable<Project> GetAll()
        {
            return Projects;
        }

        public Project GetById(int Id)
        {
            Project project = Projects.FirstOrDefault((i) => i.ID == Id);
            if (project is null)
            {
                throw new NonexistentProjectException();
            }

            return project;
        }

        public void Update(int Id, Project projectModified)
        {
            Project project = Projects.FirstOrDefault(i => i.ID == Id);

            if (project is null)
            {
                throw new NonexistentBugException();
            }

            project.Name = projectModified.Name;
            project.Testers = projectModified.Testers;
            project.Developers = projectModified.Developers;
            project.Bugs = projectModified.Bugs;
        }

        public void DeleteByName(string nameProject)
        {
            Project project = Projects.FirstOrDefault(i => i.Name == nameProject);

            if (project is null)
            {
                throw new NonexistentProjectException();
            }

            Projects.Remove(project);
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
                throw new NonexistentBugException();
            }

            project.Name = projectModified.Name;
            project.Testers = projectModified.Testers;
            project.Developers = projectModified.Developers;
            project.Bugs = projectModified.Bugs;
        }
    }
}