using AnimalShelter.API.Attributes;
using AnimalShelter.API.Exchange;
using AnimalShelter.API.Models;
using AnimalShelter.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.API.Controllers
{
    [Route("api/[controller]")]
    [AuthorizeMiddleware("Administrator")]
    public class AdminController : ControllerBase
    {
        private IUsersBackend _usersBackend;
        private IUsersExchange _usersExchange;
        public AdminController(IUsersBackend usersBackend, IUsersExchange usersExchange)
        {
            _usersBackend = usersBackend;
            _usersExchange = usersExchange;
        }

        [HttpPost("users")]
        [Consumes("application/json")]
        public async Task<ActionResult<UserModel>> Post([FromBody] UserCreationModel input)
        {
            int result = (await _usersBackend.CreateUserAsync(_usersExchange.Unpack(input))).Id;
            return Ok(result);
        }

        [HttpGet("users")]
        public async Task<ActionResult<UserModel>> Get() 
        {
            List<UserModel> result = _usersExchange.Pack(await _usersBackend.GetUsersAsync()).ToList();
            return Ok(result);
        }
    }
}
