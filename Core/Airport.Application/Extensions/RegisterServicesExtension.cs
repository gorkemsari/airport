// <copyright file="RegisterServicesExtension.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Common.Dependencies;
using Airport.Infrastructure.AirportInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Airport.Application.Extensions
{
    /// <summary>
    /// RegisterServicesExtension.
    /// </summary>
    public static class RegisterServicesExtension
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterServices(this IServiceCollection services)
        {
            // All classes using the 'IScopedDependency' will be registered automatically.
            var asd = AppDomain.CurrentDomain.GetAssemblies();
            var sss = asd.SelectMany(s => s.GetTypes());
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
              .Where(t => typeof(IScopedDependency).IsAssignableFrom(t) && !t.IsInterface).ToList()
              .ForEach(type =>
              {
                  services.AddScoped(type.GetInterface($"I{type.Name}"), type);
              });

            // All classes using the 'ITransientDependency' will be registered automatically.
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
              .Where(t => typeof(ITransientDependency).IsAssignableFrom(t) && !t.IsInterface).ToList()
              .ForEach(type =>
              {
                  services.AddTransient(type.GetInterface($"I{type.Name}"), type);
              });

            // All classes using the 'ISingletonDependency' will be registered automatically.
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
              .Where(t => typeof(ISingletonDependency).IsAssignableFrom(t) && !t.IsInterface).ToList()
              .ForEach(type =>
              {
                  services.AddSingleton(type.GetInterface($"I{type.Name}"), type);
              });

            services.AddScoped<IAirportInfoService, AirportInfoService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
