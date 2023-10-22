using System.Net;

namespace MontyHall.Web.Test.TestData
{
    public static class IntegrationTestingData
    {
        public static IEnumerable<object[]> SimulateGamesOkResult()
        {
            yield return new object[]
            {
                2,
                true,
                HttpStatusCode.OK,
            };
            yield return new object[]
            {
                2,
                false,
                HttpStatusCode.OK,
            };
            yield return new object[]
            {
                10,
                true,
                HttpStatusCode.OK,
            };
            yield return new object[]
            {
                10,
                false,
                HttpStatusCode.OK,
            };
        }
    }
}
