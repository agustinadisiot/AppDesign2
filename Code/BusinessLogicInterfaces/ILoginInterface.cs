using BusinessLogicInterfaces.Utils;
using Domain;
    
namespace BusinessLogicInterfaces
{
    public interface ILoginBusinessLogic
    {

        public LoginToken Login(string username, string password);

    }
}

