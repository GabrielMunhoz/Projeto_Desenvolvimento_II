using PlayersBook.Domain.Models.Base;

namespace PlayersBook.Domain.Entities
{
    public class PlayerProfile : BaseEntity
    {
        public Player Player { get; set; }
        public ICollection<ChannelStreams> ChannelStreams { get; set; }
        public string Description { get; set; }
        public int RatingPositive { get; set; }
        public int RatingNegative { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<GamesCategory> GamesCategoryProfile { get; set; }
    }
}
