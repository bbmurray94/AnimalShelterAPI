using AnimalShelter.API.Exchange;
using AnimalShelter.API.Models;
using AnimalShelter.Data.Backends;
using AnimalShelter.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
