using PlayersBook.Application.ViewModels.Player;

namespace PlayersBook.Application.ViewModels.Advertisement
{
    public class UpdateAdvertisementViewModel
    {
        public Guid Id { get; set; }
        public string GameCategory { get; set; }
        public string GroupCategory { get; set; }
        public bool IsActive { get; set; }
        public string PlayerHostId { get; set; }
        public ICollection<PlayerReferenceViewModel> Guests { get; set; }
    }
}
