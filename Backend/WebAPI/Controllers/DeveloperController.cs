using BusinessLogicInterfaces;
using Domain;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Filters;

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

        [AuthorizationFilter("Admin")]
        [HttpPost]
        public object Post([FromBody] DeveloperDTO devExpected)
        {
            return Ok(businessLogic.Add(devExpected));
        }

        [AuthorizationFilter("Admin")]
        [HttpGet("{id}/bugs/quantity")]
        public object GetQuantityBugsResolved([FromRoute] int idDev)
        {

            return Ok(new BugsQuantity(businessLogic.GetQuantityBugsResolved(idDev)));
        }

        public object GetAllDevs()
        {
            return Ok(businessLogic.GetAllDevs());

        }
    }
}