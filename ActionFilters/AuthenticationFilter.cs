using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using virtualReality.Entities;
using virtualReality.Extensions;

namespace ProjectManagement.ActionFilters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObject<User>("loggedUser") == null)
            {
                context.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}
