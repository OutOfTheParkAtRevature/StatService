using System;
using System.Net.Http;
using System.Net.Http.Json;
using Xunit;

using Repository;
using Service;
using Models;

using StatService.Tests.Utils;

namespace StatService.Tests {
    public class IntegrationTests : IClassFixture<StatFactory<Startup>> {
        private StatFactory<Startup> Factory;
        public IntegrationTests(StatFactory<Startup> factory) {
            Factory = factory; 
        }
        private static HttpRequestMessage GenerateMessage(HttpMethod method, string uri) {
            HttpRequestMessage result = new HttpRequestMessage(method, uri);
            result.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            return result;
        }
        [Theory]
        [InlineData("api/BasketballStatistics")]
        [InlineData("api/BaseballStatistics")]
        [InlineData("api/FootBallStatistics")]
        [InlineData("api/GolfStatistics")]
        [InlineData("api/HockeyStatistics")]
        [InlineData("api/SoccerStatistics")]
        public async void TestClientEndpoints(string uri) {
            var client = Factory.CreateClient();
            var request = GenerateMessage(HttpMethod.Get, uri);
            var response = await client.SendAsync(request);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
