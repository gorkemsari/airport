// <copyright file="Responser.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Common.Helpers.Interface;
using Airport.Common.Models;

namespace Airport.Common.Helpers
{
    /// <summary>
    /// global response helper.
    /// </summary>
    public class Responser : IResponser
    {
        /// <inheritdoc/>
        public Response Success(List<string> messages = null)
        {
            return new Response()
            {
                Status = true,
                Messages = messages,
            };
        }

        /// <inheritdoc/>
        public Response<T> Success<T>(T data, List<string> messages = null)
        {
            return new Response<T>()
            {
                Status = true,
                Messages = messages,
                Data = data,
            };
        }

        /// <inheritdoc/>
        public Response Error(List<string> messages = null)
        {
            return new Response()
            {
                Status = false,
                Messages = messages,
            };
        }

        /// <inheritdoc/>
        public Response<T> Error<T>(T data, List<string> messages = null)
        {
            return new Response<T>()
            {
                Status = false,
                Messages = messages,
                Data = data,
            };
        }
    }
}
