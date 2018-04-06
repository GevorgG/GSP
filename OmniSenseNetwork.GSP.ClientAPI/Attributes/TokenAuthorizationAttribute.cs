using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OmniSenseNetwork.GSP.ClientAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class TokenAuthorizationAttribute : ActionFilterAttribute
    {
        public TokenAuthorizationAttribute()
        {
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!IsSkippingAuthorization(context))
            {
                var isAuthorized = await IsAuthorizedAsync(context);
                if (!isAuthorized)
                {
                    HandlUnauthorizedRequest(context);
                    return;
                }
            }
            await base.OnActionExecutionAsync(context, next);
        }

        private async Task<bool> IsAuthorizedAsync(ActionExecutingContext context)
        {
            return true;
        }

        private void HandlUnauthorizedRequest(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        private bool IsSkippingAuthorization(ActionExecutingContext context)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var hasAllowAnonymousAttribute = actionDescriptor.MethodInfo.GetCustomAttributes<AllowAnonymousAttribute>().Any();
            if (hasAllowAnonymousAttribute)
                return true;
            
            var controllerType = context.Controller.GetType();
            hasAllowAnonymousAttribute = controllerType.GetCustomAttributes<AllowAnonymousAttribute>().Any();
            if (hasAllowAnonymousAttribute)
                return true;

            return false;
        }
    }
}
