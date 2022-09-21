using AutoMapper;
using Moq;
using PlayersBook.Application.AutoMapper;
using PlayersBook.Application.Interfaces;
using PlayersBook.Application.Services;
using PlayersBook.Application.Test.Mock;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;
using System.Linq.Expressions;

namespace PlayersBook.Application.Test.Services
{

    public class PlayerServiceTest
    {
        private PlayerService _playerService;
        private Mock<IPlayerRepository> _playerRepository;
        private IMapper _mapper;
        public PlayerServiceTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperSetup());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            _playerRepository = new Mock<IPlayerRepository>();
            _playerService = new PlayerService(_playerRepository.Object, _mapper);
        }

        #region Valid

        [Fact]
        public void Get_Succes()
        {
            //Arranje
            _playerRepository.Setup(x => x.GetAll()).Returns(PlayerMockSeed.GetPlayers());

            //Act
            var result = _playerService.Get();
            //Assert

            Assert.True(result.Count > 0);

        }
        [Fact]
        public void GetById_SendingValidId_Succes()
        {
            //Arranje
            var idExpected = "d0f606a2-622c-46b8-a844-ae0e817b1839";

            _playerRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Player, bool>>>())).Returns(PlayerMockSeed.GetPlayers().FirstOrDefault());

            //Act
            var result = _playerService.GetById(idExpected);
            //Assert

            Assert.Equal(idExpected, result.Id.ToString());

        }

        [Fact]
        public void Authenticate_SendingValidObject_Succes()
        {
            //Arranje
            var expectedResult = PlayerMockSeed.GetPlayerAuthenticateResponseViewModel();

            _playerRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Player, bool>>>())).Returns(PlayerMockSeed.GetPlayers().FirstOrDefault());

            //Act
            var result = _playerService.Authenticate(new Player
            {
                Nickname = "Gmunho",
                Password = "2E6F9B0D5885B6010F9167787445617F553A735F"
            });
            //Assert

            Assert.Equal(expectedResult.Player.Name, result.Player.Name);
            Assert.True(!string.IsNullOrEmpty(result.Token));
        }

        #endregion

        #region Invalid

        [Fact]
        public void Get_Error()
        {
            //Arranje

            //Act
            var result = _playerService.Get();
            //Assert

            Assert.True(result.Count == 0);

        }
        [Fact]
        public void GetById_SendingInValidId_Error()
        {
            //Arranje
            string messageExpected = "user id is not valid";

            _playerRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Player, bool>>>())).Returns(PlayerMockSeed.GetPlayers().FirstOrDefault());

            //Act
            var ex = Assert.Throws<Exception>(() => _playerService.GetById(It.IsAny<string>()));
            //Assert
            Assert.Equal(ex.Message, messageExpected);
        }
        [Fact]
        public void GetById_SendingValidId_NotFound()
        {
            //Arranje
            string validId = "14ac6deb-65f7-4cb4-b050-6cff4192d668";
            string messageExpected = "Player not foud";

            _playerRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Player, bool>>>()));

            //Act
            var ex = Assert.Throws<Exception>(() => _playerService.GetById(validId));
            //Assert
            Assert.Equal(ex.Message, messageExpected);
        }
        [Fact]
        public void Authenticate_SendingInValidObject_RequiredFields()
        {
            //Arranje
            var msgExpected = "Nickname/password are required";

            var expectedResult = PlayerMockSeed.GetPlayerAuthenticateResponseViewModel();

            _playerRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Player, bool>>>())).Returns(PlayerMockSeed.GetPlayers().FirstOrDefault());

            //Act
            var ex = Assert.Throws<Exception>(() => _playerService.Authenticate(new Player
            {
                Nickname = "Gmunho"
            }));

            //Assert

            Assert.Equal(ex.Message, msgExpected);
        }
        [Fact]
        public void Authenticate_SendingInValidObject_NotFound()
        {
            //Arranje
            var msgExpected = "Player not found";

            var expectedResult = PlayerMockSeed.GetPlayerAuthenticateResponseViewModel();

            _playerRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Player, bool>>>()));

            //Act
            var ex = Assert.Throws<Exception>(() => _playerService.Authenticate(new Player
            {
                Nickname = "Gmunho",
                Password = "2E6F9B0D5885B6010F9167787445617F553A735F"
            }));

            //Assert

            Assert.Equal(ex.Message, msgExpected);
        }

        #endregion
    }
}
