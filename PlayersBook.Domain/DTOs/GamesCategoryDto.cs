using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace PlayersBook.Domain.Entities
{
    public class GamesCategoryDto
    {
        public int IdTwitch { get; set; }
        public string Name { get; set; }
        [JsonProperty("box_art_url")]
        public string BoxArtUrl { get; set; }
    }
}
