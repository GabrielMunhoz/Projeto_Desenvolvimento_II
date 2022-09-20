using PlayersBook.Domain.Models.Base;

namespace PlayersBook.Domain.Entities
{
    public class Advertisement:BaseEntity
    {
        public string GameCategory { get; set; }
        public string GroupCategory { get; set; }
        public bool IsActive { get; set; }
        public Player Host { get; set; }
        public List<Player> Guests { get; set; }
    }
}
