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
    public class ActivitiesController : ControllerBase
    {
        private IActivitiesBackend ActivitiesBackend;
        private IActivitiesExchange ActivitiesExchange;

        public ActivitiesController(IActivitiesBackend activitiesBackend,
                                    IActivitiesExchange activitiesExchange)
        {
            ActivitiesBackend = activitiesBackend;
            ActivitiesExchange = activitiesExchange;
        }

        [HttpGet]
        [Produces(typeof(List<DogActivityModel>))]
        public async Task<ActionResult<List<DogActivityModel>>> Get()
        {
            List<DogActivityModel>? models = ActivitiesExchange.Pack(ActivitiesBackend.GetDogActivityList().Result).ToList();
            if (models == null)
            {
                return NotFound();
            }
            return Ok(models);
        }

        [HttpGet("{id}", Name = "GetActvityById")]
        public async Task<ActionResult<DogActivityModel>> Get(int id)
        {
            DogActivityModel dogActivityModel = ActivitiesExchange.Pack(ActivitiesBackend.GetDogActivity(id).Result);
            if (dogActivityModel == null)
            {
                return NotFound();
            }
            return Ok(dogActivityModel);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<int>> Post([FromBody] DogActivityCreationModel input)
        {
            if (input == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Request Body is empoty");
            }
            int id = ActivitiesBackend.AddDogActivity(ActivitiesExchange.Unpack(input)).Result.Id;

            return Created($"/api/activities/{id}", id );
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult> Put([FromBody] DogActivityCreationModel input, int id)
        {
            if (input == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Given Dog is null");
            }
            DogActivityModel? dogModel = ActivitiesExchange.Pack(ActivitiesBackend.UpdateDogActivity(id, ActivitiesExchange.Unpack(input)).Result);
            if (dogModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool deleted = ActivitiesBackend.DeleteDogActivity(id).Result;
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
