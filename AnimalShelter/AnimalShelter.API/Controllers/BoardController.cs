using AnimalShelter.API.Attributes;
using AnimalShelter.API.Exchange;
using AnimalShelter.API.Models;
using AnimalShelter.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        IBoardBackend BoardBackend;
        IBoardExchange BoardExchange;
        public BoardController(IBoardBackend boardBackend, IBoardExchange boardExchange) 
        {
            BoardBackend = boardBackend;
            BoardExchange = boardExchange;
        }

        [HttpGet]
        [AuthorizeMiddleware("Administrator")]
        public async Task<ActionResult> Get([FromQuery(Name = "date")] string? date = null)
        {
            List<BoardDogItemModel?> models = BoardExchange.Pack(BoardBackend.GetBoard(date).Result).ToList();
            return Ok(models);
        }
    }
}
