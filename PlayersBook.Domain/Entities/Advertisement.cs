using PlayersBook.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersBook.Domain.Entities
{
    public class Advertisement : BaseEntity
    {

        public string GameCategory { get; set; }
        public string GroupCategory { get; set; }
        public string TagHostGame { get; set; }
        public string LinkDiscord { get; set; }
        public bool VoiceChannel { get; set; }
        public bool IsActive { get; set; }
        public ICollection<AdvertisementPlayers> Guests { get; set; }
        public string PlayerHostId { get; set; }
        public DateTime ExpireIn { get; set; }
        [NotMapped]
        public Player Host { get; set; }

        
    }
}
