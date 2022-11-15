using PlayersBook.Application.ViewModels.PlayerProfile;

namespace PlayersBook.Application.ViewModels.Player
{
    public class PlayerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public PlayerProfileViewModel PlayerProfile { get; set; }
    }
}
