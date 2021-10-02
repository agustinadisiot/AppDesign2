using System.Collections.Generic;

namespace Domain
{
    public class Project
    {
        public string Name { get; set; }
        public List<Tester> Testers { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Bug> Bugs { get; set; }
        public int Id { get; set; }

        public Project()
        {
            Testers = new List<Tester>();
            Developers = new List<Developer>();
            Bugs = new List<Bug>();
        }

        public override bool Equals(object obj)
        {
            Project project = (Project)obj;
            return (project.Id == this.Id) && (project.Name == this.Name);
        }
    }
}