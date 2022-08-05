// <copyright file="SwaggerExtension.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Application.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace Airport.Application.Extensions
{
    /// <summary>
    /// Swagger documentation extension.
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Adds swagger documentation.
        /// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle address.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Airport Api",
                    Version = "v1",
                    Description = "C Teleport Airport Api",
                });

                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<HeaderFilter>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
        }
    }
}
