using referenceArchitecture.service.Core.Base.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace referenceArchitecture.Core.Base.BaseService
{
    public interface IBaseService
    {
        IControllerUI ControllerUI { get; }
        void register(IControllerUI _controllerUI);
    }
}
