// <copyright file="AirportDistanceHandler.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Api.Handlers.Airport.Distance.Requests;
using Airport.Api.Handlers.Airport.Distance.Responses;
using Airport.Common.Helpers.Interface;
using Airport.Common.Models;
using Airport.Infrastructure.AirportInfo;
using Airport.Infrastructure.AirportInfo.Requests;
using Airport.Infrastructure.Localization.Interfaces;
using AutoMapper;
using MediatR;

namespace Airport.Api.Handlers.Airport.Distance
{
    /// <summary>
    /// Airport distance handler implementation.
    /// </summary>
    public class AirportDistanceHandler : IRequestHandler<AirportDistanceHandlerRequest, Response<AirportDistanceHandlerResponse>>
    {
        private readonly IAirportInfoService airportInfoService;
        private readonly IResponser responser;
        private readonly IMapper mapper;
        private readonly ICalculator calculator;
        private readonly IValidator validator;
        private readonly ILocalizer localizer;
        private readonly ILogger<AirportDistanceHandler> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirportDistanceHandler"/> class.
        /// </summary>
        /// <param name="airportInfoService">AirportInfoService instance.</param>
        /// <param name="responser">Responser instance.</param>
        /// <param name="mapper">Mapper instance.</param>
        /// <param name="calculator">Calculator instance.</param>
        /// <param name="validator">Validator instance.</param>
        /// <param name="localizer">Localizer instance.</param>
        /// <param name="logger">Logger instance.</param>
        public AirportDistanceHandler(
            IAirportInfoService airportInfoService,
            IResponser responser,
            IMapper mapper,
            ICalculator calculator,
            IValidator validator,
            ILocalizer localizer,
            ILogger<AirportDistanceHandler> logger)
        {
            this.airportInfoService = airportInfoService;
            this.responser = responser;
            this.mapper = mapper;
            this.calculator = calculator;
            this.validator = validator;
            this.localizer = localizer;
            this.logger = logger;
        }

        /// <summary>
        /// Handles airport distance calculation process.
        /// </summary>
        /// <param name="request">AirportDistanceHandlerRequest instance.</param>
        /// <param name="cancellationToken">CancellationToken instance.</param>
        /// <returns>Response.AirportDistanceHandlerResponse.</returns>
        public async Task<Response<AirportDistanceHandlerResponse>> Handle(AirportDistanceHandlerRequest request, CancellationToken cancellationToken)
        {
            if (!this.validator.IsCodeValid(request.DepartureCode).Status ||
                !this.validator.IsCodeValid(request.ArrivalCode).Status)
            {
                var errors = new List<string>()
                {
                    this.localizer["Airport.Error.InvalidCode"],
                    this.localizer["Airport.Error.InvalidCodeAll"],
                };

                return this.responser.Error<AirportDistanceHandlerResponse>(null, errors);
            }

            // Get departure airport's data.
            var departureResponse = await this.airportInfoService.DetailAsync(new AirportDetailRequest()
            {
                Code = request.DepartureCode,
            }).ConfigureAwait(false);

            if (!departureResponse.Status)
            {
                return this.responser.Error<AirportDistanceHandlerResponse>(null, departureResponse.Messages);
            }

            // Get arrival airport's data.
            var arrivalResponse = await this.airportInfoService.DetailAsync(new AirportDetailRequest()
            {
                Code = request.ArrivalCode,
            }).ConfigureAwait(false);

            if (!arrivalResponse.Status)
            {
                return this.responser.Error<AirportDistanceHandlerResponse>(null, arrivalResponse.Messages);
            }

            // Calculate distance between airports as miles.
            var distanceResponse = this.calculator.Distance(
                departureResponse.Data.Location.Lat,
                departureResponse.Data.Location.Lon,
                arrivalResponse.Data.Location.Lat,
                arrivalResponse.Data.Location.Lon,
                'M');

            if (!distanceResponse.Status)
            {
                var errors = new List<string>() { this.localizer["Airport.Error.Calculation"] };

                return this.responser.Error<AirportDistanceHandlerResponse>(null, errors);
            }

            var response = new AirportDistanceHandlerResponse()
            {
                Distance = distanceResponse.Data,
                Type = this.localizer["Global.Mile"],
            };

            return this.responser.Success(response);
        }
    }
}