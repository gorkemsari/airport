// <copyright file="CorsExtension.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Microsoft.Extensions.DependencyInjection;

namespace Airport.Application.Extensions
{
    /// <summary>
    /// Registers cors policies.
    /// </summary>
    public static class CorsExtension
    {
        /// <summary>
        /// Adds the cors services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(x =>
            {
                x.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
    }
}
