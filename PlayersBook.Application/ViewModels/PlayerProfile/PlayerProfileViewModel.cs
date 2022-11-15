using PlayersBook.Application.ViewModels.GamesCategory;

namespace PlayersBook.Application.ViewModels.PlayerProfile
{
    public class PlayerProfileViewModel
    {
        public Guid Id { get; set; }
        public string PlayerId { get; set; }
        public ICollection<ChannelStreamViewModel>? ChannelStreams { get; set; }
        public string? Description { get; set; }
        public int? RatingPositive { get; set; }
        public int? RatingNegative { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<GamesCategoryViewModel>? GamesCategoryProfile { get; set; }
    }
}
