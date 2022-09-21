using PlayersBook.Application.ViewModels.Player;
using PlayersBook.Domain.Entities;
using Template.Application.ViewModels;
using Profile = AutoMapper.Profile;

namespace PlayersBook.Application.AutoMapper
{
    public class AutoMapperSetup: Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<PlayerViewModel, Player>();
            CreateMap<PlayerAuthenticateRequestViewModel, Player>();

            #endregion

            #region DomainToViewModel

            CreateMap<Player, PlayerViewModel>();

            #endregion
        }
    }
}
