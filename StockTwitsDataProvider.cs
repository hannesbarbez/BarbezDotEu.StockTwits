// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BarbezDotEu.StockTwits
{
    public class StockTwitsDataProvider : PoliteProvider, IStockTwitsDataProvider
    {
        private readonly MediaTypeWithQualityHeaderValue acceptHeader;
        private readonly string searchRecentTweetsUrl;
        private readonly string searchRecentTweetsFields;

        public StockTwitsDataProvider(ILogger<IHostedService> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory)
            : base(logger, httpClientFactory)
        {
            this.acceptHeader = new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json);
            this.SetRateLimitPerMinute(configuration["StockTwits:RateLimit:PerMinute"]);
            this.searchRecentTweetsUrl = configuration["StockTwits:SearchRecentTweets:Url"];
            this.searchRecentTweetsFields = configuration["StockTwits:SearchRecentTweets:TweetFields"];
        }

        /// <inheritdoc/>
        public async Task<List<MicroBlogEntry>> GetRecentTwits(string symbol)
        {
            var queryUrl = $"{this.searchRecentTweetsUrl}{symbol.ToUpperInvariant()}{this.searchRecentTweetsFields}";
            var request = new HttpRequestMessage(HttpMethod.Get, queryUrl);
            request.Headers.Accept.Add(acceptHeader);
            var result = await this.Request<StockTwitsResponse>(request);
            if (result?.Messages == null || !result.Messages.Any())
                return new List<MicroBlogEntry>();

            return TwitsAsMicroBlogEntries(result.Messages);
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
                    twit.User.Id,
                    default,
                    twit.CreatedAt,
                    twit.Id,
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
