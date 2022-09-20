using PlayersBook.Application.Interfaces;
using PlayersBook.Auth.Services;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;
using Template.Application.ViewModels;

namespace PlayersBook.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }
        public PlayerAuthenticateResponseViewModel Authenticate(Player player)
        {
            if (string.IsNullOrEmpty(player.Email) || string.IsNullOrEmpty(player.Password))
                throw new Exception("player email/password is not valid");

            player.Password = EncryptPassword(player.Password);

            Player playerDB = playerRepository.Find(x => !x.IsDeleted
                                                    && x.Email.ToLower() == player.Email.ToLower()
                                                    && x.Password.ToLower() == player.Password.ToLower());

            if (playerDB == null)
                throw new Exception("Player not found");

            return new PlayerAuthenticateResponseViewModel(playerDB,
                                                        TokenService.GenerateToken(playerDB));
        }

        public bool Post(Player player)
        {
            throw new NotImplementedException();
        }

        public List<Player> Get()
        {
            return playerRepository.GetAll().ToList();
        }

        public Player GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid playerId))
                throw new Exception("user id is not valid");

            Player player = playerRepository.Find(x => x.Id == playerId && !x.IsDeleted);

            if (player == null)
                throw new Exception("User not foud");

            return player;
        }

        public bool Put(Player player)
        {
            if (player.Id == Guid.Empty)
                throw new Exception("Player id is not valid");

            Player playerDB = playerRepository.Find(x => x.Id == player.Id && !x.IsDeleted);

            if (playerDB == null)
                throw new Exception("Player not foud");

            player.Password = EncryptPassword(player.Password);

            return playerRepository.Update(player);
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }


        #region EncryptPassword
        private string EncryptPassword(string password)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            byte[] encryptedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                stringBuilder.Append(caracter.ToString("X2"));
            }
            return stringBuilder.ToString();
        }

        #endregion
    }
}
