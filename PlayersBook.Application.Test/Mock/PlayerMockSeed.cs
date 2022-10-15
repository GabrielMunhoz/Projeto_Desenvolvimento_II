using PlayersBook.Application.ViewModels.Player;
using PlayersBook.Domain.Entities;
using Template.Application.ViewModels;

namespace PlayersBook.Application.Test.Mock
{
    public static class PlayerMockSeed
    {
        public static List<Player> GetPlayers() => new List<Player>
        {
            new Player
            {
                Id = Guid.Parse("d0f606a2-622c-46b8-a844-ae0e817b1839"),
                Name = "Gabriel",
                LastName = "Gmunho",
                Nickname = "Munhoz",
                Email = "gabrielmunhoz@playersbook.com",
                Password = "2E6F9B0D5885B6010F9167787445617F553A735F" //teste
            }
        };
        public static PlayerAuthenticateResponseViewModel GetPlayerAuthenticateResponseViewModel() =>
            new PlayerAuthenticateResponseViewModel(
                new PlayerViewModel
                {

                    Id = Guid.Parse("d0f606a2-622c-46b8-a844-ae0e817b1839"),
                    Name = "Gabriel",
                    LastName = "Gmunho",
                    Nickname = "Munhoz",
                    Email = "gabrielmunhoz@playersbook.com",
                    //Password = "2E6F9B0D5885B6010F9167787445617F553A735F"
                },
                token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiR2FicmllbCIsImVtYWlsIjoiZ2FicmllbG11bmhvekBwbGF5ZXJzYm9vay5jb20iLCJuYW1laWQiOiJkMGY2MDZhMi02MjJjLTQ2YjgtYTg0NC1hZTBlODE3YjE4MzkiLCJuYmYiOjE2NjM3MTkyMjgsImV4cCI6MTY2MzczNzIyOCwiaWF0IjoxNjYzNzE5MjI4fQ.P5E5-lr94NuywsktgAxGOL-PY3vYZipfOy3kCE8gNC8");
    }
}
