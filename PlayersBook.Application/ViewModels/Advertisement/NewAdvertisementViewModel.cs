using PlayersBook.Application.ViewModels.Player;

namespace PlayersBook.Application.ViewModels.Advertisement
{
    public class NewAdvertisementViewModel
    {
        public string? GameCategory { get; set; }
        public string? GroupCategory { get; set; }
        public string? TagHostGame { get; set; }
        public string? LinkDiscord { get; set; }
        public DateTime? ExpireIn { get; set; }
        public bool VoiceChannel { get; set; }
        public bool IsActive { get; set; }
        public string? PlayerHostId { get; set; }
    }
}
