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
        public async Task SimulateGames_ChangeDoor_OkResult(int numberOfSimulations, bool changeDoor, bool isWinner)
        {
            //Setup returns
            _montyHallGameService.Setup(c => c.SimulateGame(numberOfSimulations, changeDoor)).Returns(isWinner);

            var response = await _montyHallGameController.SimulateGames(numberOfSimulations, changeDoor);
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(isWinner, (bool)(response as OkObjectResult).Value);
        }

        [Theory]
        [MemberData(nameof(MontyHallTestDataGenerator.InvalidData), MemberType = typeof(MontyHallTestDataGenerator))]
        public async Task SimulateGames_ChangeDoor_ThrowException(int numberOfSimulations, bool changeDoor)
        {
            //Setup returns
            _montyHallGameService.Setup(c => c.SimulateGame(numberOfSimulations, changeDoor)).Throws(new Exception());

            await Assert.ThrowsAsync(typeof(Exception), async ()=> await  _montyHallGameController.SimulateGames(numberOfSimulations, changeDoor));
        }
    }
}