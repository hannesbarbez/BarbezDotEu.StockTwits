// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace BarbezDotEu.StockTwits.Tests
{
    [TestClass]
    public class StockTwitsDataProviderCan
    {
        [TestMethod]
        public void HandleNullForGetSecurities()
        {
            // Arrange
            var provider = new StockTwitsDataProvider(Substitute.For<ILogger>(), Substitute.For<IHttpClientFactory>(), new StockTwitsConfiguration(default));

            // Act
            var results = provider.GetSecurities(null);

            // Assert
            Assert.IsNull(results);
        }
    }
}
