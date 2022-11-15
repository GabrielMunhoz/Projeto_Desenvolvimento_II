using PlayersBook.Application.ViewModels.GamesCategory;

namespace PlayersBook.Application.ViewModels.Advertisement
{
    public class NewPlayerProfileViewModel
    {
        public Guid PlayerId { get; set; }
        public ICollection<ChannelStreamViewModel>? ChannelStreams { get; set; }
        public string? Description { get; set; }
        public int? RatingPositive { get; set; }
        public int? RatingNegative { get; set; }
        public ICollection<GamesCategoryViewModel>? GamesCategoryProfile { get; set; }
    }
}
