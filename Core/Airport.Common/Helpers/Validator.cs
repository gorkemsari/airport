// <copyright file="Validator.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Common.Helpers.Interface;
using Airport.Common.Models;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace Airport.Common.Helpers
{
    /// <summary>
    /// Validator implemetation.
    /// Validation helper.
    /// </summary>
    public class Validator : IValidator
    {
        private readonly IConfiguration configuration;
        private readonly IResponser responser;

        /// <summary>
        /// Initializes a new instance of the <see cref="Validator"/> class.
        /// </summary>
        /// <param name="responser">Responser instance.</param>
        /// <param name="configuration">Configuration instance.</param>
        public Validator(
            IConfiguration configuration,
            IResponser responser)
        {
            this.configuration = configuration;
            this.responser = responser;
        }

        /// <inheritdoc/>
        public Response IsCodeValid(string code)
        {
            if (!Regex.IsMatch(code, this.configuration["Regex:Code3"]))
            {
                return this.responser.Error();
            }

            return this.responser.Success();
        }
    }
}
