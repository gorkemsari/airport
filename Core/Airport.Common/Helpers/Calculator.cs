// <copyright file="Calculator.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Common.Helpers.Interface;
using Airport.Common.Models;

namespace Airport.Common.Helpers
{
    /// <summary>
    /// Calculator implementation.
    /// </summary>
    public class Calculator : ICalculator
    {
        private readonly IResponser responser;

        /// <summary>
        /// Initializes a new instance of the <see cref="Calculator"/> class.
        /// </summary>
        /// <param name="responser">Responser instance.</param>
        public Calculator(
            IResponser responser)
        {
            this.responser = responser;
        }

        /// <inheritdoc/>
        public Response<double> Distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return this.responser.Success(0.0);
            }

            var theta = lon1 - lon2;
            var dist = (Math.Sin(this.DegreeToRadian(lat1)) * Math.Sin(this.DegreeToRadian(lat2))) + (Math.Cos(this.DegreeToRadian(lat1)) * Math.Cos(this.DegreeToRadian(lat2)) * Math.Cos(this.DegreeToRadian(theta)));
            dist = Math.Acos(dist);
            dist = this.RadianToDegree(dist);
            dist = dist * 60 * 1.1515;

            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }

            return this.responser.Success(dist);
        }

        /// <summary>
        /// Converts decimal degrees to radians.
        /// </summary>
        /// <param name="deg">Degree.</param>
        /// <returns>Radian.</returns>
        private double DegreeToRadian(double deg)
        {
            return deg * Math.PI / 180.0;
        }

        /// <summary>
        /// Converts radians to decimal degrees.
        /// </summary>
        /// <param name="rad">Radian.</param>
        /// <returns>Degree.</returns>
        private double RadianToDegree(double rad)
        {
            return rad / Math.PI * 180.0;
        }
    }
}