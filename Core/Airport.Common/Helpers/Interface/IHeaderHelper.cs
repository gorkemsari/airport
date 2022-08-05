// <copyright file="IHeaderHelper.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Common.Dependencies;

namespace Airport.Common.Helpers.Interface
{
    /// <summary>
    /// HeaderHelper interface.
    /// Request headers methods.
    /// </summary>
    public interface IHeaderHelper : IScopedDependency
    {
        /// <summary>
        /// Gets Accept-Language value.
        /// </summary>
        /// <returns>string.</returns>
         string GetAcceptLanguage();

        /// <summary>
        /// Gets remote ip address.
        /// </summary>
        /// <returns>string.</returns>
         string GetIpAddress();
    }
}