using PlayersBook.Application.ViewModels.Player;
using PlayersBook.Domain.Entities;

namespace Template.Application.ViewModels
{
    public class PlayerAuthenticateResponseViewModel
    {
        public PlayerViewModel Player { get; set; }
        public string Token { get; set; }
        public PlayerAuthenticateResponseViewModel(PlayerViewModel player, string token)
        {
            this.Player = player;
            this.Token = token;
        }
    }
}
