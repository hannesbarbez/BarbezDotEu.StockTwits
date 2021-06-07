// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Text.Json.Serialization;

namespace BarbezDotEu.StockTwits.DTO
{
    /// <summary>
    /// Implements a StockTwits conversation DTO.
    /// </summary>
    public class Conversation
    {
        /// <summary>
        /// Gets or sets the parent message id.
        /// </summary>
        [JsonPropertyName("parent_message_id")]
        public long ParentMessageId { get; set; }

        /// <summary>
        /// Gets or sets the message ID this is a reply to.
        /// </summary>
        [JsonPropertyName("in_reply_to_message_id")]
        public long? InReplyToMessageId { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        [JsonPropertyName("parent")]
        public bool Parent { get; set; }

        /// <summary>
        /// Gets or sets the replies.
        /// </summary>
        [JsonPropertyName("replies")]
        public long Replies { get; set; }
    }
}
