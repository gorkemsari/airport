// <copyright file="AirportDetailResponse.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Text.Json.Serialization;

namespace Airport.Infrastructure.AirportInfo.Responses
{
    /// <summary>
    /// Airport detail response model.
    /// </summary>
    public class AirportDetailResponse
    {
        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets CityIata.
        /// </summary>
        [JsonPropertyName("city_iata")]
        public string CityIata { get; set; }

        /// <summary>
        /// Gets or sets Iata.
        /// </summary>
        [JsonPropertyName("iata")]
        public string Iata { get; set; }

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets TimezoneRegionName.
        /// </summary>
        [JsonPropertyName("timezone_region_name")]
        public string TimezoneRegionName { get; set; }

        /// <summary>
        /// Gets or sets CountryIata.
        /// </summary>
        [JsonPropertyName("country_iata")]
        public string CountryIata { get; set; }

        /// <summary>
        /// Gets or sets Rating.
        /// </summary>
        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Location.
        /// </summary>
        [JsonPropertyName("location")]
        public AirportDetailLocationResponse Location { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Hubs.
        /// </summary>
        [JsonPropertyName("hubs")]
        public int Hubs { get; set; }
    }
}