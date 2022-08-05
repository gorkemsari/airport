// <copyright file="IResponser.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Common.Dependencies;
using Airport.Common.Models;

namespace Airport.Common.Helpers.Interface
{
    /// <summary>
    /// Responser interface.
    /// </summary>
    public interface IResponser : IScopedDependency
    {
        /// <summary>
        /// success type.
        /// </summary>
        /// <param name="messages">success messages.</param>
        /// <returns>Response.</returns>
        Response Success(List<string> messages = null);

        /// <summary>
        /// success with a T object.
        /// </summary>
        /// <typeparam name="T">T object.</typeparam>
        /// <param name="data">generic data.</param>
        /// <param name="messages">success messages.</param>
        /// <returns>Response with T object.</returns>
        Response<T> Success<T>(T data, List<string> messages = null);

        /// <summary>
        /// error type.
        /// </summary>
        /// <param name="messages">error messages.</param>
        /// <returns>Response.</returns>
        Response Error(List<string> messages = null);

        /// <summary>
        /// error with a T object.
        /// </summary>
        /// <typeparam name="T">T object.</typeparam>
        /// <param name="data">generic data.</param>
        /// <param name="messages">error messages.</param>
        /// <returns>Response with T object.</returns>
        Response<T> Error<T>(T data, List<string> messages = null);
    }
}