// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BarbezDotEu.StockTwits.DTO
{
    public class Twit
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("source")]
        public Source Source { get; set; }

        [JsonProperty("symbols")]
        public List<Security> Symbols { get; set; }
    }
}
