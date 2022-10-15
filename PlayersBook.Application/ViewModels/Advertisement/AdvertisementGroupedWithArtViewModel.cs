using PlayersBook.Application.ViewModels.GamesCategory;

namespace PlayersBook.Application.ViewModels.Advertisement
{
    public class AdvertisementGroupedWithArtViewModel
    {
        public GamesCategoryViewModel GameCategory { get; set; }
        public List<AdvertisementViewModel> Advertisements { get; set; }
    }
}
