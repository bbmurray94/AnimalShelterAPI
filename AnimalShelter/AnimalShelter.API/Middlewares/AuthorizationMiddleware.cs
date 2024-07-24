using AnimalShelter.Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AnimalShelter.API.Middlewares
{
    public class AuthorizationMiddleware
    {
        private RequestDelegate next;
        private IUsersBackend usersBackend;
        private string[]? roles;
        private bool allowAnonymous = false;

        public AuthorizationMiddleware(RequestDelegate _next, IUsersBackend _usersBackend, string[]? _roles = null, bool _allowAnonymous = false) 
        {
            next = _next;
            usersBackend = _usersBackend;
            roles = _roles;
            allowAnonymous = _allowAnonymous;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            if (allowAnonymous)
            {
                await next(context);
                return;
            }

            string cookieValue = context.Request.Cookies["authToken"];

            if (!context.Request.Headers.TryGetValue("Authorization", out var authorizationHeader) && cookieValue.IsNullOrEmpty()) 
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Missing Authorization header");
                return;
            }



            string? token = !cookieValue.IsNullOrEmpty() ? cookieValue :authorizationHeader.ToString().Split(' ')[1];

            // Extract claims from the validated token & Create a ClaimsPrincipal based on the validated token claims
            var claimsPrincipal = await usersBackend.ValidateTokenAsync(token);
            if (claimsPrincipal == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Invalid token.");
                return;
            }

            context.User = claimsPrincipal;

            ClaimsIdentity claimsIdentity = context.User.Identity as ClaimsIdentity;
            string userName = claimsIdentity?.FindFirst(ClaimTypes.Name)?.Value;
            string roleClaim = claimsIdentity?.FindFirst(ClaimTypes.Role)?.Value;

            if (roleClaim == null || !roles.Contains(roleClaim))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden: Insufficient permissions.");
                return;
            }

            await next(context);
        }
    }
}
