using PlayersBook.Application.ViewModels.Player;
using PlayersBook.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace PlayersBook.Application.AutoMapper
{
    public class AutoMapperSetup: Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<PlayerViewModel, Player>();

            #endregion

            #region DomainToViewModel

            CreateMap<Player, PlayerViewModel>();

            #endregion
        }
    }
}
