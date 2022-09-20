using PlayersBook.Domain.Entities;

namespace Template.Application.ViewModels
{
    public class PlayerAuthenticateResponseViewModel
    {
        public Player Player { get; set; }
        public string Token { get; set; }
        public PlayerAuthenticateResponseViewModel(Player player, string token)
        {
            this.Player = player;
            this.Token = token;
        }
    }
}
