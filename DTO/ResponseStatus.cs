// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using Newtonsoft.Json;

namespace BarbezDotEu.StockTwits.DTO
{
    public class ResponseStatus
    {
        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
