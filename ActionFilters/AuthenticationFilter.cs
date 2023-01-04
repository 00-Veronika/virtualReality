﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.Entities;
using virtualReality.Extensions;

namespace ProjectManagement.ActionFilters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (context.HttpContext.Session.GetObject<Users>("loggedUser") == null)
            {
                context.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}
