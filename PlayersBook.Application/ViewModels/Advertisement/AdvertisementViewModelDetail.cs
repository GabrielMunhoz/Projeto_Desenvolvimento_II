using PlayersBook.Application.ViewModels.Player;

namespace PlayersBook.Application.ViewModels.Advertisement
{
    public class AdvertisementDetailViewModel
    {
        public Guid Id { get; set; }
        public string GameCategory { get; set; }
        public string GroupCategory { get; set; }
        public string TagHostGame { get; set; }
        public string LinkDiscord { get; set; }
        public bool VoiceChannel { get; set; }
        public DateTime ExpireIn { get; set; }
        public bool IsActive { get; set; }
        public string PlayerHostId { get; set; }
        public PlayerViewModel Host { get; set; }
        public int GuestCount { get; set; }
        public ICollection<PlayerViewModel> Guests { get; set; }
    }
}