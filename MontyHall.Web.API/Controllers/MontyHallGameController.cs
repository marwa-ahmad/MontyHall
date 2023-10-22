using Microsoft.AspNetCore.Mvc;
using MontyHall.Service;

namespace MontyHall.Web.API.Controllers
{
    [ApiController]
    [Route("montygame")]
    public class MontyHallGameController : ControllerBase
    {
        private readonly IMontyHallGameService _montyHallGameService;
        public MontyHallGameController(IMontyHallGameService montyHallGameService)
        {
            _montyHallGameService = montyHallGameService;
        }

        [HttpGet]
        [Route("simulate")]
        public async Task<OkObjectResult> SimulateGames([FromQuery] int numberOfSimulations, [FromQuery] bool changeDoor)
        {
            bool isWinner = await Task.Run(()=> _montyHallGameService.SimulateGame(numberOfSimulations, changeDoor));
            return Ok(isWinner);
        }
    }
}