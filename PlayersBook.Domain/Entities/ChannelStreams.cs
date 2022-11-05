using PlayersBook.Domain.Models.Base;
using System.Text.Json.Serialization;

namespace PlayersBook.Domain.Entities
{
    public class ChannelStreams : BaseEntity
    {
        [JsonPropertyName("display_name")]
        public string Name { get; set; }
        [JsonPropertyName("thumbnail_url")]
        public string ImageProfile{ get; set; }
    }
}
