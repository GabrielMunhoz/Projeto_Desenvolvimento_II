using PlayersBook.Domain.Entities;

namespace PlayersBook.Domain.DTOs
{
    public class AdvertisementsGroupedByGame
    {
        public GamesCategory GameCategory { get; set; }
        public List<Advertisement> Advertisements { get; set; }

    }
}
