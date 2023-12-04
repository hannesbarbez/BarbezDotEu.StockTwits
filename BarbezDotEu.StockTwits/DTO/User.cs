// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BarbezDotEu.StockTwits.DTO
{
    /// <summary>
    /// Implements a StockTwits user DTO.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the avatar URL.
        /// </summary>
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Gets or sets the avatar SSL URL.
        /// </summary>
        [JsonPropertyName("avatar_url_ssl")]
        public string AvatarUrlSsl { get; set; }

        /// <summary>
        /// Gets or sets the identity property.
        /// </summary>
        [JsonPropertyName("identity")]
        public string Identity { get; set; }

        /// <summary>
        /// Gets or sets the plus tier property.
        /// </summary>
        [JsonPropertyName("plus_tier")]
        public string PlusTier { get; set; }

        /// <summary>
        /// Gets or sets the premium room value.
        /// </summary>
        [JsonPropertyName("premium_room")]
        public string PremiumRoom { get; set; }

        /// <summary>
        /// Gets or sets the official value.
        /// </summary>
        [JsonPropertyName("official")]
        public bool Official { get; set; }

        /// <summary>
        /// Gets or sets whether the trade app value.
        /// </summary>
        [JsonPropertyName("trade_app")]
        public bool TradeApp { get; set; }

        /// <summary>
        /// Gets or sets the number of followers.
        /// </summary>
        [JsonPropertyName("followers")]
        public long Followers { get; set; }

        /// <summary>
        /// Gets or sets the number of people this user follows.
        /// </summary>
        [JsonPropertyName("following")]
        public long Following { get; set; }

        /// <summary>
        /// Gets or sets the number of ideas.
        /// </summary>
        [JsonPropertyName("ideas")]
        public long Ideas { get; set; }

        /// <summary>
        /// Gets or sets the watchlist stocks count.
        /// </summary>
        [JsonPropertyName("watchlist_stocks_count")]
        public long WatchlistStocksCount { get; set; }

        /// <summary>
        /// Gets or sets the like count.
        /// </summary>
        [JsonPropertyName("like_count")]
        public long LikeCount { get; set; }

        /// <summary>
        /// Gets or sets the classification list.
        /// </summary>
        [JsonPropertyName("classification")]
        public List<string> Classification { get; set; }
    }
}
