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
        public Developer CompletedBy { get; set; }
        public int Id { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public Bug()
        {
            IsActive = true;
            CompletedBy = null;
        }

        public override bool Equals(object obj)
        {
            Bug bug = (Bug)obj;
            return bug.Id == this.Id;
        }

        // TODO validate
    }
}