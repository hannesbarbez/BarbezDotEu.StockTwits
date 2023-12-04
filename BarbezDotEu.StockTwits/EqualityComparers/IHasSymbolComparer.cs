// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using BarbezDotEu.StockTwits.Interfaces;

namespace BarbezDotEu.StockTwits.EqualityComparers
{
    /// <inheritdoc/>
    public class IHasSymbolComparer : IEqualityComparer<IHasSymbol>
    {
        /// <inheritdoc/>
        public bool Equals(IHasSymbol x, IHasSymbol y)
        {
            var stringComparer = StringComparison.InvariantCultureIgnoreCase;
            return string.Equals(x.Symbol, y.Symbol, stringComparer);
        }

        /// <inheritdoc/>
        public int GetHashCode([DisallowNull] IHasSymbol obj)
        {
            return obj.Symbol.ToLowerInvariant().GetHashCode();
        }
    }
}
