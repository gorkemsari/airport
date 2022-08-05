// <copyright file="IValidator.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Common.Dependencies;
using Airport.Common.Models;

namespace Airport.Common.Helpers.Interface
{
    /// <summary>
    /// Validator interface.
    /// </summary>
    public interface IValidator : IScopedDependency
    {
        /// <summary>
        /// Gets code is valid or not.
        /// </summary>
        /// <param name="code">3-letter iata code.</param>
        /// <returns>Response.</returns>
        Response IsCodeValid(string code);
    }
}
