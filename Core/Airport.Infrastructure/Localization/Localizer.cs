// <copyright file="Localizer.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Infrastructure.Localization.Interfaces;
using System.Globalization;

namespace Airport.Infrastructure.Localization
{
    /// <summary>
    /// Localizer implementation.
    /// </summary>
    public class Localizer : ILocalizer
    {
        private readonly ILocalizeHelper localizeHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Localizer"/> class.
        /// </summary>
        /// <param name="localizeHelper">ILocalizeHelper.</param>
        public Localizer(ILocalizeHelper localizeHelper)
        {
            this.localizeHelper = localizeHelper;
        }

        /// <summary>
        /// Gets localized data.
        /// </summary>
        /// <param name="key">localization key.</param>
        /// <returns>localized data.</returns>
        public string this[string key]
        {
            get
            {
                var value = this.localizeHelper.GetString(CultureInfo.CurrentCulture.Name, key);

                if (string.IsNullOrEmpty(value))
                {
                    return $"[{key}]";
                }

                return value;
            }
        }
    }
}
