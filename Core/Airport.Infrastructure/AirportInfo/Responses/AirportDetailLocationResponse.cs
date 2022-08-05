// <copyright file="AirportDetailLocationResponse.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Text.Json.Serialization;

namespace Airport.Infrastructure.AirportInfo.Responses
{
    /// <summary>
    /// Airport detail loaction response model.
    /// </summary>
    public class AirportDetailLocationResponse
    {
        /// <summary>
        /// Gets or sets Lon.
        /// </summary>
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        /// <summary>
        /// Gets or sets Lat.
        /// </summary>
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }
}