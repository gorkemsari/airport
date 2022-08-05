// <copyright file="IAirportInfoService.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Common.Dependencies;
using Airport.Common.Models;
using Airport.Infrastructure.AirportInfo.Requests;
using Airport.Infrastructure.AirportInfo.Responses;

namespace Airport.Infrastructure.AirportInfo
{
    /// <summary>
    /// Airport information service interface.
    /// </summary>
    public interface IAirportInfoService : IScopedDependency
    {
        /// <summary>
        /// Gets detail information about airport.
        /// </summary>
        /// <param name="request">AirportDetailRequest isntance.</param>
        /// <returns>Response.AirportDetailResponse.</returns>
        Task<Response<AirportDetailResponse>> DetailAsync(AirportDetailRequest request);
    }
}