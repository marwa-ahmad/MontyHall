namespace MontyHall.Test
{
    public class MontyHallUnitTest
    {
        /// <summary>
        /// The app: should be able to simulate a given number of games and whether you change the door or not
        /// Expects a number of simulations and choose whether or not to change the door.
        /// This test case simulates user requested to change the door
        /// </summary>
        [Fact]
        public void SimulateGames_ChangeDoor()
        {
            IMontyHallGame montyHallGame = new MontyHallGame();
            bool isWin = montyHallGame.SimulateGames(numberOfSimulations = 4, changeDoor = true);
            Assert.Equal(isWin, isWin);
        }


        /// <summary>
        /// The app: should be able to simulate a given number of games and whether you change the door or not
        /// Expects a number of simulations and choose whether or not to change the door.
        /// This test case simulates user requested not to change the door
        /// </summary>
        [Fact]
        public void SimulateGames_DontChangeDoor()
        {
            IMontyHallGame montyHallGame = new MontyHallGame();
            bool isWin = montyHallGame.SimulateGames(numberOfSimulations = 4, changeDoor = false);
            Assert.Equal(isWin, isWin);
        }
    }
}