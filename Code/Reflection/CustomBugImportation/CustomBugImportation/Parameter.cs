namespace CustomBugImportation
{
    public struct Parameter
    {
        public string Name { get; set; }
        public string ParameterType { get; set; }
    }

    public enum ParameterType
    {
        STRING = 0,
        INTEGER = 1,
    }
}
