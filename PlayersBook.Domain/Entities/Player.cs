using PlayersBook.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersBook.Domain.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<AdvertisementPlayers> Advertisements { get; set; }
        public PlayerProfile PlayerProfile { get; set; }
    }
}
