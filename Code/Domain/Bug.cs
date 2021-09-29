namespace Domain
{
    public class Bug
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public bool IsActive { get; set; }
        public object CompletedBy { get; set; }
        public Bug()
        {
            IsActive = true;
            CompletedBy = null;
        }
    }
}