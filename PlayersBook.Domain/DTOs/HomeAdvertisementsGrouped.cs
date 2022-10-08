using PlayersBook.Domain.Entities;

namespace PlayersBook.Domain.DTOs
{
    public class AdvertisementsGroupedByGame
    {
        public string GameCategory { get; set; }
        public List<Advertisement> Advertisements { get; set; }

    }
}
