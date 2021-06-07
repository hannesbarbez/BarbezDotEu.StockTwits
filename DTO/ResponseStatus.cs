// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Text.Json.Serialization;

namespace BarbezDotEu.StockTwits.DTO
{
    /// <summary>
    /// Implements a StockTwits response status DTO.
    /// </summary>
    public class ResponseStatus
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}
