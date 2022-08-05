// <copyright file="HeaderFilter.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Airport.Application.Filters
{
    /// <summary>
    /// Header filter for swagger ui.
    /// </summary>
    public class HeaderFilter : IOperationFilter
    {
        /// <summary>
        /// Apply filter.
        /// </summary>
        /// <param name="operation">OpenApiOperation.</param>
        /// <param name="context">OperationFilterContext.</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Required = true, // set to false if this is optional
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("en-US"),
                },
            });
        }
    }
}
