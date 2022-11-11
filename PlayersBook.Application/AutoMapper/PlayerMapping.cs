using PlayersBook.Application.ViewModels.Advertisement;
using PlayersBook.Application.ViewModels.Player;
using PlayersBook.Domain.Entities;
using Template.Application.ViewModels;
using Profile = AutoMapper.Profile;

namespace PlayersBook.Application.AutoMapper
{
    public class PlayerMapping : Profile
    {
        public PlayerMapping()
        {
            #region ViewModelToDomain

            CreateMap<PlayerViewModel, Player>();
            CreateMap<NewPlayerViewModel, Player>();
            CreateMap<UpdatePlayerViewModel, Player>();
            CreateMap<PlayerAuthenticateRequestViewModel, Player>();

            #endregion
            #region DomainToViewModel

            CreateMap<Player, PlayerViewModel>();
            CreateMap<AdvertisementPlayers, PlayerViewModel>();
            CreateMap<Player, PlayerReferenceViewModel>().ReverseMap();
            #endregion

            

        }
    }
}
