namespace PlayersBook.Application.ViewModels.PlayerProfile
{
    public class PlayerProfileAllViewModel
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public string? Description { get; set; }
        public int? RatingPositive { get; set; }
        public int? RatingNegative { get; set; }
        public string? ImageUrl { get; set; }
    }
}
