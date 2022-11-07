using AutoMapper;
using PlayersBook.Application.Interfaces;
using PlayersBook.Application.ViewModels.Player;
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
        private readonly IMapper mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            this.playerRepository = playerRepository;
            this.mapper = mapper;
        }
        public PlayerAuthenticateResponseViewModel Authenticate(Player player)
        {
            if (string.IsNullOrEmpty(player.Nickname) || string.IsNullOrEmpty(player.Password))
                throw new Exception("Nickname/password are required");

            player.Password = EncryptPassword(player.Password);

            Player playerDB = playerRepository.Find(x => !x.IsDeleted
                                                    && (x.Email.ToLower() == player.Nickname.ToLower() 
                                                        || x.Nickname.ToLower() == player.Nickname.ToLower())
                                                    && x.Password.ToLower() == player.Password.ToLower());

            if (playerDB == null)
                throw new Exception("Player not found");

            return new PlayerAuthenticateResponseViewModel(mapper.Map<PlayerViewModel>(playerDB),
                                                        TokenService.GenerateToken(playerDB));
        }

        public async Task<Player> Post(Player player)
        {
            if (!(player.Id == Guid.Empty))
                throw new Exception("Id must be empty");
            player.Password = EncryptPassword(player.Password);
            return await playerRepository.CreateAsync(player);
        }

        public List<Player> Get()
        {
            return playerRepository.GetAll();
        }

        public Task<Player> GetByIdAsync(string id)
        {
            if (!Guid.TryParse(id, out Guid playerId))
                throw new Exception("Player id is not valid");

            Player player = playerRepository.Find(x => x.Id == playerId && !x.IsDeleted);

            if (player == null)
                throw new Exception("Player not foud");

            return Task.FromResult(player);
        }

        public Task<Player> Put(Player player)
        {
            if (player.Id == Guid.Empty)
                throw new Exception("Player id is not valid");

            Player playerDB = playerRepository.Find(x => x.Id == player.Id && !x.IsDeleted);

            if (playerDB == null)
                throw new Exception("Player not foud");

            player.Password = EncryptPassword(player.Password);

            if (!playerRepository.Update(player))
                throw new Exception("Update player failed");

            return Task.FromResult(player); 
        }

        public Task<bool> Delete(string id)
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
