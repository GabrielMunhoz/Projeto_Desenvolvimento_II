namespace PlayersBook.Domain.Entities
{
    public class AdvertisementPlayers
    {
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public Guid advertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
