using referenceArchitecture.Core.Exceptions;
using referenceArchitecture.service.Core.Base.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace referenceArchitecture.Core.Base.BaseService
{
    public abstract class BaseService : IBaseService
    {
        // Controller parameter
        private IControllerUI controllerUI;

        /// <summary>
        /// Controller property
        /// </summary>
        public IControllerUI ControllerUI
        {
            get
            {
                return controllerUI;
            }
        }

        /// <summary>
        /// Register the controller in the service.
        /// </summary>
        /// <param name="_controllerUI">Controller object to be registered.</param>
        public void register(IControllerUI _controllerUI)
        {
            // Throw exception if the controller passed is null.
            if (_controllerUI == null) throw new ControllerPassedToServiceIsNull();
            this.controllerUI = _controllerUI;
        }
    }
}
