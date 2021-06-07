// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace BarbezDotEu.StockTwits.DTO
{
    /// <summary>
    /// Implements a StockTwits twit DTO.
    /// </summary>
    public class Twit
    {
        /// <summary>
        /// Gets or sets the twit id.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the body of the twit.
        /// </summary>
        [JsonPropertyName("body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the twit was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        [JsonPropertyName("source")]
        public Source Source { get; set; }

        /// <summary>
        /// Gets or sets the conversation.
        /// </summary>
        [JsonPropertyName("conversation")]
        public Conversation Conversation { get; set; }

        /// <summary>
        /// Gets or sets the symbols.
        /// </summary>
        [JsonPropertyName("symbols")]
        public List<Security> Symbols { get; set; }

        /// <summary>
        /// Gets a CSV representation of the cashtags in this twit.
        /// </summary>
        /// <returns></returns>
        public string GetCashTagsAsCsv()
        {
            return string.Join(",", this.Symbols.Select(x => x.Symbol));            
        }
    }
}
