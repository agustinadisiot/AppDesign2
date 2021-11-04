namespace CustomBugImportation
{
    public struct Parameter
    {
        public string Name { get; set; }
        public string ParameterType { get; set; }

        // Only use for testing
        public override bool Equals(object obj)
        {
            if (!(obj is Parameter))
                return false;
            Parameter p = (Parameter)obj;
            return this.Name.Equals(p.Name) && this.ParameterType.Equals(p.ParameterType);
        }

    }

    public enum ParameterType
    {
        STRING = 0,
        INTEGER = 1,
    }
}
