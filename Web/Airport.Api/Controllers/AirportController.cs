// <copyright file="AirportController.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Api.Handlers.Airport.Distance.Requests;
using Airport.Api.Handlers.Airport.Distance.Responses;
using Airport.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Airport.Api.Controllers
{
    /// <summary>
    /// Airport api.
    /// </summary>
    [ApiController]
    [Route("airports")]
    [Produces("application/json")]
    public class AirportController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirportController"/> class.
        /// </summary>
        /// <param name="mediator">Mediator instance.</param>
        public AirportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Airport distance calculation endpoint.
        /// </summary>
        /// <param name="departureCode">3-letter iata airport departure code.</param>
        /// <param name="arrivalCode">3-letter iata airport arrival code.</param>
        /// <returns>Response.AirportDistanceHandlerResponse.</returns>
        [HttpGet("distance/{departureCode}/{arrivalCode}")]
        [ProducesResponseType(typeof(Response<AirportDistanceHandlerResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Distance(string departureCode, string arrivalCode)
        {
            var response = await this.mediator.Send(new AirportDistanceHandlerRequest()
            {
                ArrivalCode = arrivalCode,
                DepartureCode = departureCode,
            }).ConfigureAwait(false);

            if (!response.Status)
            {
                return this.BadRequest(response);
            }

            return this.Ok(response);
        }
    }
}