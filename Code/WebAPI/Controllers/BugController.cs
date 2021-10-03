using BusinessLogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public object Update([FromRoute]int id, [FromBody]Bug bugModified)
        {
            return Ok(businessLogic.Update(id, bugModified));
        }

        [HttpDelete("{id}")]
        public object Delete([FromRoute] int id)
        {
            return Ok(businessLogic.Delete(id));
        }
    }
}
