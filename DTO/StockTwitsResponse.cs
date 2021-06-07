// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Collections.Generic;

namespace BarbezDotEu.StockTwits.DTO
{
    /// <summary>
    /// Implements a StockTwits response DTO.
    /// </summary>
    public class StockTwitsResponse
    {
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        public ResponseStatus Response { get; set; }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        public Security Symbol { get; set; }

        /// <summary>
        /// Gets or sets the cursor.
        /// </summary>
        public Cursor Cursor { get; set; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        public List<Twit> Messages { get; set; }
    }
}
