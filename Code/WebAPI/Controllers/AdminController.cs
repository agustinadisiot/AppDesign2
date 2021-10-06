using BusinessLogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("admins")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBusinessLogic businessLogic;

        public AdminController(IAdminBusinessLogic newProjectBusinessLogic)
        {
            businessLogic = newProjectBusinessLogic;
        }

        [HttpPost]
        public object Post([FromBody] Admin projectExpected)
        {
            return Ok(businessLogic.Add(projectExpected));
        }

    }
}