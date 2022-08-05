// <copyright file="AirportDistanceHandlerResponse.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Airport.Api.Handlers.Airport.Distance.Responses
{
    /// <summary>
    /// Airport distance handler response model.
    /// </summary>
    public class AirportDistanceHandlerResponse
    {
        /// <summary>
        /// Gets or sets Distance.
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        public string Type { get; set; }
    }
}