using PlayersBook.Application.ViewModels.Player;

namespace PlayersBook.Application.ViewModels.Advertisement
{
    public class AdvertisementGroupedViewModel
    {
        public string GameCategory { get; set; }
        public List<AdvertisementViewModel> Advertisements { get; set; }
    }
}
