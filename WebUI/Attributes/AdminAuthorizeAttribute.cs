using System;
using System.Web.Mvc;
using System.Web.Routing;
using WebUI.Context;

namespace WebUI.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        public string RedirectController { get; set; } = "Home";

        public string RedirectAction { get; set; } = "Index";

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (UserContext.Current.CurrentUser != null &&
                UserContext.Current.CurrentUser.IsAdmin)
            {
                return;
            }

            SetErrorResult(filterContext);
        }

        private void SetErrorResult(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            var routeValues = new RouteValueDictionary
            {
                {"controller", RedirectController},
                { "action", RedirectAction}
            };
            filterContext.Result = new RedirectToRouteResult(routeValues);
        }
    }
}