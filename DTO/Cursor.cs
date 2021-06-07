// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Text.Json.Serialization;

namespace BarbezDotEu.StockTwits.DTO
{
    public class Cursor
    {
        [JsonPropertyName("more")]
        public bool More { get; set; }

        [JsonPropertyName("since")]
        public long? Since { get; set; }

        [JsonPropertyName("max")]
        public long? Max { get; set; }
    }
}
