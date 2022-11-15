using Newtonsoft.Json;

namespace PlayersBook.Domain.DTOs
{
    public class ChannelStreamDto
    {
        [JsonProperty("display_name")]
        public string Name { get; set; }
        [JsonProperty("thumbnail_url")]
        public string ImageProfile { get; set; }
        [JsonProperty("id")]
        public int IdTwitch { get; set; }
    }
}
