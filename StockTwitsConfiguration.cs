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
        public string MaxCallsPerMinute { get; }

        /// <summary>
        /// Gets the StockTwits consumer key for your application (which you must first obtain via the StockTwits.com developer website).
        /// </summary>
        public string ConsumerKey { get; }

        /// <summary>
        /// Gets the StockTwits consumer secret for your application (which you must first obtain via the StockTwits.com developer website).
        /// </summary>
        public string ConsumerSecret { get; }

        /// <summary>
        /// Gets the fully-qualified URL to use for OAuth2 authentication.
        /// </summary>
        public string OAuth2TokenUrl { get; }

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
        /// <param name="consumerKey">The StockTwits consumer key for your application (which you must first obtain via the StockTwits.com developer website).</param>
        /// <param name="consumerSecret">The StockTwits consumer secret for your application (which you must first obtain via the StockTwits.com developer website).</param>
        /// <param name="oAuth2TokenUrl">The fully-qualified URL to use for OAuth2 authentication.</param>
        /// <param name="searchRecentTwitsUrl">The fully-qualified URL to use to search for symbols in recent twits, including the API key. However, omits the actual search symbol and file extension.</param>
        /// <param name="searchRecentTwitsFields">The file extension to end the <see cref="SearchRecentTwitsUrl"/> with, post-symbol. Most likely: .json</param>
        public StockTwitsConfiguration(string maxCallsPerMinute, string consumerKey, string consumerSecret, string oAuth2TokenUrl, string searchRecentTwitsUrl, string searchRecentTwitsFields)
        {
            this.MaxCallsPerMinute = maxCallsPerMinute;
            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;
            this.OAuth2TokenUrl = oAuth2TokenUrl;
            this.SearchRecentTwitsUrl = searchRecentTwitsUrl;
            this.SearchRecentTwitsFields = searchRecentTwitsFields;
        }

        /// <summary>
        /// Constructs a new <see cref="StockTwitsConfiguration"/> using given parameters.
        /// </summary>
        /// <param name="maxCallsPerMinute">The maximum number of calls allowed per minute (see the StockTwits.com developer website for current rates).</param>
        /// <param name="consumerKey">The StockTwits consumer key for your application (which you must first obtain via the StockTwits.com developer website).</param>
        /// <param name="consumerSecret">The StockTwits consumer secret for your application (which you must first obtain via the StockTwits.com developer website).</param>
        /// <param name="oAuth2TokenUrl">The fully-qualified URL to use for OAuth2 authentication.</param>
        /// <param name="searchRecentTwitsUrl">The fully-qualified URL to use to search for symbols in recent twits, including the API key. However, omits the actual search symbol and file extension.</param>
        /// <param name="searchRecentTwitsFields">The file extension to end the <see cref="SearchRecentTwitsUrl"/> with, post-symbol. Most likely: .json</param>
        public StockTwitsConfiguration(long maxCallsPerMinute, string consumerKey, string consumerSecret, string oAuth2TokenUrl, string searchRecentTwitsUrl, string searchRecentTwitsFields)
            : this(maxCallsPerMinute.ToString(), consumerKey, consumerSecret, oAuth2TokenUrl, searchRecentTwitsUrl, searchRecentTwitsFields)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="StockTwitsConfiguration"/> using given parameters and using some default settings.
        /// </summary>
        /// <param name="consumerKey">The StockTwits consumer key for your application (which you must first obtain via the StockTwits.com developer website).</param>
        /// <param name="consumerSecret">The StockTwits consumer secret for your application (which you must first obtain via the StockTwits.com developer website).</param>
        public StockTwitsConfiguration(string consumerKey, string consumerSecret)
            : this(3.ToString(), consumerKey, consumerSecret, "https://api.stocktwits.com/api/2/oauth/token", "https://api.stocktwits.com/api/2/streams/symbol/", ".json")
        {
        }

        /// <summary>
        /// Constructs a new <see cref="StockTwitsConfiguration"/> using given parameters and using some default settings.
        /// </summary>
        /// <param name="maxCallsPerMinute">The maximum number of calls allowed per minute (see the StockTwits.com developer website for current rates).</param>
        /// <param name="consumerKey">The StockTwits consumer key for your application (which you must first obtain via the StockTwits.com developer website).</param>
        /// <param name="consumerSecret">The StockTwits consumer secret for your application (which you must first obtain via the StockTwits.com developer website).</param>
        public StockTwitsConfiguration(long maxCallsPerMinute, string consumerKey, string consumerSecret)
            : this(maxCallsPerMinute.ToString(), consumerKey, consumerSecret, "https://api.stocktwits.com/api/2/oauth/token", "https://api.stocktwits.com/api/2/streams/symbol/", ".json")
        {
        }

        /// <summary>
        /// Constructs a new <see cref="StockTwitsConfiguration"/> using given parameters and using some default settings.
        /// </summary>
        /// <param name="maxCallsPerMinute">The maximum number of calls allowed per minute (see the StockTwits.com developer website for current rates).</param>
        /// <param name="consumerKey">The StockTwits consumer key for your application (which you must first obtain via the StockTwits.com developer website).</param>
        /// <param name="consumerSecret">The StockTwits consumer secret for your application (which you must first obtain via the StockTwits.com developer website).</param>
        public StockTwitsConfiguration(string maxCallsPerMinute, string consumerKey, string consumerSecret)
            : this(maxCallsPerMinute, consumerKey, consumerSecret, "https://api.stocktwits.com/api/2/oauth/token", "https://api.stocktwits.com/api/2/streams/symbol/", ".json")
        {
        }
    }
}
