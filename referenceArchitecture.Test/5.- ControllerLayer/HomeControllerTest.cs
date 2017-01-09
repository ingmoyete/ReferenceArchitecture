using Microsoft.VisualStudio.TestTools.UnitTesting;
using referenceArchitecture.Core.DTO;
using referenceArchitecture.service.ExampleService;
using referenceArchitecture.Test.Core.ADO;
using referenceArchitecture.Test.Core.Factory;
using referenceArchitecture.ui.Controllers;
using referenceArchitecture.ui.Core.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace referenceArchitecture.Test.Controller
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestInitialize]
        public void Initialize()
        {
            // Set here the unity container
        }

        [TestMethod]
        public void ListUsers_return_allValues_and_partialView()
        {
            // Arrange
            var exampleService = Container.createIExampleService();
            var homeController = new HomeController(Container.createIExampleService());

            // Acts
            var view = homeController.ListUsers() as PartialViewResult; // View
            var count = exampleService.getAllUsers().Count; // Number of records

            // Assert
            Assert.AreEqual("PartialListUsers", view.ViewName, "No se devuelve la view PartialListUsers");
            Assert.IsTrue(count > 0, "No se devuelven usuarios");

        }

        [TestMethod]
        public void Users_insert_value_and_make_Redirect()
        {
            Stopwatch timer = new Stopwatch();

            var dtoExample = new DTOExample
            {
                FirstField = new Random().Next(1, 500).ToString(),
                SecondField = new Random().Next(1, 500),
                ThirdField = DateTime.Parse("2016-10-22 11:21:10.323")
            };
            
            DTOExample recordInDb = null;

            try
            {
                // Arrange
                var exampleService = Container.createIExampleService();
                var homeController = new HomeController(Container.createIExampleService());

                // Acts
                var actionResult = homeController.Users(dtoExample) as RedirectToRouteResult; // Redirect
                timer.Start();
                recordInDb = exampleService.getDTOExample(dtoExample); // Get inserted record from db
                timer.Stop();

                // Assert
                Assert.AreEqual("Users", actionResult.RouteValues["action"], "No se redirecciona a Users");
                Assert.IsTrue
                (
                    recordInDb.FirstField == dtoExample.FirstField
                    && recordInDb.SecondField == dtoExample.SecondField
                    && recordInDb.ThirdField == dtoExample.ThirdField,
                    "No se encuentra en DB el valor insertado"
                );

                Assert.IsTrue(timer.ElapsedMilliseconds < 1000, "Query is to slow.");

            }
            finally
            {
                // Remove record just created 
                using (var context = Container.createIDbContext())
                {
                    var example = context.Examples.Where(x => x.ID == recordInDb.Identificator).FirstOrDefault();
                    context.Examples.Remove(example);
                    context.SaveChanges();
                }
            }

        }
        
    }
}
