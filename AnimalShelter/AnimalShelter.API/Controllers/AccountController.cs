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
            return Ok(token);
        }
    }
}
