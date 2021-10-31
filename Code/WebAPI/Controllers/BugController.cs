using BusinessLogicInterfaces;
using Domain;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("bugs")]
    public class BugController : ControllerBase
    {
        private readonly IBugBusinessLogic businessLogic;

        public BugController(IBugBusinessLogic newBusinessLogic)
        {
            businessLogic = newBusinessLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(businessLogic.GetAll());
        }

        [AuthorizationFilter("Admin/Tester")]
        [HttpPost]
        public object Post([FromBody] Bug bugExpected)
        {
            return Ok(businessLogic.Add(bugExpected));
        }

        [HttpGet("{id}")]
        public object Get([FromRoute] int id)
        {
            return Ok(businessLogic.GetById(id));
        }

        [HttpPut("{id}")]
        public object Update([FromRoute] int id, [FromBody] Bug bugModified)
        {
            return Ok(businessLogic.Update(id, bugModified));
        }

        [AuthorizationFilter("Admin/Tester")]
        [HttpDelete("{id}")]
        public object Delete([FromRoute] int id)
        {
            businessLogic.Delete(id);
            return NoContent();
        }

        [AuthorizationFilter("Admin")]
        [HttpPost("import/{format}")]
        public object ImportBugs([FromHeader] string path, [FromRoute] string format)
        {
            ImportCompany parsedFormat = (ImportCompany)Enum.Parse(typeof(ImportCompany), format, true);
            businessLogic.ImportBugs(path, parsedFormat);
            return Ok();
        }
    }
}
