// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Collections.Generic;
using System.Threading.Tasks;
using BarbezDotEu.MicroBlog.DTO;
using BarbezDotEu.Provider.Interfaces;

namespace BarbezDotEu.StockTwits.Interfaces
{
    public interface IStockTwitsDataProvider : IPoliteProvider
    {
        /// <summary>
        /// Queries for the last 30 twits containing a given symbol.
        /// </summary>
        /// <param name="symbol">The symbol for which to query.</param>
        /// <returns>A list of <see cref="MicroBlogEntry"/> items corresponding to the given symbol.</returns>
        Task<List<MicroBlogEntry>> GetRecentTwits(string symbol);
    }
}
