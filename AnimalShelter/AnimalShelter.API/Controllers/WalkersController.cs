using AnimalShelter.API.Exchange;
using AnimalShelter.API.Models;
using AnimalShelter.Data.Backends;
using AnimalShelter.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
