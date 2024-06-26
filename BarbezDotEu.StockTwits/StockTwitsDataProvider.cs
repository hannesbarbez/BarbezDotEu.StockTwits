﻿// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using BarbezDotEu.MicroBlog.DTO;
using BarbezDotEu.MicroBlog.Enums;
using BarbezDotEu.Provider;
using BarbezDotEu.StockTwits.DTO;
using BarbezDotEu.StockTwits.EqualityComparers;
using BarbezDotEu.StockTwits.Interfaces;
using Microsoft.Extensions.Logging;

namespace BarbezDotEu.StockTwits
{
    /// <summary>
    /// Implements a data provider that connects to and can call StockTwits APIs.
    /// </summary>
    public class StockTwitsDataProvider : PoliteProvider, IStockTwitsDataProvider
    {
        private readonly StockTwitsConfiguration configuration;
        private readonly MediaTypeWithQualityHeaderValue acceptHeader;

        /// <summary>
        /// Constructs a new <see cref="StockTwitsDataProvider"/>.
        /// </summary>
        /// <param name="logger">A <see cref="ILogger"/> to use for logging.</param>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/> to use.</param>
        /// <param name="configuration">The <see cref="StockTwitsConfiguration"/> to configure this <see cref="IStockTwitsDataProvider"/> with.</param>
        public StockTwitsDataProvider(ILogger logger, IHttpClientFactory httpClientFactory, StockTwitsConfiguration configuration)
            : base(logger, httpClientFactory)
        {
            this.acceptHeader = new MediaTypeWithQualityHeaderValue("application/json");
            this.configuration = configuration;
            this.SetRateLimitPerMinute(configuration.MaxCallsPerMinute);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MicroBlogEntry>> GetRecentTwits(string symbol, bool retryOnError = true, double waitingMinutesBeforeRetry = 15)
        {
            var result = await this.GetRecentTwitsResponse(symbol, retryOnError, waitingMinutesBeforeRetry);
            if (result.HasFailed)
            {
                this.Logger.LogInformation("Request resulted in the following response: {HttpResponseMessage}", result.HttpResponseMessage);
                return [];
            }

            if (result.Content?.Messages == null || result.Content.Messages.Count == 0)
                return [];

            return GetTwitsAsMicroBlogEntries(result.Content.Messages);
        }

        /// <inheritdoc/>
        public async Task<PoliteReponse<StockTwitsResponse>> GetRecentTwitsResponse(string symbol, bool retryOnError = true, double waitingMinutesBeforeRetry = 15)
        {
            var queryUrl = $"{this.configuration.SearchRecentTwitsUrl}{symbol.ToUpperInvariant()}{this.configuration.SearchRecentTwitsFields}";
            var request = new HttpRequestMessage(HttpMethod.Get, queryUrl);
            request.Headers.Accept.Add(acceptHeader);
            return await this.Request<StockTwitsResponse>(request, retryOnError, waitingMinutesBeforeRetry);
        }

        /// <inheritdoc/>
        public IEnumerable<Security> GetSecurities(IEnumerable<Twit> twits)
        {
            return twits?.SelectMany(x => x?.Symbols)?.ToHashSet<Security>(new IHasSymbolComparer());
        }

        /// <inheritdoc/>
        public IEnumerable<MicroBlogEntry> GetTwitsAsMicroBlogEntries(IEnumerable<Twit> twits)
        {
            var results = new List<MicroBlogEntry>();

            foreach (var twit in twits)
            {
                var avatarUrl = twit.User.AvatarUrl;
                var avatarUrlSsl = twit.User.AvatarUrlSsl;
                var sourceUrl = twit.Source.Url;

                var urls = new HashSet<string>();
                if (!string.IsNullOrWhiteSpace(avatarUrl))
                    urls.Add(avatarUrl);
                if (!string.IsNullOrWhiteSpace(avatarUrlSsl))
                    urls.Add(avatarUrlSsl);
                if (!string.IsNullOrWhiteSpace(sourceUrl))
                    urls.Add(sourceUrl);

                var username = twit.User.Username;
                var name = twit.User.Name;

                var hasCompanies = twit.Symbols != null && twit.Symbols.Count != 0;
                var companies = hasCompanies
                    ? string.Join(",", twit.Symbols.Select(x => x.Title))
                    : null;

                var hasClassifications = twit.User.Classification != null && twit.User.Classification.Count != 0;
                var classifications = hasClassifications
                    ? string.Join(",", new HashSet<string>(twit.User.Classification))
                    : null;

                var annotations = new HashSet<string>();
                if (!string.IsNullOrWhiteSpace(username))
                    annotations.Add($"username: {username}");
                if (!string.IsNullOrWhiteSpace(name))
                    annotations.Add($"name: {name}");
                if (!string.IsNullOrWhiteSpace(companies))
                    annotations.Add($"companies: [{companies}]");
                if (!string.IsNullOrWhiteSpace(classifications))
                    annotations.Add($"user classifications: [{classifications}]");

                string annotationalSmorgasbord = null;
                if (annotations.Count != 0)
                    annotationalSmorgasbord = string.Join(",", annotations);

                var flatTwit = new MicroBlogEntry(
                    twit.User.Id.ToString(),
                    default,
                    twit.CreatedAt,
                    twit.Id.ToString(),
                    default,
                    default,
                    default,
                    JsonSerializer.Serialize(twit.Source),
                    twit.Body,
                    default,
                    default,
                    default,
                    default,
                    default,
                    twit.GetCashTagsAsCsv(),
                    default,
                    JsonSerializer.Serialize(twit.User.Username),
                    urls,
                    annotationalSmorgasbord,
                    default,
                    MicroBlogHost.StockTwits);

                results.Add(flatTwit);
            }

            return results;
        }
    }
}
