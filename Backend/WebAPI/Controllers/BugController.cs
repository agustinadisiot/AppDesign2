using BusinessLogicInterfaces;
using CustomBugImportation;
using Domain;
using Domain.Utils;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult GetAll([FromHeader] TokenIdDTO token) //shouldnt recieve parameters
        {
      /*      Object role;
            HttpContext.Items.TryGetValue("role", out role);
            Object Id;
            HttpContext.Items.TryGetValue("id", out Id);
            TokenIdDTO token = new TokenIdDTO() { Id = (int)Id, Role = (string)role };*/
            return Ok(businessLogic.GetAll(token));
        }

        [AuthorizationFilter("Admin/Tester")]
        [HttpPost]
        public object Post([FromBody] BugDTO bugExpected)
        {
            return Ok(businessLogic.Add(bugExpected));
        }

        [HttpGet("{id}")]
        public object Get([FromRoute] int id)
        {
            return Ok(businessLogic.GetById(id));
        }

        [HttpPut("{id}")]
        public object Update([FromRoute] int id, [FromBody] BugDTO bugModified)
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

        [AuthorizationFilter("Admin")]
        [HttpGet("custom-importers")]
        public object GetCustomImportersInfo()
        {
            List<ImporterInfo> info = businessLogic.GetCustomImportersInfo();
            return Ok(info);
        }
    }
}
