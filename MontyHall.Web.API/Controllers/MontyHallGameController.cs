using Microsoft.AspNetCore.Mvc;

namespace MontyHall.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MontyHallGameController : ControllerBase
    {
        public MontyHallGameController()
        {
        }

        [HttpGet]
        public OkObjectResult SimulateGames(int numberOfSimulations, bool changeDoor)
        {
            bool isWinner = false;
            return Ok(isWinner);
        }
    }
}