using Microsoft.AspNetCore.Mvc.Testing;
using MontyHall.Web.Test.TestData;
using System.Net;

namespace MontyHall.Web.Test
{
    /// <summary>
    /// Integration testing starting from backend
    /// Ref. https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0
    /// </summary>
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient client;

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            client = factory.CreateClient();
        }

        [Theory]
        [MemberData(nameof(IntegrationTestingData.SimulateGamesOkResult), MemberType = typeof(IntegrationTestingData))]
        public async Task SimulateGames(int numberOfSimulations, bool changeDoor, HttpStatusCode expectedHttpStatusCode)
        {
            var response = await client.GetAsync($"/montygame/simulate?numberOfSimulations={numberOfSimulations}&changeDoor={changeDoor}");

            // TODO: Integration test assertions
            Assert.NotNull(response);
            Assert.Equal(expectedHttpStatusCode, response.StatusCode);
            var responseJson = await response?.Content?.ReadAsStringAsync();
            Assert.NotNull(responseJson);
        }

    }
}
