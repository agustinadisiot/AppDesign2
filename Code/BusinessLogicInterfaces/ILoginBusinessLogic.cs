using BusinessLogicInterfaces.Utils;
    
namespace BusinessLogicInterfaces
{
    public interface ILoginBusinessLogic
    {
        public LoginToken Login(string username, string password);

    }
}

