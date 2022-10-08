using Newtonsoft.Json;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Domain.DTOs
{
    public class RetTopGamesTwitchDto
    {
        [JsonProperty("data")]
        public ICollection<GamesCategoryDto> GamesCategories { get; set; }
    }
}
