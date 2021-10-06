﻿using BusinessLogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("admins")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBusinessLogic businessLogic;

        public AdminController(IAdminBusinessLogic newAdminBusinessLogic)
        {
            businessLogic = newAdminBusinessLogic;
        }

        [HttpPost]
        public object Post([FromBody] Admin adminExpected)
        {
            return Ok(businessLogic.Add(adminExpected));
        }

    }
}