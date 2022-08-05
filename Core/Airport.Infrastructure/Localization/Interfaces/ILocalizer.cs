// <copyright file="ILocalizer.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Airport.Infrastructure.Localization.Interfaces
{
    /// <summary>
    /// Localizer interface.
    /// </summary>
    public interface ILocalizer
    {
        /// <summary>
        /// gets localized data.
        /// </summary>
        /// <param name="key">localization key.</param>
        /// <returns>localized data.</returns>
        string this[string key] { get; }
    }
}
