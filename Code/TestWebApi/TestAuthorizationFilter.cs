using BusinessLogic;
using BusinessLogicInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace TestWebApi
{
    [TestClass]
    class TestAuthorizationFilter
    {
        [TestMethod]
        public void AdminAuthorization()
        {
            // SETUP
            string token = "asdfa";
            var logicMock = new Mock<IAdminBusinessLogic>(MockBehavior.Strict);
            logicMock.Setup(m => m.VerifyRole(token)).Returns(true);

            // Source guide: https://programmium.wordpress.com/2020/04/30/unit-testing-custom-authorization-filter-in-net-core/
            var httpContextMock = new Mock<HttpContext>(MockBehavior.Loose);
            httpContextMock.Setup(m => m.Request.Headers["token"]).Returns(token);
            httpContextMock.Setup(m => m.RequestServices.GetService(typeof(IAdminBusinessLogic))).Returns(logicMock.Object);
            ActionContext fakeActionContext = new ActionContext(httpContextMock.Object,
                                             new Microsoft.AspNetCore.Routing.RouteData(),
                                             new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
            AuthorizationFilterContext fakeAuthFilterContext =
            new AuthorizationFilterContext(fakeActionContext,
              new List<IFilterMetadata> { });

            var filter = new AuthorizationFilter("Admin");
            // ACT 
            filter.OnAuthorization(fakeAuthFilterContext);
            // VERIFY
            var result = (ContentResult)fakeAuthFilterContext.Result;
            int? code = result.StatusCode;
            Assert.AreEqual(403, code);
        }
    }
}
