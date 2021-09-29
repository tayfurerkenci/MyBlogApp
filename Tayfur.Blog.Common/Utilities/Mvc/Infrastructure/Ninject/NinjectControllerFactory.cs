using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tayfur.Blog.Common.Utilities.Mvc.Infrastructure.Ninject
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        // kernel is a container name for the ninject
        IKernel kernel;

        public NinjectControllerFactory(params INinjectModule[] modules)
        {
            // modules can be 0 or more than 0
            this.kernel = new StandardKernel(modules);
        }
        // when user do request to a controller, controller constructor resolves IAdminService
        // to AdminManager  
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType==null?null:(IController)this.kernel.Get(controllerType);
        }

    }
}
