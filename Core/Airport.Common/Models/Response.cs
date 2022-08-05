// <copyright file="Response.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Airport.Common.Models
{
    /// <summary>
    /// Global response model.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or sets a value indicating whether Status.
        /// </summary>
        public bool Status { get; set; } = false;

        /// <summary>
        /// Gets or sets Messages.
        /// </summary>
        public List<string> Messages { get; set; }
    }
}
