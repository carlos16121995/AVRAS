using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace A.V.R.A.S.Filters
{
    public class ValidarAcessoAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var controller = (string)filterContext.RouteData.Values["controller"];
            //var action = (string)filterContext.RouteData.Values["action"];
            //var hostAddress = filterContext.HttpContext.Request.UserHostAddress;
            //var browser = filterContext.HttpContext.Request.UserAgent;
            //var urlReferrer = filterContext.HttpContext.Request.UrlReferrer;

            if (filterContext.HttpContext.Request.Cookies["id"] == null)
            { 
                filterContext.Result = new RedirectResult("/Usuario/Index");
            }
        }
    }
}