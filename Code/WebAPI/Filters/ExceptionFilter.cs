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

namespace WebApi.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode;

            string errorMesssage = context.Exception.Message;

            if (context.Exception is NonexistentBugException)
            {
                statusCode = 404;
            }
            else if (context.Exception is NonexistentProjectException)
            {
                statusCode = 404;
            }
            else if (context.Exception is NonexistentUserException)
            {
                statusCode = 404;
            }
            else if (context.Exception is AuthenticationException)
            {
                statusCode = 401;
                errorMesssage = "Incorrect password or username";
            }
            else
            {
                statusCode = 500;
            }

            ResponseMessage message = new ResponseMessage(errorMesssage);
            context.Result = new ObjectResult(message)
            {
                StatusCode = statusCode,
            };
        }
    }
}