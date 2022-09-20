using PlayersBook.Domain.Entities;
using Template.Application.ViewModels;

namespace PlayersBook.Application.Interfaces
{
    public interface IPlayerService
    {
        PlayerAuthenticateResponseViewModel Authenticate(Player user);
        List<Player> Get();
        bool Post(Player player);
        Player GetById(string id);
        bool Put(Player player);
        bool Delete(string id);
    }
}
