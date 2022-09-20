using PlayersBook.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersBook.Domain.Entities
{
    public class Profile : BaseEntity
    {
        public Player Player { get; set; }
        public List<GamesTags> GamesTagsProfile { get; set; }
        public string Description { get; set; }
        public int RatingPositive { get; set; }
        public int RatingNegative { get; set; }
        public List<GamesCategory> GamesCategoryProfile { get; set; }
    }
}
