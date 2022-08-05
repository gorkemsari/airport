// <copyright file="LocalizeModel.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Airport.Infrastructure.Localization.Models
{
    /// <summary>
    /// Localize model.
    /// </summary>
    public class LocalizeModel
    {
        /// <summary>
        /// gets or sets localization key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// gets or sets localization values.
        /// </summary>
        public Dictionary<string, string> Values { get; set; }
    }
}
