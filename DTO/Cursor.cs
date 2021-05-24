// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Text.Json.Serialization;

namespace BarbezDotEu.StockTwits.DTO
{
    public class Cursor
    {
        [JsonPropertyName("more")]
        public string More { get; set; }

        [JsonPropertyName("since")]
        public string Since { get; set; }

        [JsonPropertyName("max")]
        public string Max { get; set; }
    }
}
