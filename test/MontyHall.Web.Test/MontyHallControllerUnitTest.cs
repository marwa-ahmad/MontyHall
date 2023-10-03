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
            var response = _montyHallGameController.SimulateGames(numberOfSimulations = 4, changeDoor = true);
            var objectResponse = Assert.IsType<OkObjectResult>(response);
            var isWinner = objectResponse.Value as bool;
            Assert.Equal(isWinner, isWinner);
        }
    }
}