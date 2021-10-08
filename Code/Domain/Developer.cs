using System.Collections.Generic;

namespace Domain
{
    public class Developer : User
    {
        public List<Project> Projects { get; set; }
        public Developer()
        {
            Projects = new List<Project>();
        }
    }
}