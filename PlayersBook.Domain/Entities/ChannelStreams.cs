using PlayersBook.Domain.Models.Base;

namespace PlayersBook.Domain.Entities
{
    public class ChannelStreams : BaseEntity
    {
        public string Name { get; set; }
        public string ImageProfile{ get; set; }
        public int IdTwitch { get; set; }
    }
}
