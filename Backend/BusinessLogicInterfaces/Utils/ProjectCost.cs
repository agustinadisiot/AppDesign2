namespace BusinessLogicInterfaces
{
    public class ProjectCost
    {

        public ProjectCost(int expectedCost)
        {
            Cost = expectedCost;
        }

        public int Cost { get; set; }
    }
}