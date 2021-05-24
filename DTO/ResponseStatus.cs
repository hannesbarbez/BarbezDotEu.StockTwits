// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Text.Json.Serialization;

namespace BarbezDotEu.StockTwits.DTO
{
    public class ResponseStatus
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}
