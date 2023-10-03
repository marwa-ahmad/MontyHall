using Microsoft.AspNetCore.Mvc;
using MontyHall.Web.API.Controllers;

namespace MontyHall.Web.Test
{
    public class MontyHallControllerUnitTest
    {
        MontyHallGameController _montyHallGameController;
        public MontyHallControllerUnitTest()
        {
            _montyHallGameController = new MontyHallGameController();
        }

        [Fact]
        public void SimulateGames_ChangeDoor_OkResult()
        {
            var response = _montyHallGameController.SimulateGames(numberOfSimulations: 4, changeDoor: true);
            Assert.IsType<OkObjectResult>(response);
            Assert.IsType<bool>((response as OkObjectResult).Value);
        }
    }
}