// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Text.Json.Serialization;
using BarbezDotEu.StockTwits.Interfaces;

namespace BarbezDotEu.StockTwits.DTO
{
    /// <summary>
    /// Implements a StockTwits security DTO.
    /// </summary>
    public class Security : IHasSymbol
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <inheritdoc/>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the watchlist count.
        /// </summary>
        [JsonPropertyName("watchlist_count")]
        public long? WatchlistCount { get; set; }

        /// <summary>
        /// Gets or sets the is following value.
        /// </summary>
        [JsonPropertyName("is_following")]
        public bool IsFollowing { get; set; }
    }
}
