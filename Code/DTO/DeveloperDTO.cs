using Domain;
using System;
using System.Collections.Generic;

namespace DTO
{
    public class DeveloperDTO
    {
        private Developer dev;

        public DeveloperDTO()
        {
            ProjectsDTO = new List<ProjectDTO>();
        }

        public DeveloperDTO(Developer dev)
        {
            Id = dev.Id;
            Username = dev.Username;
            Name = dev.Name;
            Lastname = dev.Lastname;
            Password = dev.Password;
            Email = dev.Email;
            Cost = dev.Cost;
            ProjectsDTO = ConvertProjects(dev.Projects);
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<ProjectDTO> ProjectsDTO { get; set; }
        public int Cost { get; set; }

        public Developer ConvertToDomain()
        {
            Developer dev = new Developer()
            {
                Id = this.Id,
                Username = this.Username,
                Name = this.Name,
                Cost = this.Cost,
                Email = this.Email,
                Lastname = this.Lastname,
                Password = this.Password,
                Projects = this.ProjectsDTO.ConvertAll(p => p.ConvertToDomain())
            };
            return dev;
        }

        private List<ProjectDTO> ConvertProjects(List<Project> projects)
        {
            List<ProjectDTO> projectsDTO = new List<ProjectDTO>();
            foreach (Project proj in projects)
            {
                projectsDTO.Add(new ProjectDTO(proj));
            }
            return projectsDTO;
        }
    }
}