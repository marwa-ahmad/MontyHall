using Microsoft.AspNetCore.Mvc;
using MontyHall.Service;
using MontyHall.Web.API.Controllers;
using MontyHall.Web.Test.TestData;
using Moq;

namespace MontyHall.Web.Test
{
    public class MontyHallControllerUnitTest
    {
        private readonly MontyHallGameController _montyHallGameController;
        private readonly Mock<IMontyHallGameService> _montyHallGameService;

        public MontyHallControllerUnitTest()
        {
            _montyHallGameService = new Mock<IMontyHallGameService>();
            _montyHallGameController = new MontyHallGameController(_montyHallGameService.Object);
        }

        [Theory]
        [MemberData(nameof(MontyHallTestDataGenerator.GetAllData), MemberType = typeof(MontyHallTestDataGenerator))]
        public async Task SimulateGames_ChangeDoor_OkResult(int numberOfSimulations, bool changeDoor, bool isWinnerExpected)
        {
            //Setup returns
            _montyHallGameService.Setup(c => c.SimulateGame(numberOfSimulations, changeDoor)).Returns(isWinnerExpected);

            var response = await _montyHallGameController.SimulateGames(numberOfSimulations, changeDoor);
            Assert.IsType<OkObjectResult>(response);
            OkObjectResult? okObjectResult = response as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(isWinnerExpected, (bool)okObjectResult.Value);
        }

        [Theory]
        [MemberData(nameof(MontyHallTestDataGenerator.InvalidData), MemberType = typeof(MontyHallTestDataGenerator))]
        public async Task SimulateGames_ChangeDoor_BadRequest(int numberOfSimulations, bool changeDoor)
        {
            var result = await  _montyHallGameController.SimulateGames(numberOfSimulations, changeDoor);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}