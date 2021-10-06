using BusinessLogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("testers")]
    public class TesterController : ControllerBase
    {
        private readonly ITesterBusinessLogic businessLogic;

        public TesterController(ITesterBusinessLogic newTesterBusinessLogic)
        {
            businessLogic = newTesterBusinessLogic;
        }

        [HttpPost]
        public object Post([FromBody] Tester testerExpected)
        {
            return Ok(businessLogic.Add(testerExpected));
        }

    }
}