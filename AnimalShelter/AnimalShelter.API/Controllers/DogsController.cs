using AnimalShelter.API.Exchange;
using AnimalShelter.API.Models;
using AnimalShelter.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private IDogsBackend DogsBackend;
        private IDogsExchange DogsExchange;
        
        public DogsController(IDogsBackend dogsBackend,
                               IDogsExchange dogsExchange) 
        {
            DogsBackend = dogsBackend;
            DogsExchange = dogsExchange;
        }
        
        [HttpGet]
        [Produces(typeof(List<DogModel>))]
        public async Task<ActionResult<List<DogModel>>> Get() 
        {
            List<DogModel> models = DogsExchange.Pack(DogsBackend.GetDogList().Result).ToList();
            return Ok(models);
        }

        [HttpGet("{id}", Name = "GetDogById")]
        public async Task<ActionResult<DogModel>> Get(int id) 
        {
            DogModel dogModel = DogsExchange.Pack(DogsBackend.GetDog(id).Result);
            return Ok(dogModel);
        }
    }
}
