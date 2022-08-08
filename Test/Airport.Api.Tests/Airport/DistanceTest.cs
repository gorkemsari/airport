// <copyright file="DistanceTest.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Api.Handlers.Airport.Distance;
using Airport.Api.Handlers.Airport.Distance.Requests;
using Airport.Common.Helpers;
using Airport.Infrastructure.AirportInfo;
using Airport.Infrastructure.Localization.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Airport.Api.Tests.Airport
{
    /// <summary>
    /// Distance handler test implementation.
    /// </summary>
    public class DistanceTest
    {
        private readonly AirportDistanceHandler handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistanceTest"/> class.
        /// </summary>
        public DistanceTest()
        {
            var responser = new Responser();
            var calculator = new Calculator(responser);

            var configuration = new Mock<IConfiguration>();
            configuration.SetupGet(x => x[It.Is<string>(s => s == "Regex:Code3")]).Returns("^[A-Z]{3}$");
            configuration.SetupGet(x => x[It.Is<string>(s => s == "CTeleport:Url")]).Returns("https://places-dev.cteleport.com/");
            configuration.SetupGet(x => x[It.Is<string>(s => s == "CTeleport:Airport:Detail")]).Returns("airports/{0}");

            var validator = new Validator(configuration.Object, responser);
            var localizer = new Mock<ILocalizer>().Object;

            var airportInfoService = new AirportInfoService(
                configuration.Object,
                responser,
                localizer);

            this.handler = new AirportDistanceHandler(
                airportInfoService,
                responser,
                calculator,
                validator,
                localizer,
                new Mock<ILogger<AirportDistanceHandler>>().Object);
        }

        /// <summary>
        /// Checks if parameters ok.
        /// </summary>
        /// <param name="departureCode">3-letter airport code for departure.</param>
        /// <param name="arrivalCode">3-letter airport code for arrival.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Theory]
        [InlineData("ADB", "SAW")]
        public async Task Distance_ReturnsTrue_WhenParametersOK(string departureCode, string arrivalCode)
        {
            // Arrange
            var request = new AirportDistanceHandlerRequest()
            {
                DepartureCode = departureCode,
                ArrivalCode = arrivalCode,
            };

            // Act
            var response = await this.handler.Handle(request, default(CancellationToken)).ConfigureAwait(false);

            // Assert
            Assert.True(response.Status);
        }

        /// <summary>
        /// Checks if parameters not found.
        /// </summary>
        /// <param name="departureCode">3-letter airport code for departure.</param>
        /// <param name="arrivalCode">3-letter airport code for arrival.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Theory]
        [InlineData("XXX", "YYY")]
        public async Task Distance_ReturnsFalse_WhenNotFound(string departureCode, string arrivalCode)
        {
            // Arrange
            var request = new AirportDistanceHandlerRequest()
            {
                DepartureCode = departureCode,
                ArrivalCode = arrivalCode,
            };

            // Act
            var response = await this.handler.Handle(request, default(CancellationToken)).ConfigureAwait(false);

            // Assert
            Assert.False(response.Status);
        }

        /// <summary>
        /// Checks if parameter is short.
        /// </summary>
        /// <param name="departureCode">3-letter airport code for departure.</param>
        /// <param name="arrivalCode">3-letter airport code for arrival.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Theory]
        [InlineData("AD", "SAW")]
        public async Task Distance_ReturnsFalse_WhenParameterIsShort(string departureCode, string arrivalCode)
        {
            // Arrange
            var request = new AirportDistanceHandlerRequest()
            {
                DepartureCode = departureCode,
                ArrivalCode = arrivalCode,
            };

            // Act
            var response = await this.handler.Handle(request, default(CancellationToken)).ConfigureAwait(false);

            // Assert
            Assert.False(response.Status);
        }

        /// <summary>
        /// Checks if parameter has number.
        /// </summary>
        /// <param name="departureCode">3-letter airport code for departure.</param>
        /// <param name="arrivalCode">3-letter airport code for arrival.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Theory]
        [InlineData("ADB", "SA1")]
        public async Task Distance_ReturnsFalse_WhenParameterHasNumber(string departureCode, string arrivalCode)
        {
            // Arrange
            var request = new AirportDistanceHandlerRequest()
            {
                DepartureCode = departureCode,
                ArrivalCode = arrivalCode,
            };

            // Act
            var response = await this.handler.Handle(request, default(CancellationToken)).ConfigureAwait(false);

            // Assert
            Assert.False(response.Status);
        }

        /// <summary>
        /// Checks if parameter is lower case.
        /// </summary>
        /// <param name="departureCode">3-letter airport code for departure.</param>
        /// <param name="arrivalCode">3-letter airport code for arrival.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Theory]
        [InlineData("ADB", "saw")]
        public async Task Distance_ReturnsFalse_WhenParameterLower(string departureCode, string arrivalCode)
        {
            // Arrange
            var request = new AirportDistanceHandlerRequest()
            {
                DepartureCode = departureCode,
                ArrivalCode = arrivalCode,
            };

            // Act
            var response = await this.handler.Handle(request, default(CancellationToken)).ConfigureAwait(false);

            // Assert
            Assert.False(response.Status);
        }
    }
}