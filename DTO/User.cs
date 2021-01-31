// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BarbezDotEu.StockTwits.DTO
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("avatar_url_ssl")]
        public string AvatarUrlSsl { get; set; }

        [JsonProperty("identity")]
        public string Identity { get; set; }

        [JsonProperty("classification")]
        public List<string> Classification { get; set; }
    }
}
