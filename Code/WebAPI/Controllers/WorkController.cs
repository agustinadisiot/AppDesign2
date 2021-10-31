using BusinessLogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("works")]
    public class WorkController : ControllerBase
    {
        private readonly IWorkBusinessLogic businessLogic;

        public WorkController(IWorkBusinessLogic newbusinessLogic)
        {
            businessLogic = newbusinessLogic;
        }

        [HttpPost]
        public object Post(Work workExpected)
        {
            return Ok(businessLogic.Add(workExpected));

        }

        [HttpGet("{id}")]
        public object Get([FromRoute] int id)
        {
            return Ok(businessLogic.GetById(id));
        }
    }
}