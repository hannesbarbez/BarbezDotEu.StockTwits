// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Collections.Generic;
using System.Net.Http;
using BarbezDotEu.Provider.Interfaces;

namespace BarbezDotEu.StockTwits.DTO
{
    public class StockTwitsResponse : ICanFail
    {
        public ResponseStatus Response { get; set; }

        public Security Symbol { get; set; }

        public Cursor Cursor { get; set; }

        public List<Twit> Messages { get; set; }

        /// <inheritdoc/>
        public HttpResponseMessage FailedResponse { get; set; }

        /// <inheritdoc/>
        public bool HasFailed => FailedResponse != null;
    }
}
