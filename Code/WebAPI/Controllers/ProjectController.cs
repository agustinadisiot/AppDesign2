using BusinessLogicInterfaces;
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
        public object GetByName([FromBody] string name)
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

        [HttpGet("{id}/devs")]
        public object GetDevelopers([FromRoute] int id)
        {
            return Ok(businessLogic.GetDevelopers(id));
        }

        [HttpGet("{id}/testers")]
        public object GetTesters([FromRoute] int id)
        {
            return Ok(businessLogic.GetTesters(id));
        }

        [HttpDelete("{idProject}/devs/{idDev}")]
        public object RemoveDeveloperFromProject(int idProject, int idDev)
        {
            return Ok(businessLogic.RemoveDeveloperFromProject(idProject, idDev));
        }

        [HttpDelete("{idProject}/testers/{idTester}")]

        public object RemoveTesterFromProject(int idProject, int idTester)
        {
            return Ok(businessLogic.RemoveTesterFromProject(idProject, idTester));
        }

        [HttpPost("{idProject}/devs/{idDev}")]

        public object AddDeveloperToProject(int idProject, int idDev)
        {
            return Ok(businessLogic.AddDeveloperToProject(idProject, idDev));
        }

        [HttpPost("{idProject}/testers/{idTester}")]

        public object AddTesterToProject(int idProject, int idTester)
        {
            return Ok(businessLogic.AddTesterToProject(idProject, idTester));
        }

        /*        [HttpPost("{id}/bugs")] TODO borrar
                public object Post([FromRoute] int id, [FromBody] Bug bugExpected)
                {
                    return Ok(businessLogic.AddBug(id, bugExpected));
                }*/
    }
}