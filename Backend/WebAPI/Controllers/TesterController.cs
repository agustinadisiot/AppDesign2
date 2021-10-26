using BusinessLogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Filters;

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

        [HttpGet("{idTester}/bugs/status/{filter}")]
        public object GetBugsByStatus([FromRoute] int idTester, [FromRoute] bool filter)
        {
            return Ok(businessLogic.GetBugsByStatus(idTester, filter));
        }

        [HttpGet("{idTester}/bugs/name/{filter}")]
        public object GetBugsByName([FromRoute] int idTester, [FromRoute] string filter)
        {
            return Ok(businessLogic.GetBugsByName(idTester, filter));

        }

        [HttpGet("{idTester}/bugs/project/{filter}")]
        public object GetBugsByProject([FromRoute] int idTester, [FromRoute] int filter)
        {
            return Ok(businessLogic.GetBugsByProject(idTester, filter));

        }
    }
}