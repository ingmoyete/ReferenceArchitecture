using referenceArchitecture.Core.Base.BaseService;
using referenceArchitecture.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace referenceArchitecture.service.ExampleService
{
    public interface IExampleService : IBaseService
    {
        void insertarExample(DTOExample example);
        List<DTOExample> getAllUsers();
        DTOExample getDTOExample(DTOExample example);
    }
}
