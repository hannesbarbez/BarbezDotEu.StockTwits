// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BarbezDotEu.StockTwits.DTO
{
    public class User
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("avatar_url_ssl")]
        public string AvatarUrlSsl { get; set; }

        [JsonPropertyName("identity")]
        public string Identity { get; set; }

        [JsonPropertyName("plus_tier")]
        public string PlusTier { get; set; }

        [JsonPropertyName("premium_room")]
        public string PremiumRoom { get; set; }

        [JsonPropertyName("official")]
        public bool Official { get; set; }

        [JsonPropertyName("trade_app")]
        public bool TradeApp { get; set; }

        [JsonPropertyName("followers")]
        public long Followers { get; set; }

        [JsonPropertyName("following")]
        public long Following { get; set; }

        [JsonPropertyName("ideas")]
        public long Ideas { get; set; }

        [JsonPropertyName("watchlist_stocks_count")]
        public long WatchlistStocksCount { get; set; }

        [JsonPropertyName("like_count")]
        public long LikeCount { get; set; }

        [JsonPropertyName("classification")]
        public List<string> Classification { get; set; }
    }
}
