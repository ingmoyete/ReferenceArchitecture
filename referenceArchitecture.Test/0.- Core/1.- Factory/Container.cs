using referenceArchitecture.Core.Cache;
using referenceArchitecture.Core.Helpers;
using referenceArchitecture.Core.Logger;
using referenceArchitecture.Core.Resources;
using referenceArchitecture.repository._0.__Edmx;
using referenceArchitecture.repository.Edmx.Interfaces;
using referenceArchitecture.repository.ExampleRepository;
using referenceArchitecture.service.ExampleService;
using referenceArchitecture.ui.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace referenceArchitecture.Test.Core.Factory
{
    /// <summary>
    /// Class that contains methods to create instances of implementations. 
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Create a instance of the IResource implementation.
        /// </summary>
        /// <returns>An insance of IResource.</returns>
        public static IResource createIResource()
        {
            return new ResourceCsvService(createICache(), createILogger(), createHp()); 
        }

        /// <summary>
        /// Create an instante of the ICache implementation.
        /// </summary>
        /// <returns>An instance of ICache.</returns>
        public static ICache createICache()
        {
            return new CacheService(createHp());
        }

        /// <summary>
        /// Create an instante of the ILogger implementation.
        /// </summary>
        /// <returns>An instance of ILogger.</returns>
        public static ILogger createILogger()
        {
            return new LoggerService(createHp());
        }

        /// <summary>
        /// Create an instance of the Ihp implementation.
        /// </summary>
        /// <returns>An instance of Ihp.</returns>
        public static Ihp createHp()
        {
            return new hp();
        }

        /// <summary>
        /// Create an instance of the IExampleRepository.
        /// </summary>
        /// <returns>an instance of the IExampleRepository.</returns>
        public static IExampleRepository createIExampleRepository()
        {
            return new ExampleRepository();
        }

        /// <summary>
        /// Create an instance of the IDbContext.
        /// </summary>
        /// <returns>instance of the IDbContext.</returns>
        public static IDbContext createIDbContext()
        {
            return new ExampleDB();
        }

        /// <summary>
        /// Create instance of the IExampleService.
        /// </summary>
        /// <returns>instance of the IExampleService.</returns>
        public static IExampleService createIExampleService()
        {
            return new ExampleService(createIExampleRepository(), createIDbContext());
        }

        /// <summary>
        /// Create instance of the HomeController.
        /// </summary>
        /// <returns></returns>
        public static HomeController createHomeController()
        {
            return new HomeController(createIExampleService());
        }

    }
}
