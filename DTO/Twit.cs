// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace BarbezDotEu.StockTwits.DTO
{
    public class Twit
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("source")]
        public Source Source { get; set; }

        [JsonPropertyName("symbols")]
        public List<Security> Symbols { get; set; }

        public string GetCashTagsAsCsv()
        {
            // TODO: Low priority, but we could complete missing company name data in the securities table using: x.Title
            return string.Join(",", this.Symbols.Select(x => x.Symbol));            
        }
    }
}
