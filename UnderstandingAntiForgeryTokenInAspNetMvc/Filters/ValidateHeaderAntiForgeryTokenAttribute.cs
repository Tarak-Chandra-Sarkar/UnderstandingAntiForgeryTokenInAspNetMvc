using System;
using System.Web.Helpers;
using System.Web.Mvc;

namespace UnderstandingAntiForgeryTokenInAspNetMvc.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple =true, Inherited =true)]
    public class ValidateHeaderAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentException("filtercontext");
            }

            var httpContext = filterContext.HttpContext;
            var cookie = httpContext.Request.Cookies[AntiForgeryConfig.CookieName];
            var __requestVerificationToken = httpContext.Request.Form["__RequestVerificationToken"];

            AntiForgery.Validate(cookie != null ? cookie.Value : null, __requestVerificationToken);
        }
    }
}