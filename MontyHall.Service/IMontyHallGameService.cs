namespace MontyHall.Service
{
    public interface IMontyHallGameService
    {
        /// <summary>
        /// Simulate game
        /// </summary>
        /// <param name="numberOfSimulations"></param>
        /// <param name="changeDoor"></param>
        /// <returns>Returns winning status</returns>
        bool SimulateGame(int numberOfSimulations, bool changeDoor);
    }
}