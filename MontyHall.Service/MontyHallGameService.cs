
namespace MontyHall.Service
{
    public class MontyHallGameService : IMontyHallGameService
    {
        //Set static value for number of doors
        private static int NUMBER_OF_DOORS = 3;
        private int _userDoor = 0;
        private Random _random;

        public MontyHallGameService()
        {
            _random = new Random();
        }

        public bool SimulateGame(int numberOfSimulations, bool changeDoor)
        {
            if (numberOfSimulations <= 0) throw new Exception("Simulations should be greater than zero");

            int winsWithChange = 0;
            int winsWithoutChange = 0;
            int revealedDoor = 0;

            for (int i = 0; i < numberOfSimulations; i++)
            {
                //Randomly place the car behind one of the doors
                int carBehindDoor = _random.Next(1, NUMBER_OF_DOORS);

                //For simplicity pick the user door's randomaly and don't take it in the function parameters
                _userDoor = _random.Next(1, NUMBER_OF_DOORS);

                //Reveals a door with a goat, not the player's choice and not where the car is
                var remainingDoors = Enumerable.Range(1, NUMBER_OF_DOORS).Where(i => i != carBehindDoor && i != _userDoor).ToList();
                revealedDoor = remainingDoors[_random.Next(1, remainingDoors.Count()) - 1];

                // If changing the door, choose to a randomly selected unchosen door except user selected door or revealed door
                int changedUserDoor = 0;
                if (changeDoor)
                {
                    remainingDoors = Enumerable.Range(1, NUMBER_OF_DOORS).Where(i => i != _userDoor && i != revealedDoor).ToList();
                    changedUserDoor = remainingDoors[_random.Next(1, remainingDoors.Count()) - 1];
                }

                if (changeDoor)
                {
                    if (changedUserDoor == carBehindDoor) winsWithChange++;
                    else winsWithoutChange++;
                }
                else
                {
                    if (_userDoor == carBehindDoor) winsWithChange++;
                    else winsWithoutChange++;
                }
            };
            return changeDoor ? winsWithChange > winsWithoutChange : winsWithoutChange > winsWithChange;
        }
    }
}
