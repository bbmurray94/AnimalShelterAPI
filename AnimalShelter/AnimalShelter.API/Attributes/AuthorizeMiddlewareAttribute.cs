using AnimalShelter.API.Middlewares;
using AnimalShelter.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AnimalShelter.API.Attributes
{
    public class AuthorizeMiddlewareAttribute : Attribute, IAsyncActionFilter
    {
        private bool allowAnonymous;
        private string[] roles;

        public AuthorizeMiddlewareAttribute(bool _allowAnonymous, params string[] _roles)
        {
            allowAnonymous = _allowAnonymous;
            roles = _roles;
        }

        public AuthorizeMiddlewareAttribute(params string[] _roles) : this(false, _roles) 
        {
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            HttpContext httpContext = context.HttpContext;
            IUsersBackend usersBackend = httpContext.RequestServices.GetService<IUsersBackend>();
            AuthorizationMiddleware middleware = new AuthorizationMiddleware(async _ => await next(), usersBackend, roles, allowAnonymous);
            await middleware.InvokeAsync(httpContext);
        }
    }
}
