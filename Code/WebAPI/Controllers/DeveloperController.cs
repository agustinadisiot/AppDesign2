using BusinessLogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("devs")]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperBusinessLogic businessLogic;

        public DeveloperController(IDeveloperBusinessLogic newDeveloperBusinessLogic)
        {
            businessLogic = newDeveloperBusinessLogic;
        }

        [HttpPost]
        public object Post([FromBody] Developer devExpected)
        {
            return Ok(businessLogic.Add(devExpected));
        }

        [HttpGet("{id}/bugs/quantity")]
        public object GetQuantityBugsResolved([FromRoute] int idDev)
        {

            return Ok(new BugsQuantity(businessLogic.GetQuantityBugsResolved(idDev)));
        }
    }
}