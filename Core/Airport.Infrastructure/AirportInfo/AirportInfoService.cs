// <copyright file="AirportInfoService.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Common.Helpers.Interface;
using Airport.Common.Models;
using Airport.Infrastructure.AirportInfo.Requests;
using Airport.Infrastructure.AirportInfo.Responses;
using Airport.Infrastructure.Localization.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text.Json;

namespace Airport.Infrastructure.AirportInfo
{
    /// <summary>
    /// Airport information service implementation.
    /// Gets airport informations from third party api.
    /// </summary>
    public class AirportInfoService : IAirportInfoService
    {
        private readonly IConfiguration configuration;
        private readonly IResponser responser;
        private readonly ILocalizer localizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirportInfoService"/> class.
        /// </summary>
        /// <param name="configuration">Configuration instance.</param>
        /// <param name="responser">Responser instance.</param>
        /// <param name="localizer">Localizer instance.</param>
        public AirportInfoService(
            IConfiguration configuration,
            IResponser responser,
            ILocalizer localizer)
        {
            this.configuration = configuration;
            this.responser = responser;
            this.localizer = localizer;
        }

        /// <inheritdoc/>
        public async Task<Response<AirportDetailResponse>> DetailAsync(AirportDetailRequest request)
        {
            var rootUrl = this.configuration["CTeleport:Url"];
            var path = string.Format(this.configuration["CTeleport:Airport:Detail"], request.Code);
            var url = rootUrl + path;

            using (var httpRequest = new HttpRequestMessage(HttpMethod.Get, url))
            {
                using (var httpResponse = await new HttpClient().SendAsync(httpRequest))
                {
                    var responseString = await httpResponse.Content.ReadAsStringAsync();

                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var responseModel = JsonSerializer.Deserialize<AirportDetailResponse>(responseString);

                        return this.responser.Success(responseModel);
                    }
                    else if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var responseModel = JsonSerializer.Deserialize<List<AirportDetailErrorResponse>>(responseString);
                        var messages = new List<string>();

                        foreach (var model in responseModel)
                        {
                            messages.Add($"{model.Message} ({model.Value})");
                        }

                        return this.responser.Error<AirportDetailResponse>(null, messages);
                    }
                    else if (httpResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        var messages = new List<string>()
                        {
                            $"{this.localizer["Airport.Error.InvalidCode"]} ({request.Code})",
                        };

                        return this.responser.Error<AirportDetailResponse>(null, messages);
                    }

                    return this.responser.Error<AirportDetailResponse>(null);
                }
            }
        }
    }
}