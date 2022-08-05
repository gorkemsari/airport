// <copyright file="RobotsTxtMiddleware.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Microsoft.AspNetCore.Http;

namespace Airport.Application.Middlewares
{
    /// <summary>
    /// Robots txt middleware.
    /// </summary>
    public class RobotsTxtMiddleware
    {
        private const string Default = @"User-Agent: *\nAllow: /";

        private readonly RequestDelegate next;
        private readonly string environmentName;
        private readonly string rootPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotsTxtMiddleware"/> class.
        /// </summary>
        /// <param name="next">RequestDelegate.</param>
        /// <param name="environmentName">string.</param>
        /// <param name="rootPath">string root path.</param>
        public RobotsTxtMiddleware(
            RequestDelegate next,
            string environmentName,
            string rootPath)
        {
            this.next = next;
            this.environmentName = environmentName;
            this.rootPath = rootPath;
        }

        /// <summary>
        /// Invoke process.
        /// </summary>
        /// <param name="context">HttpContext instance.</param>
        /// <returns>Task.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/robots.txt"))
            {
                var generalRobotsTxt = Path.Combine(this.rootPath, "robots.txt");
                var environmentRobotsTxt = Path.Combine(this.rootPath, $"robots.{this.environmentName}.txt");
                string output;

                // try environment first
                if (File.Exists(environmentRobotsTxt))
                {
                    output = await File.ReadAllTextAsync(environmentRobotsTxt);
                }

                // then robots.txt
                else if (File.Exists(generalRobotsTxt))
                {
                    output = await File.ReadAllTextAsync(generalRobotsTxt);
                }

                // then just a general default
                else
                {
                    output = Default;
                }

                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(output);
            }
            else
            {
                await this.next(context);
            }
        }
    }
}
