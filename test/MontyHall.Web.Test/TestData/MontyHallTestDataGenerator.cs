namespace MontyHall.Web.Test.TestData
{
    internal class MontyHallTestDataGenerator
    {
        /// <summary>
        /// Retrieves all test data
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetAllData()
        {
            yield return new object[]
            {
                4,
                true,
                true
            };
            yield return new object[]
            {
                4,
                true,
                false
            };
            yield return new object[]
            {
                4,
                false,
                true
            };
            yield return new object[]
            {
                4,
                false,
                false
            };
        }

        public static IEnumerable<object[]> InvalidData()
        {
            yield return new object[]
            {
                0,
                true,
            };
            yield return new object[]
            {
                -1,
                true,
            };
        }
    }
}
