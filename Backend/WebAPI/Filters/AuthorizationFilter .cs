using BusinessLogic;
using BusinessLogicInterfaces;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Domain;

namespace WebApi.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private string arg;

        public AuthorizationFilter(string arguments)
        {
            arg = arguments;

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorize = false;
            string token = context.HttpContext.Request.Headers["token"];
            if (token == null)
            {
                NotLoggedRespond(context);
                return;
            }

            if (arg.Contains("Admin"))
            {
                var logic = context.HttpContext.RequestServices.GetService<IAdminBusinessLogic>();
                isAuthorize = isAuthorize || logic.VerifyRole(token);
            }
            if (arg.Contains("Developer"))
            {
                var logic = context.HttpContext.RequestServices.GetService<IDeveloperBusinessLogic>();
                isAuthorize = isAuthorize || logic.VerifyRole(token);
            }
            if (arg.Contains("Tester"))
            {
                var logic = context.HttpContext.RequestServices.GetService<ITesterBusinessLogic>();
                isAuthorize = isAuthorize || logic.VerifyRole(token);
            }

            if (!isAuthorize)
            {
                ResponseMessage message = new ResponseMessage("You aren't logued correctly.");
                context.Result = new ObjectResult(message)
                {
                    StatusCode = 403,
                };
            }

        }

        private void NotLoggedRespond(AuthorizationFilterContext context)
        {
            ResponseMessage message = new ResponseMessage("You aren't logged.");
            context.Result = new ObjectResult(message)
            {
                StatusCode = 401,
            };
        }
    }
};
