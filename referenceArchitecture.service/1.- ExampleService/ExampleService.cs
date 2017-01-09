using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using referenceArchitecture.repository.ExampleRepository;
using referenceArchitecture.repository.Edmx.Interfaces;
using referenceArchitecture.Core.DTO;
using referenceArchitecture.Core.Exceptions;
using referenceArchitecture.Core.Base.BaseService;

namespace referenceArchitecture.service.ExampleService
{
    /// <summary>
    /// Example service.
    /// </summary>
    public class ExampleService : BaseService, IExampleService
    {
        // Example repository
        private IExampleRepository exampleRepository;

        // Database context
        private IDbContext dbContext;
        /// <summary>
        /// Constructor used to inject example repository.
        /// </summary>
        /// <param name="_exampleRepository">Example repository to be injected.</param>
        public ExampleService(IExampleRepository _exampleRepository, IDbContext _dbContext)
        {
            this.dbContext          = _dbContext;
            this.exampleRepository  = _exampleRepository;
        }
        
        /// <summary>
        /// Insert a DTOExample.
        /// </summary>
        /// <param name="example">DTOExample to insert.</param>
        public void insertarExample(DTOExample example)
        {
            using (dbContext)
            {
                // Exist method if record exist.
                if (DTOExampleExist(dbContext, example)) return;
                
                // Insert.
                exampleRepository.insertarExample(dbContext, example);

                // Save changes.
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>A collection of DTOExample with all users.</returns>
        public List<DTOExample> getAllUsers()
        {
            using (dbContext)
            {
                // Get all users.
                return exampleRepository.getAllUsers(dbContext);
            }
        }

        /// <summary>
        /// Get the DTOExample from DB.
        /// </summary>
        /// <param name="example">DTOExample to get from db</param>
        /// <returns>A DTOExample </returns>
        public DTOExample getDTOExample(DTOExample example)
        {
            using (dbContext)
            {
                return exampleRepository.getDTOExample(dbContext, example);
            }
        }

        /// <summary>
        /// Check if a DTOExample exist.
        /// </summary>
        /// <param name="context">Context of the database</param>
        /// <param name="example">This will be checked if it exists.</param>
        /// <returns>True if "example" exist en DB. Otherwise false.</returns>
        private bool DTOExampleExist(IDbContext context, DTOExample example)
        {
            // Get record.
            DTOExample record = exampleRepository.getDTOExample(context, example);

            // Add error if record does not exist.
            if (record != null) ControllerUI.ModelStateService.AddModelError(" ", "Record exist");

            // True if record exist, otherwise false.
            return record != null;
        }

    }
}
