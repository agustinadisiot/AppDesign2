using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Bug
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public bool IsActive { get; set; }
        public object CompletedBy { get; set; }
        public int ID { get; set; }
        public List<Project> Projects { get; set; }

        public Bug()
        {
            IsActive = true;
            CompletedBy = null;
        }

        public override bool Equals(object obj)
        {
            Bug bug = (Bug)obj;
            return bug.ID == this.ID;
        }
    }
}