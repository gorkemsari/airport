// <copyright file="HeaderHelper.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Common.Helpers.Interface;
using Microsoft.AspNetCore.Http;

namespace Airport.Common.Helpers
{
    /// <summary>
    /// HeaderHelper implementation.
    /// Request headers methods.
    /// </summary>
    public class HeaderHelper : IHeaderHelper
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderHelper"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">HttpContextAccessor instance.</param>
        public HeaderHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <inheritdoc/>
        public string GetAcceptLanguage()
        {
            var context = this.httpContextAccessor.HttpContext;
            var culture = context.Request.Headers["Accept-Language"];

            if (string.IsNullOrEmpty(culture))
            {
                return "en-US";
            }

            return culture;
        }

        /// <inheritdoc/>
        public string GetIpAddress()
        {
            var context = this.httpContextAccessor.HttpContext;
            var ipAddress = context.Connection.RemoteIpAddress.ToString();

            return ipAddress;
        }
    }
}