using referenceArchitecture.Core.DTO;
using referenceArchitecture.repository._0.__Edmx;
using referenceArchitecture.repository.Edmx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace referenceArchitecture.repository.ExampleRepository
{
    public interface IExampleRepository
    {
        DTOExample getDTOExample(IDbContext context, DTOExample example);
        void insertarExample(IDbContext context, DTOExample example);
        List<DTOExample> getAllUsers(IDbContext context);
    }
}
