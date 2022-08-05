// <copyright file="AirportDetailRequest.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Airport.Infrastructure.AirportInfo.Requests
{
    /// <summary>
    /// Airport detail request model.
    /// </summary>
    public class AirportDetailRequest
    {
        /// <summary>
        /// Gets or sets Code.
        /// 3-letter IATA code.
        /// </summary>
        public string Code { get; set; }
    }
}