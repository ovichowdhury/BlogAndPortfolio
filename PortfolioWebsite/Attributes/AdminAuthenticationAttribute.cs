using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace PortfolioWebsite.Attributes
{
    public class AdminAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["username"] == null)
                filterContext.HttpContext.Response.Redirect("~/Home/Login");
        }   
    }
}