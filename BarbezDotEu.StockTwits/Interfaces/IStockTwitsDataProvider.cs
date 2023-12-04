// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Collections.Generic;
using System.Threading.Tasks;
using BarbezDotEu.MicroBlog.DTO;
using BarbezDotEu.Provider;
using BarbezDotEu.Provider.Interfaces;
using BarbezDotEu.StockTwits.DTO;

namespace BarbezDotEu.StockTwits.Interfaces
{
    /// <summary>
    /// Defines a blueprint for a data provider that connects to and can call StockTwits APIs.
    /// </summary>
    public interface IStockTwitsDataProvider : IPoliteProvider
    {
        /// <summary>
        /// Queries for the last 30 twits containing a given symbol. Uses <see cref="GetRecentTwitsResponse(string, bool, double)"/> underneath.
        /// </summary>
        /// <param name="symbol">The symbol for which to query.</param>
        /// <param name="retryOnError">Set to TRUE to retry the request, in case the initial request should prove unsuccessful.</param>
        /// <param name="waitingMinutesBeforeRetry">The number of minutes to wait before automatically retrying re-sending the request, if the intention is to retry again upon error.</param>
        /// <returns>A list of <see cref="MicroBlogEntry"/> items corresponding to the given symbol.</returns>
        Task<IEnumerable<MicroBlogEntry>> GetRecentTwits(string symbol, bool retryOnError = true, double waitingMinutesBeforeRetry = 15);

        /// <summary>
        /// Queries for the last 30 twits containing a given symbol.
        /// </summary>
        /// <param name="symbol">The symbol for which to query.</param>
        /// <param name="retryOnError">Set to TRUE to retry the request, in case the initial request should prove unsuccessful.</param>
        /// <param name="waitingMinutesBeforeRetry">The number of minutes to wait before automatically retrying re-sending the request, if the intention is to retry again upon error.</param>
        /// <returns>A list of <see cref="MicroBlogEntry"/> items corresponding to the given symbol.</returns>
        Task<PoliteReponse<StockTwitsResponse>> GetRecentTwitsResponse(string symbol, bool retryOnError = true, double waitingMinutesBeforeRetry = 15);

        /// <summary>
        /// Returns a list of <see cref="Twit"/>s as collection of <see cref="MicroBlogEntry"/> items.
        /// </summary>
        /// <returns>A list of <see cref="Twit"/>s as collection of <see cref="MicroBlogEntry"/> items.</returns>
        IEnumerable<MicroBlogEntry> GetTwitsAsMicroBlogEntries(IEnumerable<Twit> twits);

        /// <summary>
        /// Returns a list of unique <see cref="Security"/> objects as found inside a given collection of <see cref="Twit"/>s.
        /// </summary>
        /// <param name="twits">The <see cref="Twit"/>s out of which to extract a list of unique <see cref="Security"/> objects.</param>
        /// <returns>A list of unique <see cref="Security"/> objects as found inside a given collection of <see cref="Twit"/>s.</returns>
        IEnumerable<Security> GetSecurities(IEnumerable<Twit> twits);
    }
}
