using referenceArchitecture.service.Core.Base.BaseController.MVCWrapper;
using referenceArchitecture.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using referenceArchitecture.service.ExampleService;
using referenceArchitecture.Core.Exceptions;
using referenceArchitecture.ui.Core.Filters;
using referenceArchitecture.Core.Resources;
using referenceArchitecture.Core.Cache;
using DevTrends.MvcDonutCaching;

namespace referenceArchitecture.ui.Controllers
{
    [CustomHandleError(MensajeErrorActionResult = "Error occured in Home")]
    public class HomeController : BaseController
    {
        private IExampleService exampleService;
        public HomeController(IExampleService _exampleService)
        {
            this.exampleService = _exampleService;
            this.exampleService.register(this);
        }

        // GET: Get index page
        [HttpGet]
        [DonutOutputCache(CacheProfile = "htmlGlobalCache900")]
        public ActionResult Index()
        {
            return View();
        }
        
        // CHILDONLY: Get all users
        [ChildActionOnly]
        public ActionResult ListUsers()
        {
            return PartialView("PartialListUsers", exampleService.getAllUsers());
        }

        // GET: Get user form
        [HttpGet]
        [DonutOutputCache(CacheProfile = "htmlGlobalCache900")]
        public ActionResult Users()
        {
            return View("Users", new DTOExample { FirstField = "Nombre", SecondField = 15, ThirdField = DateTime.Now });
        }

        // POST: Insert user
        [HttpPost]
        [CheckModelState(GoToIfInvalidOnStart = "Users", GoToIfInvalidOnEnd = "Error")]
        public ActionResult Users(DTOExample model)
        {
            exampleService.insertarExample(model);
            return RedirectToAction("Users");
        }

        // GET: Error page
        [HttpGet]
        public ActionResult ErrorRedirect(string exceptionMessage)
        {
            ModelState.AddModelError("exceptionMessage", exceptionMessage);
            return View("Error");
        }
    }
}