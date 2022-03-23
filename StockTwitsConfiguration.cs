// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

namespace BarbezDotEu.StockTwits
{
    /// <summary>
    /// Implements and houses configuration parameters to correctly connect to and communicate with StockTwits' services.
    /// </summary>
    public class StockTwitsConfiguration
    {
        /// <summary>
        /// Gets the maximum number of calls allowed per minute (see the StockTwits.com developer website for current rates).
        /// </summary>
        public long MaxCallsPerMinute { get; }

        /// <summary>
        /// Gets the fully-qualified URL to use to search for symbols in recent twits, including the API key. However, omits the actual search symbol and file extension.
        /// </summary>
        public string SearchRecentTwitsUrl { get; }

        /// <summary>
        /// Gets the file extension to end the <see cref="SearchRecentTwitsUrl"/> with, post-symbol. Most likely: .json
        /// </summary>
        public string SearchRecentTwitsFields { get; }

        /// <summary>
        /// Constructs a new <see cref="StockTwitsConfiguration"/> using given parameters.
        /// </summary>
        /// <param name="maxCallsPerMinute">The maximum number of calls allowed per minute (see the StockTwits.com developer website for current rates).</param>
        public StockTwitsConfiguration(long maxCallsPerMinute)
        {
            this.MaxCallsPerMinute = maxCallsPerMinute;
            this.SearchRecentTwitsUrl = "https://api.stocktwits.com/api/2/streams/symbol/";
            this.SearchRecentTwitsFields = ".json";
        }
    }
}
