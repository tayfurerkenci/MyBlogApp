using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Tayfur.Blog.Common.Utilities.Mvc.Infrastructure.Ninject;
using Tayfur.Blog.Mvc.Controllers;
using Tayfur.Blog.Mvc.Services.Utility;
using Tayfur.Blog.Service.AutoMapperConfig;
using Tayfur.Blog.Service.DependencyResolvers.Ninject;

namespace Tayfur.Blog.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			ControllerBuilder.Current.SetControllerFactory(
				new NinjectControllerFactory(new ServiceModule()));
			AutoMapperConfiguration.Configure();
		}
		protected void Application_Error(object sender, EventArgs e)
		{
			Exception ex = Server.GetLastError();
			if (ex != null)
			{
				StringBuilder err = new StringBuilder();
				err.Append("Error caught in Application_Error event\n");
				err.Append("Error in: " + (Context.Session == null ? string.Empty : Request.Url.ToString()));
				err.Append("\nError Message:" + ex.Message);
				if (null != ex.InnerException)
					err.Append("\nInner Error Message:" + ex.InnerException.Message);
				err.Append("\n\nStack Trace:" + ex.StackTrace);
				Server.ClearError();

				if (null != Context.Session)
				{
					err.Append($"Session: Identity name:[{Thread.CurrentPrincipal.Identity.Name}] IsAuthenticated:{Thread.CurrentPrincipal.Identity.IsAuthenticated}");
				}
				// singleton pattern error instance!
				MyLogger.GetInstance().Error(err.ToString());

				if (null != Context.Session)
				{
					var routeData = new RouteData();
					routeData.Values.Add("controller", "ErrorPage");
					routeData.Values.Add("action", "Error");
					routeData.Values.Add("exception", ex);

					if (ex.GetType() == typeof(HttpException))
					{
						routeData.Values.Add("statusCode", ((HttpException)ex).GetHttpCode());
					}
					else
					{
						routeData.Values.Add("statusCode", 500);
					}
					Response.TrySkipIisCustomErrors = true;
					IController controller = new ErrorPageController();
					controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
					Response.End();
				}
			}
		}
	}
}
