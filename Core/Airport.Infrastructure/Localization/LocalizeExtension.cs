// <copyright file="LocalizeExtension.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Infrastructure.Localization.Interfaces;
using Airport.Infrastructure.Localization.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Airport.Infrastructure.Localization
{
    /// <summary>
    /// Localization service collections.
    /// </summary>
    public static class LocalizeExtension
    {
        /// <summary>
        /// add localization extension.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        /// <param name="setupAction">Action.LocalizeOptions.</param>
        /// <returns>returns IServiceCollection.</returns>
        public static IServiceCollection AddLocalizer(this IServiceCollection services, Action<LocalizeOptions> setupAction = null)
        {
            services.AddOptions();

            services.AddSingleton<ILocalizeHelper, LocalizeHelper>();
            services.AddSingleton<ILocalizer, Localizer>();

            if (setupAction != null)
            {
                services.Configure(setupAction);

                // set default cultures by initializing an options instance.
                var options = new LocalizeOptions();

                setupAction.Invoke(options);

                SetDefaultCultures(options);

                var supportedCultures = options.SupportedCultures.Select(s => new CultureInfo(s)).ToList();

                services.Configure<RequestLocalizationOptions>(option =>
                {
                    option.SupportedCultures = supportedCultures;
                    option.SupportedUICultures = supportedCultures;

                    option.RequestCultureProviders = new List<IRequestCultureProvider>()
                    {
                        new QueryStringRequestCultureProvider()
                        {
                            Options = option,
                            QueryStringKey = options.QueryStringKey,
                            UIQueryStringKey = options.UIQueryStringKey,
                        },
                        new CookieRequestCultureProvider()
                        {
                            Options = option,
                            CookieName = options.CookieName,
                        },
                        new AcceptLanguageHeaderRequestCultureProvider()
                        {
                            Options = option,
                        },
                    };
                });
            }

            return services;
        }

        /// <summary>
        /// set default culture.
        /// </summary>
        /// <param name="options">LocalizeOptions.</param>
        private static void SetDefaultCultures(LocalizeOptions options)
        {
            CultureInfo.CurrentCulture = GetCultureByString(options.DefaultCulture);
            CultureInfo.CurrentUICulture = GetCultureByString(options.DefaultCulture);
        }

        /// <summary>
        /// gets culture by culture name.
        /// </summary>
        /// <param name="cultureName">culture name.</param>
        /// <returns>CultureInfo.</returns>
        private static CultureInfo GetCultureByString(string cultureName)
        {
            if (string.IsNullOrEmpty(cultureName))
            {
                return CultureInfo.InvariantCulture;
            }

            return CultureInfo.GetCultureInfo(cultureName);
        }
    }
}
