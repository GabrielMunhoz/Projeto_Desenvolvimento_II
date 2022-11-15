using PlayersBook.Application.ViewModels.GamesCategory;
using PlayersBook.Application.ViewModels.Player;

namespace PlayersBook.Application.ViewModels.PlayerProfile
{
    public class PlayerProfileDetailViewModel
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public PlayerViewModel Player { get; set; }
        public ICollection<ChannelStreamViewModel>? ChannelStreams { get; set; }
        public string? Description { get; set; }
        public int? RatingPositive { get; set; }
        public int? RatingNegative { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<GamesCategoryViewModel>? GamesCategoryProfile { get; set; }
    }
}
