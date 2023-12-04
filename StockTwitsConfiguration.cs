// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

namespace BarbezDotEu.StockTwits
{
    /// <summary>
    /// Implements and houses configuration parameters to correctly connect to and communicate with StockTwits' services.
    /// </summary>
    /// <remarks>
    /// Constructs a new <see cref="StockTwitsConfiguration"/> using given parameters.
    /// </remarks>
    /// <param name="maxCallsPerMinute">The maximum number of calls allowed per minute (see the StockTwits.com developer website for current rates).</param>
    public class StockTwitsConfiguration(long maxCallsPerMinute)
    {
        /// <summary>
        /// Gets the maximum number of calls allowed per minute (see the StockTwits.com developer website for current rates).
        /// </summary>
        public long MaxCallsPerMinute { get; } = maxCallsPerMinute;

        /// <summary>
        /// Gets the fully-qualified URL to use to search for symbols in recent twits, including the API key. However, omits the actual search symbol and file extension.
        /// </summary>
        public string SearchRecentTwitsUrl { get; } = "https://api.stocktwits.com/api/2/streams/symbol/";

        /// <summary>
        /// Gets the file extension to end the <see cref="SearchRecentTwitsUrl"/> with, post-symbol. Most likely: .json
        /// </summary>
        public string SearchRecentTwitsFields { get; } = ".json";
    }
}
