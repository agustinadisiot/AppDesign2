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
    }
}
