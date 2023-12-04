// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

namespace BarbezDotEu.StockTwits.Interfaces
{
    /// <summary>
    /// Defines a blueprint for a StockTwits Symbol.
    /// </summary>
    public interface IHasSymbol
    {
        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        string Symbol { get; }
    }
}
