using BusinessLogicInterfaces;
using Domain;
using Domain.Utils;
using DTO;
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

        public ProjectDTO Add(ProjectDTO projectDTO)
        {
            Project project = projectDTO.ConvertToDomain();
            project.Validate();
            return new ProjectDTO(projectDataAccess.Create(project));
        }

        public ResponseMessage Delete(int Id)
        {
            return projectDataAccess.Delete(Id);
        }

        public IEnumerable<ProjectDTO> GetAll(TokenIdDTO idRole)
        {
            List<Project> projects = (List<Project>)projectDataAccess.GetAll();
            if (idRole.Role == Roles.Dev)
            {
                List<Project> myProjects = projects.FindAll(p => p.Developers.Exists(d => d.Id == idRole.Id));
                return myProjects.ConvertAll(p => new ProjectDTO(p));
            }
            if (idRole.Role == Roles.Tester)
            {
                List<Project> myProjects = projects.FindAll(p => p.Testers.Exists(t => t.Id == idRole.Id));
                return myProjects.ConvertAll(p => new ProjectDTO(p));
            }
            return projects.ConvertAll(p => new ProjectDTO(p));
        }

        public ProjectDTO GetById(int Id)
        {
            return new ProjectDTO(projectDataAccess.GetById(Id));
        }

        public ProjectDTO Update(int Id, ProjectDTO projectModified)
        {
            Project project = projectModified.ConvertToDomain();
            project.Validate();
            return new ProjectDTO(projectDataAccess.Update(Id, project));
        }

        public ResponseMessage DeleteByName(string nameProject)
        {
            return projectDataAccess.DeleteByName(nameProject);
        }

        public ProjectDTO GetByName(string nameProject)
        {
            return new ProjectDTO(projectDataAccess.GetByName(nameProject));
        }

        public ProjectDTO UpdateByName(string nameProjectToUpdate, ProjectDTO projectModified)
        {
            Project project = projectModified.ConvertToDomain();
            project.Validate();
            return new ProjectDTO(projectDataAccess.UpdateByName(nameProjectToUpdate, project));
        }

        public List<BugDTO> GetBugs(int id)
        {
            return projectDataAccess.GetBugs(id).ConvertAll(b=>new BugDTO(b));
        }

        public BugsQuantity GetBugsQuantity(int idProject)
        {
            return projectDataAccess.GetBugsQuantity(idProject);
        }

        public List<DeveloperDTO> GetDevelopers(int id)
        {
            return projectDataAccess.GetDevelopers(id).ConvertAll(d=>new DeveloperDTO(d));
        }

        public List<TesterDTO> GetTesters(int id)
        {
            return projectDataAccess.GetTesters(id).ConvertAll(t=>new TesterDTO(t));
        }

        public ResponseMessage RemoveDeveloperFromProject(int idproject, int idDev)
        {
            return projectDataAccess.RemoveDeveloperFromProject(idproject, idDev);

        }

        public ResponseMessage RemoveTesterFromProject(int idproject, int idTester)
        {
            return projectDataAccess.RemoveTesterFromProject(idproject, idTester);

        }

        public DeveloperDTO AddDeveloperToProject(int idproject, int idDev)
        {
            return new DeveloperDTO(projectDataAccess.AddDeveloperToProject(idproject, idDev));

        }

        public TesterDTO AddTesterToProject(int idproject, int idTester)
        {
            return new TesterDTO(projectDataAccess.AddTesterToProject(idproject, idTester));

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