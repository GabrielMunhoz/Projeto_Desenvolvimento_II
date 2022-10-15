using System.Text.Json.Serialization;

namespace PlayersBook.Domain.Entities
{
    public class GamesCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("box_art_url")]
        public string BoxArtUrl { get; set; }
    }
}
