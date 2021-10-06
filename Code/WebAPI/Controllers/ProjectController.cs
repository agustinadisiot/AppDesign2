﻿using BusinessLogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectBusinessLogic businessLogic;

        public ProjectController(IProjectBusinessLogic newProjectBusinessLogic)
        {
            businessLogic = newProjectBusinessLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(businessLogic.GetAll());
        }

        [HttpPost]
        public object Post([FromBody] Project projectExpected)
        {
            return Ok(businessLogic.Add(projectExpected));
        }

        [HttpGet("{id}")]
        public object Get([FromRoute] int id)
        {
            return Ok(businessLogic.GetById(id));
        }

        [HttpGet("{name}")]
        public object GetByName([FromRoute] string name)
        {
            return Ok(businessLogic.GetByName(name));
        }

        [HttpPut("{id}")]
        public object Update([FromRoute] int id, [FromBody] Project projectModified)
        {
            return Ok(businessLogic.Update(id, projectModified));
        }

        [HttpDelete("{id}")]
        public object Delete([FromRoute] int id)
        {
            return Ok(businessLogic.Delete(id));
        }

        [HttpGet("{id}/bugs")]
        public object GetBugs([FromRoute] int id)
        {
            return Ok(businessLogic.GetBugs(id));
        }

        [HttpGet("{id}/bugs/quantity")]
        public object GetBugsQuantity([FromRoute]int id)
        {
            return Ok(businessLogic.GetBugsQuantity(id));
        }

        /*        [HttpPost("{id}/bugs")] TODO borrar
                public object Post([FromRoute] int id, [FromBody] Bug bugExpected)
                {
                    return Ok(businessLogic.AddBug(id, bugExpected));
                }*/
    }
}