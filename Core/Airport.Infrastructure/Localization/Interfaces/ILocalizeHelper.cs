// <copyright file="ILocalizeHelper.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Airport.Infrastructure.Localization.Interfaces
{
    /// <summary>
    /// LocalizeHelper interface.
    /// </summary>
    public interface ILocalizeHelper
    {
        /// <summary>
        /// gets localized data by key.
        /// </summary>
        /// <param name="cultureName">culture name.</param>
        /// <param name="key">localization key.</param>
        /// <returns>string localized value.</returns>
        string GetString(string cultureName, string key);

        /// <summary>
        /// gets all localization list.
        /// </summary>
        /// <param name="cultureName">culture name.</param>
        /// <returns>localization list.</returns>
        IEnumerable<(string key, string value)> GetAllStrings(string cultureName);
    }
}
