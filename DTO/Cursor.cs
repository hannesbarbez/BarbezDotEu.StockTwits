// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using Newtonsoft.Json;

namespace BarbezDotEu.StockTwits.DTO
{
    public class Cursor
    {
        [JsonProperty("more")]
        public bool More { get; set; }

        [JsonProperty("since")]
        public long Since { get; set; }

        [JsonProperty("max")]
        public long Max { get; set; }
    }
}
