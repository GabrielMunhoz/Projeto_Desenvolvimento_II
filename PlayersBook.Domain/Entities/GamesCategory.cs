using Newtonsoft.Json;
using PlayersBook.Domain.Models.Base;

namespace PlayersBook.Domain.Entities
{
    public class GamesCategory : BaseEntity
    {

        [JsonProperty("id")]
        public int IdTwitch { get; set; }
        public string Name { get; set; }
        [JsonProperty("box_art_url")]
        public string BoxArtUrl { get; set; }
    }
}
