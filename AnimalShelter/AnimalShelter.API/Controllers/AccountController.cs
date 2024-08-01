using AnimalShelter.API.Attributes;
using AnimalShelter.API.Exchange;
using AnimalShelter.API.Models; 
using AnimalShelter.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUsersBackend UsersBackend;
        private IUsersExchange UsersExchange;

        public AccountController(IUsersBackend usersBackend, IUsersExchange usersExchange) 
        {
            UsersBackend = usersBackend;
            UsersExchange = usersExchange;
        }
        
        [HttpPost("login")]
        [Consumes("application/json")]
        public async Task<ActionResult<UserModel>> Login([FromBody] LoginModel loginModel)
        {
            
            JwtTokenModel token = UsersExchange.Pack(await UsersBackend.LogIn(loginModel.Username, loginModel.Password));
            if (token == null) 
            {
                return NotFound("Username or password is incorrect");
            }

            Response.Cookies.Append("authToken", token.AccessToken, new CookieOptions
            { 
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = token.AccessTokenExpiration
            });
            return Ok(token);
        }

        [HttpPost("logout")]
        public ActionResult Logout() 
        {
            Response.Cookies.Append("authToken", "", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddDays(-1)
            });
            
            return Ok(new { message = "Logged out successfully"});
        }

        [HttpGet("currentUser")]
        [AuthorizeMiddleware("Administrator")]
        public ActionResult<UserModel> CurrentUser() 
        {
            string? contextId = HttpContext?.Items["id"]?.ToString();
            if (contextId == null) 
            {
                return NotFound();
            }
            
            if (!int.TryParse(contextId, out int id)) 
            {
                return NotFound();
            }

            UserModel? model = UsersExchange.Pack(UsersBackend.GetUserAsync(id).Result);

            if (model == null) 
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
