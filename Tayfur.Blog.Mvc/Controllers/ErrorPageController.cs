using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Mvc.Controllers
{
    public class ErrorPageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error(int statusCode, Exception exception)
        {
            Response.StatusCode = statusCode;
            var error = new ErrorViewModel
            {
                StatusCode = statusCode.ToString(),
                StatusDescription = HttpWorkerRequest.GetStatusDescription(statusCode),
                Message = exception.Message,
                DateTime = DateTime.Now
            };
            return View(error);
        }
    }
}