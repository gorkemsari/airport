// <copyright file="Response{T}.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Airport.Common.Models
{
    /// <summary>
    /// Generic response model.
    /// </summary>
    /// <typeparam name="T">T object.</typeparam>
    public sealed class Response<T> : Response
    {
        /// <summary>
        /// Gets or sets T object.
        /// </summary>
        public T Data { get; set; }
    }
}
