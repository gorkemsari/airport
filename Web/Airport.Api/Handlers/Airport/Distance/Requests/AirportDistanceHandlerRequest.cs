// <copyright file="AirportDistanceHandlerRequest.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Api.Handlers.Airport.Distance.Responses;
using Airport.Common.Models;
using MediatR;

namespace Airport.Api.Handlers.Airport.Distance.Requests
{
    /// <summary>
    /// Airport distance handler request model.
    /// </summary>
    public class AirportDistanceHandlerRequest : IRequest<Response<AirportDistanceHandlerResponse>>
    {
        /// <summary>
        /// Gets or sets ArrivalCode.
        /// </summary>
        public string ArrivalCode { get; set; }

        /// <summary>
        /// Gets or sets DepartureCode.
        /// </summary>
        public string DepartureCode { get; set; }
    }
}