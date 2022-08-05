// <copyright file="AirportDetailErrorResponse.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Text.Json.Serialization;

namespace Airport.Infrastructure.AirportInfo.Responses
{
    /// <summary>
    /// Airport detail error response model.
    /// </summary>
    public class AirportDetailErrorResponse
    {
        /// <summary>
        /// Gets or sets Value.
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        [JsonPropertyName("msg")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Parameter.
        /// </summary>
        [JsonPropertyName("param")]
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or sets Location.
        /// </summary>
        [JsonPropertyName("location")]
        public string Location { get; set; }
    }
}