namespace CustomBugImportation
{
    public class ImportedBug
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public bool IsActive { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int? CompletedById { get; set; }
        public int Time { get; set; }
    }
}
