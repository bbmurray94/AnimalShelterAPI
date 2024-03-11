using AnimalShelter.API.Exchange;
using AnimalShelter.API.Models;
using AnimalShelter.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            List<DogModel>? models = DogsExchange.Pack(DogsBackend.GetDogList().Result).ToList();
            if (models == null)
            {
                return NotFound();
            }
            return Ok(models);
        }

        [HttpGet("{id}", Name = "GetDogById")]
        public async Task<ActionResult<DogModel>> Get(int id)
        {
            DogModel dogModel = DogsExchange.Pack(DogsBackend.GetDog(id).Result);
            if (dogModel == null)
            {
                return NotFound();
            }
            return Ok(dogModel);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<DogModel>> Post([FromBody] DogModel input)
        {
            if (input == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Given Dog is null");
            }
            DogModel? dogModel = DogsExchange.Pack(DogsBackend.AddDog(DogsExchange.Unpack(input)).Result);
            return Ok(dogModel);
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<DogModel>> Put([FromBody] DogModel input, int id)
        {
            if (input == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Given Dog is null");
            }
            DogModel? dogModel = DogsExchange.Pack(DogsBackend.UpdateDog(id, DogsExchange.Unpack(input)).Result);
            if (dogModel == null)
            {
                return NotFound();
            }
            return Ok(dogModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool deleted = DogsBackend.DeleteDog(id).Result;
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}/notes")]
        public async Task<ActionResult> GetNoteListForDog(int id) 
        {
            List<DogNoteModel>? models = DogsExchange.Pack(DogsBackend.GetNoteListForDog(id).Result).ToList();
            if (models == null)
            {
                return NotFound();
            }
            return Ok(models);
        }

        [HttpGet("{dogId}/notes/{noteId}")]
        public async Task<ActionResult> GetNoteForDog(int dogId, int noteId) 
        {
            DogNoteModel? dogNoteModel = DogsExchange.Pack(DogsBackend.GetNoteForDog(dogId, noteId).Result);
            if (dogNoteModel == null)
            {
                return NotFound();
            }
            return Ok(dogNoteModel);
        }
    }
}
