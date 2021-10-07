using BusinessLogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet("{idTester}/bugs")]
        public object GetBugsByStatus([FromRoute]int idTester, [FromQuery]bool filter)
        {
            return Ok(businessLogic.GetBugsByStatus(idTester, filter));
        }

        [HttpGet("{idTester}/bugs")]
        public object GetBugsByName([FromRoute]int idTester, [FromQuery]string filter)
        {
            return Ok(businessLogic.GetBugsByName(idTester, filter));

        }

        [HttpGet("{idTester}/bugs")]
        public object GetBugsByProject([FromRoute]int idTester, [FromQuery]int filter)
        {
            return Ok(businessLogic.GetBugsByProject(idTester, filter));

        }
    }
}