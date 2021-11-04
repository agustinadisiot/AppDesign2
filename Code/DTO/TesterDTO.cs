using DTO;
using System.Collections.Generic;

namespace TDO
{
    public class TesterDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Cost { get; set; }
        public List<ProjectDTO> ProjectsDTO { get; set; }
    }
}