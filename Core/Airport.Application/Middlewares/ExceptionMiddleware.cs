// <copyright file="ExceptionMiddleware.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Airport.Application.Middlewares
{
    /// <summary>
    /// Exception middleware implementation.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next">RequestDelegate.</param>
        /// <param name="logger">Logger instance.</param>
        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        /// <summary>
        /// Invoke middleware.
        /// </summary>
        /// <param name="httpContext">HttpContext.</param>
        /// <returns>Task.</returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this.next(httpContext);
            }
            catch (Exception ex)
            {
                this.logger.LogError(exception: ex, ex.StackTrace);
            }
        }
    }
}
