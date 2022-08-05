// <copyright file="LocalizeOptions.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Airport.Infrastructure.Localization.Models
{
    /// <summary>
    /// LocalizeOptions model.
    /// </summary>
    public class LocalizeOptions
    {
        /// <summary>
        /// gets or sets default culture.
        /// </summary>
        public string DefaultCulture { get; set; }

        /// <summary>
        /// gets or sets supported culture list.
        /// </summary>
        public IEnumerable<string> SupportedCultures { get; set; }

        /// <summary>
        /// gets or sets resource path.
        /// </summary>
        public string ResourcesPath { get; set; } = "wwwroot/resources/";

        /// <summary>
        /// gets or sets query string name.
        /// </summary>
        public string QueryStringKey { get; set; } = "culture";

        /// <summary>
        /// gets or sets ui query string name.
        /// </summary>
        public string UIQueryStringKey { get; set; } = "ui-culture";

        /// <summary>
        /// gets or sets cookie name.
        /// </summary>
        public string CookieName { get; set; } = ".AspNetCore.Culture";
    }
}
