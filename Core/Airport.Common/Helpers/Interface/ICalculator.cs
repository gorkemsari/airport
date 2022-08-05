// <copyright file="ICalculator.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Common.Dependencies;
using Airport.Common.Models;

namespace Airport.Common.Helpers.Interface
{
    /// <summary>
    /// Calculator interface.
    /// </summary>
    public interface ICalculator : IScopedDependency
    {
        /// <summary>
        /// Calculates the distance between two points.
        /// </summary>
        /// <param name="lat1">Latitude of point 1.</param>
        /// <param name="lon1">Longitude of point 1.</param>
        /// <param name="lat2">Latitude of point 2.</param>
        /// <param name="lon2">Longitude of point 2.</param>
        /// <param name="unit">'M' is statute miles (default). 'K' is kilometers. 'N' is nautical miles.</param>
        /// <returns>Distance.</returns>
        Response<double> Distance(double lat1, double lon1, double lat2, double lon2, char unit);
    }
}