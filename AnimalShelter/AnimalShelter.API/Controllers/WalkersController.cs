using AnimalShelter.API.Exchange;
using AnimalShelter.API.Models;
using AnimalShelter.Data.Backends;
using AnimalShelter.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AnimalShelter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkersController : ControllerBase
    {
        private IWalkersBackend WalkersBackend;
        private IWalkersExchange WalkersExchange;
        
        public WalkersController(IWalkersBackend walkersBackend,
                                    IWalkersExchange walkersExchange) 
        {
            WalkersBackend = walkersBackend;
            WalkersExchange = walkersExchange;
        }

        [HttpGet]
        [Produces(typeof(List<DogModel>))]
        public async Task<ActionResult<List<DogModel>>> Get() 
        {
            List<WalkerModel>? models = WalkersExchange.Pack(WalkersBackend.GetWalkerList().Result).ToList();
            if (models == null)
            {
                return NotFound();
            }
            return Ok(models);
        }

        [HttpGet("{id}", Name = "GetWalkerById")]
        public async Task<ActionResult<DogModel>> Get(int id) 
        {
            WalkerModel walkerModel = WalkersExchange.Pack(WalkersBackend.GetWalker(id).Result);
            if (walkerModel == null)
            {
                return NotFound();
            }
            return Ok(walkerModel);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<WalkerModel>> Post([FromBody] WalkerModel input) 
        {
            if (input == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Given Walker is null");
            }
            WalkerModel? walkerModel = WalkersExchange.Pack(WalkersBackend.AddWalker(WalkersExchange.Unpack(input)).Result);
            return Ok(walkerModel);
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<WalkerModel>> Put([FromBody] WalkerModel input, int id)
        {
            if (input == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Given Walker is null");
            }
            WalkerModel? walkerModel = WalkersExchange.Pack(WalkersBackend.UpdateWalker(id, WalkersExchange.Unpack(input)).Result);
            if (walkerModel == null)
            {
                return NotFound();
            }
            return Ok(walkerModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool deleted = WalkersBackend.DeleteWalker(id).Result;
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
