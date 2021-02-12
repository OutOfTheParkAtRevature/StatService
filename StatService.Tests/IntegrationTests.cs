using System;
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
        [Fact]
        public void TestClientInitialize() {
            var client = Factory.CreateClient();
            Assert.NotNull(client);
        }
    }
}
