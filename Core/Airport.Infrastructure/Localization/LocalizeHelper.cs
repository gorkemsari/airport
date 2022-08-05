// <copyright file="LocalizeHelper.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Infrastructure.Localization.Interfaces;
using Airport.Infrastructure.Localization.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Airport.Infrastructure.Localization
{
    /// <summary>
    /// LocalizeHelper implementation.
    /// </summary>
    public class LocalizeHelper : ILocalizeHelper
    {
        private readonly IList<LocalizeModel> localizeModels;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizeHelper"/> class.
        /// </summary>
        /// <param name="options">IOptions.LocalizeOptions.</param>
        public LocalizeHelper(IOptions<LocalizeOptions> options)
        {
            this.localizeModels = new List<LocalizeModel>();

            this.LoadFromDirectory(options.Value.ResourcesPath);
        }

        /// <summary>
        /// gets all localization list.
        /// </summary>
        /// <param name="cultureName">culture name.</param>
        /// <returns>localization list.</returns>
        public IEnumerable<(string key, string value)> GetAllStrings(string cultureName)
        {
            return this.localizeModels
                .Where(l => l.Values.Keys.Any(lv => lv == cultureName))
                .Select(l => (l.Key, l.Values[cultureName]));
        }

        /// <summary>
        /// gets localized data by key.
        /// </summary>
        /// <param name="cultureName">culture name.</param>
        /// <param name="key">localization key.</param>
        /// <returns>string localized value.</returns>
        public string GetString(string cultureName, string key)
        {
            var query = this.localizeModels
                .Where(l => l.Values.Keys.Any(lv => lv == cultureName));

            var value = query.FirstOrDefault(l => l.Key == key);

            if (value == null)
            {
                return null;
            }

            return value.Values[cultureName];
        }

        /// <summary>
        /// loads localization json file.
        /// </summary>
        /// <param name="path">file path.</param>
        private void LoadFromDirectory(string path)
        {
            var files = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                this.LoadFromFile(file);
            }
        }

        /// <summary>
        /// serializes and adds localized list.
        /// </summary>
        /// <param name="path">file path.</param>
        private void LoadFromFile(string path)
        {
            var content = File.ReadAllText(path);

            var entries = JsonSerializer.Deserialize<List<LocalizeModel>>(content);

            foreach (var entry in entries)
            {
                this.localizeModels.Add(entry);
            }
        }
    }
}
