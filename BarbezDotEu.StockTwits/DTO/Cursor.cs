// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Text.Json.Serialization;

namespace BarbezDotEu.StockTwits.DTO
{
    /// <summary>
    /// Implements a StockTwits cursor DTO.
    /// </summary>
    public class Cursor
    {
        /// <summary>
        /// Gets or sets the more value.
        /// </summary>
        [JsonPropertyName("more")]
        public bool More { get; set; }

        /// <summary>
        /// Gets or sets the since value.
        /// </summary>
        [JsonPropertyName("since")]
        public long? Since { get; set; }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        [JsonPropertyName("max")]
        public long? Max { get; set; }
    }
}
