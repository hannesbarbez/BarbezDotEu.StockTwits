﻿// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Collections.Generic;

namespace BarbezDotEu.StockTwits.DTO
{
    public class StockTwitsResponse
    {
        public ResponseStatus Response { get; set; }

        public Security Symbol { get; set; }

        public Cursor Cursor { get; set; }

        public List<Twit> Messages { get; set; }
    }
}
