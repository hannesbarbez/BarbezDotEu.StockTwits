// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using BarbezDotEu.MicroBlog.DTO;
using BarbezDotEu.MicroBlog.Enums;
using BarbezDotEu.Provider;
using BarbezDotEu.StockTwits.DTO;
using BarbezDotEu.StockTwits.Interfaces;
using Microsoft.Extensions.Logging;

namespace BarbezDotEu.StockTwits
{
    /// <summary>
    /// Implements a data provider that connects to and can call StockTwits APIs.
    /// </summary>
    public class StockTwitsDataProvider : PoliteProvider, IStockTwitsDataProvider
    {
        private StockTwitsConfiguration configuration;
        private readonly MediaTypeWithQualityHeaderValue acceptHeader;

        /// <summary>
        /// Gets the <see cref="StockTwitsConfiguration"/> this <see cref="StockTwitsConfiguration"/> uses to communicate to the APIs.
        /// </summary>
        private StockTwitsConfiguration Configuration
        {
            get
            {
                if (this.configuration == null)
                {
                    throw new ApplicationException(
                        $"An {nameof(StockTwitsDataProvider)} cannot be used before it is configured. To fix, call the {nameof(StockTwitsDataProvider)}.{nameof(Configure)} method right after initialization.");
                }

                return this.configuration;
            }
        }

        /// <inheritdoc/>
        public void Configure(StockTwitsConfiguration configuration)
        {
            this.configuration = configuration;
            this.SetRateLimitPerMinute(configuration.MaxCallsPerMinute);
        }

        /// <summary>
        /// Constructs a new <see cref="StockTwitsDataProvider"/>.
        /// </summary>
        /// <param name="logger">A <see cref="ILogger"/> to use for logging.</param>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/> to use.</param>
        public StockTwitsDataProvider(ILogger logger, IHttpClientFactory httpClientFactory)
            : base(logger, httpClientFactory)
        {
            this.acceptHeader = new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json);
        }

        /// <inheritdoc/>
        public async Task<List<MicroBlogEntry>> GetRecentTwits(string symbol, bool retryOnError = true, double waitingMinutesBeforeRetry = 15)
        {
            var result = await this.GetRecentTwitsResponse(symbol, retryOnError, waitingMinutesBeforeRetry);
            if (result.HasFailed)
            {
                this.Logger.LogWarning("Failed request resulted in the following response: {0}", result.HttpResponseMessage);
                return new List<MicroBlogEntry>();
            }

            if (result.Content?.Messages == null || !result.Content.Messages.Any())
                return new List<MicroBlogEntry>();

            return TwitsAsMicroBlogEntries(result.Content.Messages);
        }

        /// <inheritdoc/>
        public async Task<PoliteReponse<StockTwitsResponse>> GetRecentTwitsResponse(string symbol, bool retryOnError = true, double waitingMinutesBeforeRetry = 15)
        {
            var queryUrl = $"{this.Configuration.SearchRecentTwitsUrl}{symbol.ToUpperInvariant()}{this.Configuration.SearchRecentTwitsFields}";
            var request = new HttpRequestMessage(HttpMethod.Get, queryUrl);
            request.Headers.Accept.Add(acceptHeader);
            return await this.Request<StockTwitsResponse>(request, retryOnError, waitingMinutesBeforeRetry);
        }

        /// <inheritdoc/>
        protected override Task<PoliteReponse<T>> Request<T>(HttpRequestMessage request, bool retryOnError = true, double waitingMinutesBeforeRetry = 15)
        {
            try
            {
                return base.Request<T>(request, retryOnError, waitingMinutesBeforeRetry);
            }
            catch (JsonException e)
            {
                base.Logger.LogWarning($"An error occurred that we're going to ignore since occasionally, StockTwits sends back empty responses. Moving on from: {e}");
                return null;
            }
        }

        /// <summary>
        /// Returns a list of <see cref="Twit"/>s as collection of <see cref="MicroBlogEntry"/> items.
        /// </summary>
        /// <returns>A list of <see cref="Twit"/>s as collection of <see cref="MicroBlogEntry"/> items.</returns>
        private static List<MicroBlogEntry> TwitsAsMicroBlogEntries(List<Twit> twits)
        {
            var results = new List<MicroBlogEntry>();

            foreach (var twit in twits)
            {
                var avatarUrl = twit.User.AvatarUrl;
                var avatarUrlSsl = twit.User.AvatarUrlSsl;
                var sourceUrl = twit.Source.Url;

                HashSet<string> urls = new();
                if (!string.IsNullOrWhiteSpace(avatarUrl))
                    urls.Add(avatarUrl);
                if (!string.IsNullOrWhiteSpace(avatarUrlSsl))
                    urls.Add(avatarUrlSsl);
                        if (!string.IsNullOrWhiteSpace(sourceUrl))
                    urls.Add(sourceUrl);

                var username = twit.User.Username;
                var name = twit.User.Name;

                var hasCompanies = twit.Symbols != null && twit.Symbols.Any();
                var companies = hasCompanies
                    ? string.Join(",", twit.Symbols.Select(x => x.Title))
                    : null;

                var hasClassifications = twit.User.Classification != null && twit.User.Classification.Any();
                var classifications = hasClassifications
                    ? string.Join(",", new HashSet<string>(twit.User.Classification))
                    : null;

                HashSet<string> annotations = new();
                if (!string.IsNullOrWhiteSpace(username))
                    annotations.Add($"username: {username}");
                if (!string.IsNullOrWhiteSpace(name))
                    annotations.Add($"name: {name}");
                if (!string.IsNullOrWhiteSpace(companies))
                    annotations.Add($"companies: [{companies}]");
                if (!string.IsNullOrWhiteSpace(classifications))
                    annotations.Add($"user classifications: [{classifications}]");

                string annotationalSmorgasbord = null;
                if (annotations.Any())
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
