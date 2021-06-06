// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Text.Json.Serialization;

namespace BarbezDotEu.StockTwits.DTO
{
    public class Conversation
    {
        [JsonPropertyName("parent_message_id")]
        public long ParentMessageId { get; set; }

        [JsonPropertyName("in_reply_to_message_id")]
        public long? InReplyToMessageId { get; set; }

        [JsonPropertyName("parent")]
        public bool Parent { get; set; }

        [JsonPropertyName("replies")]
        public long Replies { get; set; }
    }
}
