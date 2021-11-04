using System.Collections.Generic;

namespace DTO
{
    public class DeveloperDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<ProjectDTO> ProjectsDTO { get; set; }
        public int Cost { get; set; }
    }
}