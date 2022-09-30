using PlayersBook.Domain.Entities;
using Template.Application.ViewModels;

namespace PlayersBook.Application.Interfaces
{
    public interface IPlayerService
    {
        PlayerAuthenticateResponseViewModel Authenticate(Player user);
        List<Player> Get();
        Task<Player> Post(Player player);
        Task<Player> GetById(string id);
        Task<Player> Put(Player player);
        Task<bool> Delete(string id);
    }
}
